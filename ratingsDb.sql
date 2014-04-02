-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               5.6.16-log - MySQL Community Server (GPL)
-- Server OS:                    Win64
-- HeidiSQL Version:             8.3.0.4694
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Dumping structure for table useritemratings.items
CREATE TABLE IF NOT EXISTS `items` (
  `itemId` int(11) NOT NULL,
  PRIMARY KEY (`itemId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table useritemratings.ratings
CREATE TABLE IF NOT EXISTS `ratings` (
  `userId` int(11) NOT NULL,
  `itemId` int(11) NOT NULL,
  `rating` int(11) NOT NULL,
  PRIMARY KEY (`userId`,`itemId`),
  KEY `RATINGS_FK2` (`userId`),
  KEY `RATINGS_FK1` (`itemId`),
  CONSTRAINT `RATINGS_FK1` FOREIGN KEY (`itemId`) REFERENCES `items` (`itemId`),
  CONSTRAINT `RATINGS_FK2` FOREIGN KEY (`userId`) REFERENCES `users` (`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Data exporting was unselected.


-- Dumping structure for table useritemratings.users
CREATE TABLE IF NOT EXISTS `users` (
  `userId` int(11) NOT NULL,
  PRIMARY KEY (`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Data exporting was unselected.
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
