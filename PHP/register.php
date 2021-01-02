
<?php
	
	define("DB_SERVER", "localhost");
    define("DB_USER", "matthewvaneenena");
    define("DB_PASSWORD", "Gu2shaeSh8");
    define("DB_DATABASE", "matthewvaneenena");

    $con = mysqli_connect(DB_SERVER , DB_USER, DB_PASSWORD, DB_DATABASE);

    //check that connect happend
    if (mysqli_connect_errno()){
        echo "Error 1 Connection failed"; 
        exit();
    }

    $username = $_POST["username"];
    $password = $_POST["password"];

    //see if name exists already
     $namecheckquery = "SELECT username FROM players WHERE username='". $username . "';";

     //does it work 
      $namecheck = mysqli_query($con, $namecheckquery) or die("Error 2 Name check query failed"); //error 2

      //is there another name thats the same
      if (mysqli_num_rows($namecheck) > 0){
        echo "Error 3 Name already exists"; //already exists
        exit();
    }

    //add a user to table in the database and incripting the pass
    $salt = "\$5\$rounds=5000\$" . "yozoraisnoct" . $username . "\$";
    $hash = crypt($password, $salt);
    $insertuserquery = "INSERT INTO players (username, hash, salt) VALUES ('" . $username . "', '" . $hash . "', '" . $salt . "');";
    mysqli_query($con, $insertuserquery) or die(mysqli_error($con));

    echo ("0");
?>