
<?php
	
    
	//read config
    require_once('config.php');

    session_start();

    //check that connect happend
    if (mysqli_connect_errno()){
        echo "Error 1 Connection failed"; 
        exit();
    }

    $username = $_POST["username"];
    $password = $_POST["password"];

    //see if name exists already
     $namecheckquery = "SELECT id, username, salt, hash, score FROM players WHERE username='". $username . "';";

     $idCheckQuery = "SELECT id, FROM players WHERE username='". $username . "';";

     //does it work 
      $namecheck = mysqli_query($con, $namecheckquery) or die("Error 2 Name check query failed"); //error 2

      //is there another name thats the same
      if (mysqli_num_rows($namecheck) != 1){
        echo "5: Either no user with name or more than one"; //wrong matching username does not = 1
        exit();
    }

    //get the login info
    $existinginfo = mysqli_fetch_assoc($namecheck);
    $salt = $existinginfo["salt"];
    $hash = $existinginfo["hash"];

    $loginhash = crypt($password, $salt);
    if ($hash != $loginhash){//error wrong passsword does not match hash
        echo "6: Wrong password"; 
        exit();
    }

    $_SESSION['username'] = $username;
    $_SESSION['id'] = $existinginfo["id"];
    echo "0\t" . $existinginfo["score"]."\t". $_SESSION['id'];

    
?>