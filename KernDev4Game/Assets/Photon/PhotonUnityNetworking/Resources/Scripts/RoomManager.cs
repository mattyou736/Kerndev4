using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;

    //[SerializeField]
    //int numberPlayers;

    //[SerializeField]
    //Transform spawnpoint1, spawnpoint2;

    //stan singlton pattern
    private void Awake()
    {//check if it exists 
        if (Instance)
        {//only one plz
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if(scene.buildIndex == 1)//in the scene
        {
            //spawnpoint1 = GameObject.Find("spawnpoint1").transform;
            //spawnpoint2 = GameObject.Find("spawnpoint2").transform;

            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);
        }
    }
}
