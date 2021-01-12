<?php

	require('config.php');

	$querry = "SELECT * FROM players ORDER BY score DESC";
	$alle_gegevens = mysqli_query($con ,$querry);


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
	</body>


	</html>