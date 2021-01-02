using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    PhotonView pv;

    [SerializeField]
    Transform spawnpoint1;

    [SerializeField]
    Transform spawnpoint2;

    private void Awake()
    {
        pv = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnpoint1 = GameObject.Find("spawnpoint1").transform;
        spawnpoint2 = GameObject.Find("spawnpoint2").transform;
        if (pv.IsMine)
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                CreateController1();
            }
            else
            {
                CreateController2();
            }
            
        }
        
    }

    void CreateController1()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerContoller"), spawnpoint1.position, spawnpoint1.rotation);
    }

    void CreateController2()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerContoller"), spawnpoint2.position, spawnpoint2.rotation);
    }
}
