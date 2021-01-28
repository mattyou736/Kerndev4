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
        $id = $_SESSION["id"];
        $newScore = $_POST["score"];
        $squareDestroyed = $_POST["squareDestroyed"];
        $timestamp = date("Y-m-d");

         //update query
        $insertuserquery = "INSERT INTO WinningGameDates (id, scoreAtPlayTime, squareDestroyed, playdate) VALUES ('" . $id . "', '" . $newScore . "', '" . $squareDestroyed ."', '" . $timestamp ."');";
        mysqli_query($con, $insertuserquery) or die(mysqli_error($con));
    }
    
   
    
    echo "0";

?>