<?php

    //read config
    require_once('config.php');
    
    //check connection
    if (mysqli_connect_errno()){
        echo "1: Connection failed"; //failed
        exit();
    }

    $username = $_POST["username"];
    $newScore = $_POST["score"];
    $squareDestroyed = $_POST["squareDestroyed"];
    $timestamp = date("Y-m-d");

    //update query
    $insertuserquery = "INSERT INTO WinningGameDates (username, score, squareDestroyed, playdate) VALUES ('" . $username . "', '" . $newScore . "', '" . $squareDestroyed ."', '" . $timestamp ."');";
    mysqli_query($con, $insertuserquery) or die(mysqli_error($con));
    
    echo "0";

?>