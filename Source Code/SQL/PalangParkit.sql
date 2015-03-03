-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               5.5.32 - MySQL Community Server (GPL)
-- Server OS:                    Win32
-- HeidiSQL Version:             8.1.0.4545
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Dumping database structure for palangparkir
DROP DATABASE IF EXISTS `palangparkir`;
CREATE DATABASE IF NOT EXISTS `palangparkir` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `palangparkir`;


-- Dumping structure for table palangparkir.jenis_kendaraan
DROP TABLE IF EXISTS `jenis_kendaraan`;
CREATE TABLE IF NOT EXISTS `jenis_kendaraan` (
  `id` int(50) NOT NULL AUTO_INCREMENT,
  `jenis_kendaraan` varchar(50) DEFAULT NULL,
  `perjam` int(11) DEFAULT NULL,
  `maksimal` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

-- Dumping data for table palangparkir.jenis_kendaraan: ~7 rows (approximately)
DELETE FROM `jenis_kendaraan`;
/*!40000 ALTER TABLE `jenis_kendaraan` DISABLE KEYS */;
INSERT INTO `jenis_kendaraan` (`id`, `jenis_kendaraan`, `perjam`, `maksimal`) VALUES
	(1, 'Mobil', 21, 21),
	(2, 'Motor', 21, 21),
	(3, 'Truck', 21, 21),
	(4, 'Ambulance', 21, 21),
	(5, '11', 21, 21),
	(6, 'Macam', 21, 21),
	(9, 'Mobil Truk', 1000, 10);
/*!40000 ALTER TABLE `jenis_kendaraan` ENABLE KEYS */;


-- Dumping structure for table palangparkir.kendaraan
DROP TABLE IF EXISTS `kendaraan`;
CREATE TABLE IF NOT EXISTS `kendaraan` (
  `id` int(50) NOT NULL AUTO_INCREMENT,
  `barcode` varchar(50) DEFAULT NULL,
  `jenis_kendaraan` varchar(50) DEFAULT NULL,
  `waktu_masuk` datetime DEFAULT NULL,
  `waktu_keluar` datetime DEFAULT NULL,
  `durasi` int(11) DEFAULT NULL,
  `pembayaran` int(11) DEFAULT NULL,
  `uang_diterima` int(11) DEFAULT NULL,
  `kembalian` int(11) DEFAULT NULL,
  `pintu` varchar(50) DEFAULT NULL,
  `image_path` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- Dumping data for table palangparkir.kendaraan: ~5 rows (approximately)
DELETE FROM `kendaraan`;
/*!40000 ALTER TABLE `kendaraan` DISABLE KEYS */;
INSERT INTO `kendaraan` (`id`, `barcode`, `jenis_kendaraan`, `waktu_masuk`, `waktu_keluar`, `durasi`, `pembayaran`, `uang_diterima`, `kembalian`, `pintu`, `image_path`) VALUES
	(1, '21321321', 'mobil', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	(2, '201533143017', NULL, '2015-03-03 14:30:23', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	(3, '201533143110', NULL, '2015-03-03 14:31:12', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	(4, '201533145352', NULL, '2015-03-03 14:53:53', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	(5, '201533145536', NULL, '2015-03-03 14:55:37', NULL, NULL, NULL, NULL, NULL, NULL, NULL);
/*!40000 ALTER TABLE `kendaraan` ENABLE KEYS */;


-- Dumping structure for table palangparkir.user_info
DROP TABLE IF EXISTS `user_info`;
CREATE TABLE IF NOT EXISTS `user_info` (
  `id` int(50) NOT NULL AUTO_INCREMENT,
  `nama` varchar(50) DEFAULT NULL,
  `level` varchar(50) DEFAULT NULL,
  `nik` varchar(50) DEFAULT NULL,
  `pass` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- Dumping data for table palangparkir.user_info: ~5 rows (approximately)
DELETE FROM `user_info`;
/*!40000 ALTER TABLE `user_info` DISABLE KEYS */;
INSERT INTO `user_info` (`id`, `nama`, `level`, `nik`, `pass`) VALUES
	(1, 'budi', '12', '12', '12'),
	(2, 'Sugiarto', '', '123213', '12345678'),
	(3, '21', 'Admin', '21', '12121'),
	(4, '321321', 'SuperVisor', '321321', '121212121'),
	(5, '321', 'SuperVisor', '321', '321');
/*!40000 ALTER TABLE `user_info` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
