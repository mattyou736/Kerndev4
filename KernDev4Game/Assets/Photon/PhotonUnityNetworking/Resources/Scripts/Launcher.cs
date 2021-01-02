using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using System.Linq;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher Instance;

    [SerializeField]
    TMP_InputField roomNameImputField;

    [SerializeField]
    TMP_Text errorText;

    [SerializeField]
    TMP_Text roomNameText;

    [SerializeField]
    Transform roomListContent;
    [SerializeField]
    Transform playerlistContent;
    [SerializeField]
    GameObject roomListPrefab;
    [SerializeField]
    GameObject playerListPrefab;

    [SerializeField]
    GameObject StartGameButton;

    public MainMenu mainMenu;
    public UserHolder userHolder;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to master");
        //base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
        //syncs scene for all players
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {
        //base.OnJoinedLobby();
        MenuManager.Instance.OpenMenu("title");
        Debug.Log("joined lobby");
        PhotonNetwork.NickName = "Player " + userHolder.usernamePlayer;


    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(roomNameImputField.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomNameImputField.text);
        if (DBManager.LoggedIn)
        {
            PhotonNetwork.NickName = DBManager.username;
            MenuManager.Instance.OpenMenu("loading");
        }
    }

    public override void OnJoinedRoom()
    {
        
        MenuManager.Instance.OpenMenu("room");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;
        Player[] players = PhotonNetwork.PlayerList;

        

        //clear player list that are old
        foreach (Transform child in playerlistContent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < players.Count(); i++)
        {

            Instantiate(playerListPrefab, playerlistContent).GetComponent<PlayerListItem>().SetUp(players[i]);
        }
        //if joining room you cant start the game
        StartGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        //if new host you can start the game
        StartGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "room creation failed" + message;
        MenuManager.Instance.OpenMenu("error");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("loading");
    }

    public void JoinRoom(RoomInfo info)
    {
        if (DBManager.LoggedIn)
        {
            PhotonNetwork.NickName = DBManager.username;
        }
        PhotonNetwork.JoinRoom(info.Name);
        MenuManager.Instance.OpenMenu("loading");
        
    }

    public void StartGame()
    {//loads lvl for all players
        PhotonNetwork.LoadLevel(1);
    }

    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("title");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (Transform trans in roomListContent)
        {
            Destroy(trans.gameObject);
        }

        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].RemovedFromList)
            {
                continue;
            }
            Instantiate(roomListPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(playerListPrefab, playerlistContent).GetComponent<PlayerListItem>().SetUp(newPlayer);
    }
}

