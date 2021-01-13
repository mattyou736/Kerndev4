using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScreen : MonoBehaviour
{
    EndGameValues nameCarryOverScript;
    public TMP_Text wintext;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        nameCarryOverScript = GameObject.Find("ValueHolder").GetComponent<EndGameValues>();
        if (nameCarryOverScript.username != null)
        {
            wintext.text = nameCarryOverScript.username + " wins!";
        }
        else
        {
            wintext.text = "You lose";
        }
    }

    public void ExitGame()
    {
        StartCoroutine(SavePlayerData());
    }

    IEnumerator SavePlayerData()
    {
        WWWForm form2 = new WWWForm();
        form2.AddField("username", DBManager.username);
        form2.AddField("score", DBManager.score);
        form2.AddField("squareDestroyed", nameCarryOverScript.squaresDestroy);

        WWW www2 = new WWW("https://studenthome.hku.nl/~matthew.vaneenenaam/Database/saveWinDate.php", form2);
        yield return www2;
        if (www2.text.Contains("0"))
        {
            Debug.Log("Game Saved to database");
            //good moment to maybe just call ui and turn of player control or just load a end scene
            DBManager.LogOut();
            Application.Quit();
        }
        else
        {
            Debug.Log("Game Saved to database Failed #" + www2.text);
        }


        
    }
}
