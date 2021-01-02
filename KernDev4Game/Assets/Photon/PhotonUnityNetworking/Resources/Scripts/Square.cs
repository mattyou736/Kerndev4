using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Square : MonoBehaviour
{
    Board board;
    bool marked;
    public string boardName;
    public GameObject marker;

    Gamemanager gman;

    // Start is called before the first frame update
    void Start()
    {
        board = GameObject.Find(boardName).GetComponent<Board>();
        gman = GameObject.Find("Gamemanager").GetComponent<Gamemanager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //try this but from the bullet script instead
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet" && board.marked == true && gman.gameStarted)
        {
            //PhotonNetwork.Destroy(other.gameObject);
            PhotonView photonView = PhotonView.Get(this);
            photonView.RPC("DestroySquare", RpcTarget.AllBuffered);
        }
        else if(other.tag == "Bullet" && !board.marked)
        {
            //PhotonNetwork.Destroy(other.gameObject);
            PhotonView photonView = PhotonView.Get(this);
            photonView.RPC("MarkSquare", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    public void MarkSquare()
    {
        if(board.marked == false)
        {
            marked = true;
            board.marked = true;
            marker.SetActive(true);
            gman.redPlayerTurn = !gman.redPlayerTurn;
        }
        
    }

    [PunRPC]
    public void DestroySquare()
    {
        Destroy(gameObject);
        gman.redPlayerTurn = !gman.redPlayerTurn;
        if (marked && boardName == "player1-board")
        {
            gman.gameFinished = true;
            gman.player1Wins = true;
        }
        else if(marked && boardName == "player2-board")
        {
            gman.gameFinished = true;
            gman.player2Wins = true;
        }
    }
}
