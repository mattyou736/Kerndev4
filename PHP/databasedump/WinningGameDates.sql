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
-- Tabelstructuur voor tabel `WinningGameDates`
--

CREATE TABLE `WinningGameDates` (
  `id` int(11) NOT NULL,
  `scoreAtPlayTime` int(10) NOT NULL,
  `squareDestroyed` int(10) NOT NULL,
  `playdate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Gegevens worden geëxporteerd voor tabel `WinningGameDates`
--

INSERT INTO `WinningGameDates` (`id`, `scoreAtPlayTime`, `squareDestroyed`, `playdate`) VALUES
(18, 18, 1, '2021-01-28'),
(16, 16, 0, '2021-01-28'),
(18, 19, 1, '2021-01-28'),
(16, 16, 1, '2021-01-28'),
(2, 1, 1, '2021-01-28'),
(20, 0, 1, '2021-01-28');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
