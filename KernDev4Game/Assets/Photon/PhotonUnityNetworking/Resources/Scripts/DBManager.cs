using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager
{
    /// <summary>
    ///if user has logged in succesfully these will be filled 
    /// </summary>
    public static string username;
    public static int score;
    //if username is null nobody logged in
    public static bool LoggedIn { get { return username != null; } }

    public static void LogOut()
    {
        username = null;
    }
}
