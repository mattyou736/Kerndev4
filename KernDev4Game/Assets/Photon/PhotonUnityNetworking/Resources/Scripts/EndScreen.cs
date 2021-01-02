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
        Application.Quit();
    }
}
