using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class Gamemanager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    public bool gameStarted;

    [SerializeField]
    public bool gameFinished;

    [SerializeField]
    public bool player1Wins,player2Wins;

    [SerializeField]
    public bool redPlayerTurn;

    [SerializeField]
    public bool isRunning;

    public Board player1Board;
    public Board player2Board;

    [SerializeField]
    public int player1BoardSquareDestroyed;
    [SerializeField]
    public int player2BoardSquareDestroyed;

    public GameObject wall;
    public Transform movepoint;

    string usernameWinner = null;
    EndGameValues nameCarryOverScript;

    // Start is called before the first frame update
    void Start()
    {
        player1Board = GameObject.Find("player1-board").GetComponent<Board>();
        player2Board = GameObject.Find("player2-board").GetComponent<Board>();
        nameCarryOverScript = GameObject.Find("ValueHolder").GetComponent<EndGameValues>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player1Board.marked && player2Board.marked && !gameStarted)
        {
            gameStarted = true;
            wall.transform.position = movepoint.position;
        }

        if (gameFinished && player1Wins && !isRunning)
        {
            Debug.Log(DBManager.username + "WINS");
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                usernameWinner = DBManager.username;
                nameCarryOverScript.Endgame(usernameWinner, player1BoardSquareDestroyed);
                CallSaveData(true);
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(2);
            }
        }
        else if (gameFinished && player2Wins && !isRunning)
        {
            Debug.Log(DBManager.username + "WINS");
            if (!PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                usernameWinner = DBManager.username;
                nameCarryOverScript.Endgame(usernameWinner,player2BoardSquareDestroyed);
                CallSaveData(false);
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                nameCarryOverScript.Endgame(usernameWinner, player2BoardSquareDestroyed);
                UnityEngine.SceneManagement.SceneManager.LoadScene(2);
            }
        }
    }

    void CallSaveData(bool playe1win)
    {
        isRunning = true;
        DBManager.score++;
        if (playe1win)
        {
            StartCoroutine(SavePlayerData());
        }
        else
        {
            StartCoroutine(SavePlayerData());
        }
            

    }


    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DBManager.username);
        form.AddField("score", DBManager.score);

        WWW www = new WWW("https://studenthome.hku.nl/~matthew.vaneenenaam/Database/savedata.php", form);
        yield return www;
        if (www.text.Contains("0"))
        {
            Debug.Log("Game Saved to database");
            //good moment to maybe just call ui and turn of player control or just load a end scene
        }
        else
        {
            Debug.Log("Game Saved to database Failed #" + www.text);
        }

        
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
