<?php

	require('config.php');

	$querry = "SELECT * FROM players ORDER BY score DESC";
	$alle_gegevens = mysqli_query($con ,$querry);

	$querry2 = "SELECT * FROM players INNER JOIN WinningGameDates ON players.id = WinningGameDates.id  ORDER BY playdate DESC";
	$alle_gegevens2 = mysqli_query($con ,$querry2);
?>
	<html>

	<head>

	<title>
		Ranking list Kerndev4 Online game wins
	</title>

	</head>

	<body>
		<p>Ranking list Kerndev4 Online game wins</p>

		<?php
			echo "<table border = true>";
			echo "<tr>";
			echo "<td>Username</td>";
			echo "<td>Wins</td>";
			echo "</tr>";

			while ($rij = mysqli_fetch_array($alle_gegevens))
			{
				echo "<tr>";
				echo "<td>" . $rij['username'] . "</td>";
				echo "<td>" . $rij['score'] . "</td>";
				echo "</tr>";
			}

			echo "</table>";
			mysqli_free_result($alle_gegevens);

		?>

		<p>Games that people have played</p>

		<?php
			echo "<table border = true>";
			echo "<tr>";
			echo "<td>Username</td>";
			echo "<td>Total Score</td>";
			echo "<td>Amount of Wins racked up at that moment of the game</td>";
			echo "<td>Squares destroyed in that game</td>";
			echo "<td>Date played</td>";
			echo "</tr>";

			while ($rij = mysqli_fetch_array($alle_gegevens2))
			{
				echo "<tr>";
				echo "<td>" . $rij['username'] . "</td>";
				echo "<td>" . $rij['score'] . "</td>";
				echo "<td>" . $rij['scoreAtPlayTime'] . "</td>";
				echo "<td>" . $rij['squareDestroyed'] . "</td>";
				echo "<td>" . $rij['playdate'] . "</td>";
				echo "</tr>";
			}

			echo "</table>";
			mysqli_free_result($alle_gegevens2);

			

		?>
	</body>


	</html>