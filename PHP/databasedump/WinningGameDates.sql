-- phpMyAdmin SQL Dump
-- version 4.9.4
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Gegenereerd op: 13 jan 2021 om 16:09
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
  `username` varchar(16) NOT NULL,
  `score` int(10) NOT NULL,
  `squareDestroyed` int(10) NOT NULL,
  `playdate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Gegevens worden geëxporteerd voor tabel `WinningGameDates`
--

INSERT INTO `WinningGameDates` (`id`, `username`, `score`, `squareDestroyed`, `playdate`) VALUES
(2, 'roxas435', 1, 2, '0000-00-00'),
(3, 'roxas736', 13, 0, '0000-00-00'),
(4, 'sora1234', 13, 0, '0000-00-00'),
(5, 'sora1234', 14, 2, '0000-00-00'),
(6, 'roxas736', 13, 2, '0000-00-00'),
(7, 'roxas736', 14, 2, '2021-01-13'),
(8, 'sora1234', 14, 2, '2021-01-13');

--
-- Indexen voor geëxporteerde tabellen
--

--
-- Indexen voor tabel `WinningGameDates`
--
ALTER TABLE `WinningGameDates`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT voor geëxporteerde tabellen
--

--
-- AUTO_INCREMENT voor een tabel `WinningGameDates`
--
ALTER TABLE `WinningGameDates`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
