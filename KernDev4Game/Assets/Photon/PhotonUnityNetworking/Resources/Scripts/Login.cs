using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField userNameInput;
    public InputField passwordInput;
    public Text errorText;

    public string username;
    public string password;

    public Button loginButton, registerButton;

    public Menu mainMenu;
    public MenuManager menManager;
    public UserHolder userHolder;

    public void UserName()
    {
        username = userNameInput.text.ToString();
    }

    public void Password()
    {
        password = passwordInput.text.ToString();
    }

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {
        //information to write to database
        WWWForm form = new WWWForm();
        form.AddField("username", userNameInput.text);
        form.AddField("password", passwordInput.text);

        //path to the php code to execute
        WWW www = new WWW("https://studenthome.hku.nl/~matthew.vaneenenaam/Database/login.php", form);

        yield return www;

        if (www.text.Contains("0"))
        {
            DBManager.username = userNameInput.text;
            userHolder.usernamePlayer = userNameInput.text;
            DBManager.score = int.Parse(www.text.Split('\t')[1]);
            DBManager.id = int.Parse(www.text.Split('\t')[2]);
            Debug.Log("ID = " + DBManager.id);
            menManager.OpenMenu(mainMenu);
        }
        else
        {
            Debug.Log("User login failed errorCode #" + www.text);
        }

    }


    IEnumerator Register()
    {
        
        //information to write to database
        WWWForm form = new WWWForm();
        form.AddField("username", userNameInput.text);
        form.AddField("password", passwordInput.text);

        //path to the php code to execute
        WWW www = new WWW("https://studenthome.hku.nl/~matthew.vaneenenaam/Database/register.php", form);
        
        yield return www;
        
        Debug.Log(www.text);

        if (www.text.Contains("0"))
        {//if we register
            Debug.Log("user created");
            StartCoroutine(LoginPlayer());
            //menManager.OpenMenu(mainMenu);
        }
        else
        {//if we fuck up
            Debug.Log("Code #" + www.text);
            menManager.OpenMenu(mainMenu);
        }
    }

    public void VerifyInputs()
    {
        //check if the fields have a certain length before being allowed to click
        registerButton.interactable = (userNameInput.text.Length >= 8 && passwordInput.text.Length >= 8);
        loginButton.interactable = (userNameInput.text.Length >= 8 && passwordInput.text.Length >= 8);
    }
}
