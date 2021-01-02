<?php

	define("DB_SERVER", "localhost");
    define("DB_USER", "matthewvaneenena");
    define("DB_PASSWORD", "Gu2shaeSh8");
    define("DB_DATABASE", "matthewvaneenena");

    $con = mysqli_connect(DB_SERVER , DB_USER, DB_PASSWORD, DB_DATABASE);
    
    //check connection
    if (mysqli_connect_errno()){
        echo "1: Connection failed"; //failed
        exit();
    }

    $username = $_POST["username"];
    $newScore = $_POST["score"];


    $namecheckquery = "SELECT username FROM players WHERE username='" . $username . "';";

    $namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed"); //namecheck query failed

    if (mysqli_num_rows($namecheck) != 1){
        echo "5: Either no user with name or more than one"; //wrong matching username
        exit();
    }

    //update query
    $updatequery = "UPDATE players SET score = " . $newScore . " WHERE username = '" . $username . "';";
    mysqli_query($con, $updatequery) or die("7: Save query failed");// update query failed
    
    echo "0";

?>