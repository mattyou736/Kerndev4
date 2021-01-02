using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameValues : MonoBehaviour
{

    [SerializeField]
    public string username = null;
    [SerializeField]
    string password;
    [SerializeField]
    public int point;

    static bool created = false;

    private void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Endgame(string _username)
    {
        username = _username;
    }
}
