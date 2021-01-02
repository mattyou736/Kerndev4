using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDemo : MonoBehaviour
{
    public TMP_Text playerDisplay;
    public TMP_Text scoreDisplay;
    MenuManager menuManager;
    // Start is called before the first frame update
    void Awake()
    {
        menuManager = GameObject.Find("Canvas").GetComponent<MenuManager>();
        if (DBManager.username == null)
        {
            menuManager.OpenMenu("title");
        }
        else
        {
            playerDisplay.text = "Player: " + DBManager.username;
            scoreDisplay.text = "score: " + DBManager.score;
        }
        
    }

    public void CallSaveData()
    {
        StartCoroutine(SavePlayerData());
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
            Debug.Log("Game Saved");
        }
        else
        {
            Debug.Log("Save Failed Error #" + www.text);
        }

        DBManager.LogOut();
        menuManager.OpenMenu("title");
    }

    public void IncreaseScore()
    {
        DBManager.score++;
        scoreDisplay.text = "score: " + DBManager.score;
    }
}
