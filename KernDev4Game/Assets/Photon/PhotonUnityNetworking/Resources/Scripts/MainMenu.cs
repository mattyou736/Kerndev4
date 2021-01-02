using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_Text playerDisplay;
    public Button demo, findroom, createroom;

    public void OnEnable()
    {
        if (DBManager.LoggedIn)
        {
            playerDisplay.text = "Player: " + DBManager.username;
            findroom.interactable = true;
            createroom.interactable = true;
        }
        else
        {
            demo.interactable = false;
            findroom.interactable = false;
            createroom.interactable = false;
        }
    }
}
