using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltRegister : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

/*WWWForm form = new WWWForm();
        form.AddField("username", userNameInput.text);
        form.AddField("password", passwordInput.text);
        using (UnityWebRequest www = UnityWebRequest.Post("https://studenthome.hku.nl/~matthew.vaneenenaam/Database/register.php", form))
        {
            yield return www.SendWebRequest();
            // isNetworkError always comes true, else is to check for logs
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);

                Debug.Log("network error");
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                Debug.Log("downloadHandlertext");
            }
            if (www.downloadHandler.text == "0")
            {
                Debug.Log("User created succesfully!");
                menManager.OpenMenu(mainMenu);
            }
        }*/
