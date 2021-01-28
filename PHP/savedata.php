<?php

    //read config
    require_once('config.php');
    session_start();
    
    //check connection
    if (mysqli_connect_errno()){
        echo "1: Connection failed"; //failed
        exit();
    }

    if($_POST["id"] == $_SESSION["id"])
    {
        $usernameid = $_SESSION["id"];
        $newScore = $_POST["score"];


        $namecheckquery = "SELECT username FROM players WHERE id='" . $usernameid . "';";

        $namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed"); //namecheck query failed

        if (mysqli_num_rows($namecheck) != 1){
            echo "5: Either no user with name or more than one"; //wrong matching username
            exit();
        }

        //update query
        $updatequery = "UPDATE players SET score = " . $newScore . " WHERE id = '" . $usernameid . "';";
        mysqli_query($con, $updatequery) or die("7: Save query failed");// update query failed
        
        echo "0";
    }

?>