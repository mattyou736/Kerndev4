-- phpMyAdmin SQL Dump
-- version 4.9.4
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Gegenereerd op: 28 jan 2021 om 11:30
-- Serverversie: 10.2.32-MariaDB
-- PHP-versie: 5.5.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `matthewvaneenena`
--

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `players`
--

CREATE TABLE `players` (
  `id` int(10) NOT NULL,
  `username` varchar(16) NOT NULL,
  `hash` varchar(100) NOT NULL,
  `salt` varchar(50) NOT NULL,
  `score` int(10) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Gegevens worden geëxporteerd voor tabel `players`
--

INSERT INTO `players` (`id`, `username`, `hash`, `salt`, `score`) VALUES
(2, 'testuserv1', '$5$rounds=5000$yozoraisnocttest$7sEnS0ogcOlH9.2iYN0O9n0jcZrkNDrQlv2WIN6Kil1', '$5$rounds=5000$yozoraisnocttestuserv1$', 1),
(3, 'tesruserv2', '$5$rounds=5000$yozoraisnocttesr$nWlwS6Ts.z1bntl7BkfcrUdohZexsMPPe9MdjqX2df/', '$5$rounds=5000$yozoraisnocttesruserv2$', 0),
(4, 'usernexttest', '$5$rounds=5000$yozoraisnoctuser$nQ2rL27gwBrYjhsQGdsF6hWUR00sam6VKIQT.dYPUq/', '$5$rounds=5000$yozoraisnoctusernexttest$', 0),
(5, 'testwithnewcode', '$5$rounds=5000$yozoraisnocttest$7sEnS0ogcOlH9.2iYN0O9n0jcZrkNDrQlv2WIN6Kil1', '$5$rounds=5000$yozoraisnocttestwithnewcode$', 0),
(8, 'useruser', '$5$rounds=5000$yozoraisnoctuser$/UG1fTtdoyaX4DnAcwipaHeR5MX/46l3TKGxzXITQA2', '$5$rounds=5000$yozoraisnoctuseruser$', 0),
(9, 'usernamezero', '$5$rounds=5000$yozoraisnoctuser$4gvAncrA45oZo7BmZ35LCk5mUUuQyeqc0rB7hqX46p3', '$5$rounds=5000$yozoraisnoctusernamezero$', 0),
(12, 'checktest', '$5$rounds=5000$yozoraisnoctchec$2vJQjlcMp95o/RlxSpSyrcZ8uIHc0JbhYT6zpOeqfeB', '$5$rounds=5000$yozoraisnoctchecktest$', 0),
(13, 'checktextv2', '$5$rounds=5000$yozoraisnoctchec$IfJIV8XmQcZP9.vosbwUVAc47t6RBjuw4p3Kystm4t3', '$5$rounds=5000$yozoraisnoctchecktextv2$', 0),
(14, 'testuseridotknow', '$5$rounds=5000$yozoraisnocttest$bE6yZx1sQpolBjSF8rYq/nbnIR9JQ9y6A92u4RDeO/A', '$5$rounds=5000$yozoraisnocttestuseridotknow$', 0),
(15, 'ifitcontains', '$5$rounds=5000$yozoraisnoctifit$kQXIe2yBbcOfCyyLh7fq/QCyt6u5T27vS1iPdfRcWX7', '$5$rounds=5000$yozoraisnoctifitcontains$', 0),
(16, 'roxas736', '$5$rounds=5000$yozoraisnoctroxa$SRr.AP2Jimv/pIa95Q5w32fMAemOwhZWPwYYrTEkPPA', '$5$rounds=5000$yozoraisnoctroxas736$', 16),
(17, 'yozora736', '$5$rounds=5000$yozoraisnoctyozo$fpnCtg9MfohdLsGtpNJ66VuuTPROUQktwJKcqmAs26B', '$5$rounds=5000$yozoraisnoctyozora736$', 0),
(18, 'sora1234', '$5$rounds=5000$yozoraisnoctsora$xhs1aK.fp/Nz02/E.6pJ75DDifMsYbl9oCaFoDAjz5C', '$5$rounds=5000$yozoraisnoctsora1234$', 19),
(19, 'shane123123', '$5$rounds=5000$yozoraisnoctshan$J4cfzk9MrVUPHP69G9xh3yo9.Dlss1zfIomfxCwTFDC', '$5$rounds=5000$yozoraisnoctshane123123$', 0),
(20, 'matthew736', '$5$rounds=5000$yozoraisnoctmatt$3I69OntjFlEsbcR61MJZDgsxwo1stDZ7cs0Hur7FAJ1', '$5$rounds=5000$yozoraisnoctmatthew736$', 0);

--
-- Indexen voor geëxporteerde tabellen
--

--
-- Indexen voor tabel `players`
--
ALTER TABLE `players`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT voor geëxporteerde tabellen
--

--
-- AUTO_INCREMENT voor een tabel `players`
--
ALTER TABLE `players`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
