-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2026. Feb 11. 18:41
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `kockasfuzet`
--
CREATE DATABASE IF NOT EXISTS `kockasfuzet` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci;
USE `kockasfuzet`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szamla`
--

DROP TABLE IF EXISTS `szamla`;
CREATE TABLE IF NOT EXISTS `szamla` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `SzolgaltatasAzon` int(11) NOT NULL,
  `SzolgaltatasRovid` varchar(8) NOT NULL,
  `Tol` date NOT NULL,
  `Ig` date NOT NULL,
  `Osszeg` int(11) NOT NULL,
  `Hatarido` date NOT NULL,
  `Befizetve` date DEFAULT NULL,
  `Megjegyzes` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `SzolgaltatasAzon` (`SzolgaltatasAzon`),
  KEY `SzolgaltatasRovid` (`SzolgaltatasRovid`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `szamla`
--

INSERT INTO `szamla` (`Id`, `SzolgaltatasAzon`, `SzolgaltatasRovid`, `Tol`, `Ig`, `Osszeg`, `Hatarido`, `Befizetve`, `Megjegyzes`) VALUES
(1, 3, 'MVM Next', '2026-01-01', '2026-01-31', 30000, '2026-01-31', '2026-01-29', ''),
(2, 3, 'One', '2026-02-17', '2026-03-16', 43027, '2026-03-15', '2026-03-11', 'interneten'),
(4, 7, 'Yettel', '2026-02-01', '2026-02-28', 11111, '2026-02-28', '1494-11-06', ''),
(5, 8, 'MárkaABC', '2026-03-01', '2026-03-30', 78987, '2026-04-01', '2026-02-12', 'személyesen');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szolgaltatas`
--

DROP TABLE IF EXISTS `szolgaltatas`;
CREATE TABLE IF NOT EXISTS `szolgaltatas` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nev` varchar(32) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `szolgaltatas`
--

INSERT INTO `szolgaltatas` (`Id`, `Nev`) VALUES
(1, 'víz'),
(2, 'villany'),
(3, 'földgáz'),
(4, 'mobil'),
(5, 'vezetékes telefon'),
(6, 'internet'),
(7, 'kábel TV'),
(8, 'házhoz kaja');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szolgaltato`
--

DROP TABLE IF EXISTS `szolgaltato`;
CREATE TABLE IF NOT EXISTS `szolgaltato` (
  `RovidNev` varchar(8) NOT NULL,
  `Nev` varchar(256) NOT NULL,
  `Ugyfelszolgalat` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`RovidNev`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `szolgaltato`
--

INSERT INTO `szolgaltato` (`RovidNev`, `Nev`, `Ugyfelszolgalat`) VALUES
('ÉRV', 'ÉRV. Északmagyarországi Regionális Vízművek Zrt.', '3530 Miskolc, Corvin u. 2.'),
('MárkaABC', 'Márka ABC Coop SzuperPlusz+ Magyarország Zrt', 'Valahol Budapesten'),
('MiVíz', 'MIVÍZ Kft.', '3530 Miskolc, Corvin u. 2.'),
('MVM Next', 'MVM Next Energiakereskedelmi Zrt.', '3530 Miskolc, Arany János utca 6-8.'),
('One', 'One Magyarország Nyrt.', '3525 Miskolc, Szentpáli utca 2-6'),
('Telecom', 'Magyar Telekom Nyrt.', '3525 Miskolc, Szentpáli utca 2 - 6.'),
('Yettel', 'Yettel Magyarország Nyrt', '3525 Miskolc, Szentpáli utca 2-6');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
