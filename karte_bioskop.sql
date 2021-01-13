-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 11, 2021 at 06:16 AM
-- Server version: 10.4.17-MariaDB
-- PHP Version: 8.0.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `karte_bioskop`
--

-- --------------------------------------------------------

--
-- Table structure for table `bioskopi`
--

CREATE TABLE `bioskopi` (
  `bioskopid` int(11) NOT NULL,
  `nazivBioskopa` varchar(40) DEFAULT NULL,
  `adresa` varchar(100) DEFAULT NULL,
  `telefon` varchar(20) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `kapacitet` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `bioskopi`
--

INSERT INTO `bioskopi` (`bioskopid`, `nazivBioskopa`, `adresa`, `telefon`, `email`, `kapacitet`) VALUES
(1, 'Kozara', 'Beograd', '0637000484', 'kontakt@kozara.com', 2500);

-- --------------------------------------------------------

--
-- Table structure for table `dogadjaji`
--

CREATE TABLE `dogadjaji` (
  `dogadjajiid` int(11) NOT NULL,
  `nazivFilma` varchar(100) DEFAULT NULL,
  `idbioskop` int(11) DEFAULT NULL,
  `datum` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `dogadjaji`
--

INSERT INTO `dogadjaji` (`dogadjajiid`, `nazivFilma`, `idbioskop`, `datum`) VALUES
(1, 'Revolver', 1, '2021-01-12 22:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `korisnici`
--

CREATE TABLE `korisnici` (
  `korisnikid` int(11) NOT NULL,
  `ime` varchar(20) DEFAULT NULL,
  `prezime` varchar(20) DEFAULT NULL,
  `korisnicko` varchar(20) DEFAULT NULL,
  `lozinka` varchar(20) DEFAULT NULL,
  `idstatus` int(11) NOT NULL DEFAULT 1,
  `datumRegistracije` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `korisnici`
--

INSERT INTO `korisnici` (`korisnikid`, `ime`, `prezime`, `korisnicko`, `lozinka`, `idstatus`, `datumRegistracije`) VALUES
(2, 'Marko', 'Beloica', 'marbel', '123', 2, '2021-01-10 10:41:52'),
(3, 'Pera', 'Petrovic', 'pera', '111', 1, '2021-01-10 11:08:32');

-- --------------------------------------------------------

--
-- Table structure for table `rezervacije`
--

CREATE TABLE `rezervacije` (
  `rezervacijaid` int(11) NOT NULL,
  `iddogadjaj` int(11) DEFAULT NULL,
  `idkorisnik` int(11) DEFAULT NULL,
  `rezervisaoKarata` int(11) DEFAULT NULL,
  `datumRezervacije` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `rezervacije`
--

INSERT INTO `rezervacije` (`rezervacijaid`, `iddogadjaj`, `idkorisnik`, `rezervisaoKarata`, `datumRezervacije`) VALUES
(1, 1, 2, 5, '2021-01-10 21:41:37');

-- --------------------------------------------------------

--
-- Table structure for table `status_korisnika`
--

CREATE TABLE `status_korisnika` (
  `statusid` int(11) NOT NULL,
  `statusKorisnika` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `status_korisnika`
--

INSERT INTO `status_korisnika` (`statusid`, `statusKorisnika`) VALUES
(1, 'Korisnik'),
(2, 'Administrator');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bioskopi`
--
ALTER TABLE `bioskopi`
  ADD PRIMARY KEY (`bioskopid`);

--
-- Indexes for table `dogadjaji`
--
ALTER TABLE `dogadjaji`
  ADD PRIMARY KEY (`dogadjajiid`);

--
-- Indexes for table `korisnici`
--
ALTER TABLE `korisnici`
  ADD PRIMARY KEY (`korisnikid`);

--
-- Indexes for table `rezervacije`
--
ALTER TABLE `rezervacije`
  ADD PRIMARY KEY (`rezervacijaid`);

--
-- Indexes for table `status_korisnika`
--
ALTER TABLE `status_korisnika`
  ADD PRIMARY KEY (`statusid`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bioskopi`
--
ALTER TABLE `bioskopi`
  MODIFY `bioskopid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `dogadjaji`
--
ALTER TABLE `dogadjaji`
  MODIFY `dogadjajiid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `korisnici`
--
ALTER TABLE `korisnici`
  MODIFY `korisnikid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `rezervacije`
--
ALTER TABLE `rezervacije`
  MODIFY `rezervacijaid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
