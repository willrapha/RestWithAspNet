-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           8.0.13 - MySQL Community Server - GPL
-- OS do Servidor:               Win64
-- HeidiSQL Versão:              9.5.0.5196
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Copiando estrutura do banco de dados para rest_udemy
CREATE DATABASE IF NOT EXISTS `rest_udemy` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;
USE `rest_udemy`;

-- Copiando estrutura para tabela rest_udemy.books
CREATE TABLE IF NOT EXISTS `books` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `Author` longtext,
  `LaunchDate` datetime(6) NOT NULL,
  `Price` decimal(65,2) NOT NULL,
  `Title` longtext,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela rest_udemy.books: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `books` DISABLE KEYS */;
INSERT INTO `books` (`id`, `Author`, `LaunchDate`, `Price`, `Title`) VALUES
	(16, 'Michael C. Feathers', '2017-11-29 13:50:05.878000', 49.00, 'Working effectively with legacy code'),
	(17, 'Michael C. Feathers', '2017-11-29 13:50:05.878000', 49.00, 'Working effectively with legacy code'),
	(18, 'Michael C. Feathers', '2017-11-29 13:50:05.878000', 49.00, 'Working effectively with legacy code');
/*!40000 ALTER TABLE `books` ENABLE KEYS */;

-- Copiando estrutura para tabela rest_udemy.changelog
CREATE TABLE IF NOT EXISTS `changelog` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `type` tinyint(4) DEFAULT NULL,
  `version` varchar(50) DEFAULT NULL,
  `description` varchar(200) NOT NULL,
  `name` varchar(300) NOT NULL,
  `checksum` varchar(32) DEFAULT NULL,
  `installed_by` varchar(100) NOT NULL,
  `installed_on` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `success` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela rest_udemy.changelog: ~15 rows (aproximadamente)
/*!40000 ALTER TABLE `changelog` DISABLE KEYS */;
INSERT INTO `changelog` (`id`, `type`, `version`, `description`, `name`, `checksum`, `installed_by`, `installed_on`, `success`) VALUES
	(1, 2, '0', 'Empty schema found: rest_udemy.', 'rest_udemy', '', 'root', '2018-11-15 16:26:52', 1),
	(2, 0, '1.0.1', 'Create Table Persons', 'V1_0_1__Create_Table_Persons.sql', '5C57601C086E1B99BBB04D07959D0F8D', 'root', '2018-11-15 16:26:52', 1),
	(3, 0, '1.0.2', 'Alter Table Persons', 'V1_0_2__Alter_Table_Persons.sql', '7D6F470E7C4AF6D5B72404F45156FD1E', 'root', '2018-11-15 16:26:53', 1),
	(4, 0, '1.0.3', 'Create table books', 'V1_0_3__Create_table_books.sql', '3CAEBF868C3B3D5FA5F0C952EA0BDA08', 'root', '2018-11-15 16:26:53', 0),
	(5, 0, '1.0.3', 'Create table books', 'V1_0_3__Create_table_books.sql', '3CAEBF868C3B3D5FA5F0C952EA0BDA08', 'root', '2018-11-15 16:27:10', 0),
	(6, 0, '1.0.3', 'Create table books', 'V1_0_3__Create_table_books.sql', '3CAEBF868C3B3D5FA5F0C952EA0BDA08', 'root', '2018-11-15 16:27:41', 0),
	(7, 0, '1.0.3', 'Create table books', 'V1_0_3__Create_table_books.sql', '3CAEBF868C3B3D5FA5F0C952EA0BDA08', 'root', '2018-11-15 16:27:53', 0),
	(8, 0, '1.0.3', 'Create table books', 'V1_0_3__Create_table_books.sql', '3CAEBF868C3B3D5FA5F0C952EA0BDA08', 'root', '2018-11-15 16:28:12', 0),
	(9, 0, '1.0.3', 'Create table books', 'V1_0_3__Create_table_books.sql', '6A28FD6969604D6706D878FDA5BC5655', 'root', '2018-11-15 16:31:48', 1),
	(10, 0, '1.0.4', 'Insert data in books', 'V1_0_4__Insert_data_in_books.sql', 'DF897A99AB6E370E70436E0440E39370', 'root', '2018-11-15 16:31:48', 1),
	(11, 0, '1.0.5', 'Insert data in persons', 'V1_0_5__Insert_data_in_persons.sql', 'DB48E62EA9C3C1BD68458FF4884B381B', 'root', '2018-11-15 16:31:48', 1),
	(12, 0, '1.0.6', 'Drop table books', 'V1_0_6__Drop_table_books.sql', '996116D4AC3B9566301DE7B869018E5E', 'root', '2018-11-15 16:31:48', 1),
	(13, 0, '1.0.7', 'Recreate table books', 'V1_0_7__Recreate_table_books.sql', 'CB5FB5A85E1A215AF7660C79FA4D9348', 'root', '2018-11-15 16:31:49', 1),
	(14, 0, '1.0.8', 'Reinsert data in books', 'V1_0_8__Reinsert_data_in_books.sql', '373CE0C6F178AAD499A836E05474A56D', 'root', '2018-11-15 16:31:49', 0),
	(15, 0, '1.0.8', 'Reinsert data in books', 'V1_0_8__Reinsert_data_in_books.sql', '65DF348BF7BABCA6BC361F5D1CFF485A', 'root', '2018-11-15 16:32:13', 1),
	(16, 0, '1.0.9', 'Create table users', 'V1_0_9__Create_table_users.sql', '90F1442888FFB519A8723FF76F2D28E2', 'root', '2018-11-17 20:18:12', 1),
	(17, 0, '1.0.10', 'Insert data in users', 'V1_0_10__Insert_data_in_users.sql', 'F797DBD546543CC7570998EAFDAC4225', 'root', '2018-11-17 20:18:12', 1);
/*!40000 ALTER TABLE `changelog` ENABLE KEYS */;

-- Copiando estrutura para tabela rest_udemy.persons
CREATE TABLE IF NOT EXISTS `persons` (
  `ID` int(10) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(50) DEFAULT NULL,
  `LastName` varchar(50) DEFAULT NULL,
  `Address` varchar(50) DEFAULT NULL,
  `Gender` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=1015 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela rest_udemy.persons: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `persons` DISABLE KEYS */;
INSERT INTO `persons` (`ID`, `FirstName`, `LastName`, `Address`, `Gender`) VALUES
	(976, 'Orv', 'Sweedy', '6603 Pankratz Parkway', 'Male'),
	(977, 'Averil', 'Stanistreet', '74903 Loomis Trail', 'Female'),
	(978, 'Rhodia', 'Kerswell', '78 Florence Point', 'Female'),
	(979, 'Hermann', 'Golby', '06087 Anthes Lane', 'Male'),
	(980, 'Jerry', 'Inglis', '2 Loomis Terrace', 'Female'),
	(981, 'Quentin', 'Lepper', '234 Artisan Court', 'Male'),
	(982, 'Tildi', 'Danilovitch', '359 Crescent Oaks Road', 'Female'),
	(983, 'Emelyne', 'Libby', '8181 Arkansas Street', 'Female'),
	(984, 'Chrystel', 'Castelin', '1 Commercial Parkway', 'Female'),
	(985, 'Ansel', 'Baude', '60016 Kensington Crossing', 'Male'),
	(986, 'Joletta', 'Attwill', '47914 Coleman Street', 'Female'),
	(987, 'Otis', 'Britcher', '5005 Judy Road', 'Male'),
	(988, 'Dru', 'Leuchars', '7998 Dahle Street', 'Male'),
	(989, 'Grayce', 'Dufaur', '015 Longview Park', 'Female'),
	(990, 'Teodora', 'Timoney', '5558 Ohio Avenue', 'Female'),
	(991, 'Maire', 'Walker', '2737 Cottonwood Crossing', 'Female'),
	(992, 'Lucina', 'Serrell', '9 Service Crossing', 'Female'),
	(993, 'Marijn', 'Weaving', '9282 Hudson Center', 'Male'),
	(994, 'Teodorico', 'Lortz', '7486 Fair Oaks Park', 'Male'),
	(995, 'Nevin', 'Denerley', '49168 Forest Dale Terrace', 'Male'),
	(996, 'Carlene', 'Myderscough', '88 Nelson Court', 'Female'),
	(997, 'Rae', 'Dennitts', '87 Cherokee Drive', 'Female'),
	(998, 'Luigi', 'Wilsher', '40 Grayhawk Junction', 'Male'),
	(999, 'Pepe', 'Spanton', '92 Roxbury Hill', 'Male'),
	(1000, 'Clemmie', 'Ethington', '1 Grim Avenue', 'Male'),
	(1001, 'Irwinn', 'Josse', '359 Chive Crossing', 'Male'),
	(1002, 'Joseph', 'Jukubczak', '000 Forest Run Center', 'Male'),
	(1003, 'Jeri', 'Boyda', '56 Independence Street', 'Female'),
	(1004, 'Alexis', 'Colledge', '52 Village Street', 'Male'),
	(1005, 'Carce', 'Demko', '9 Prentice Hill', 'Male'),
	(1006, 'Mackenzie', 'Hatje', '6 American Crossing', 'Male'),
	(1007, 'Roderick', 'Seamark', '6 Hoard Crossing', 'Male'),
	(1008, 'Madelin', 'Durant', '574 Ramsey Way', 'Female'),
	(1009, 'Lemmy', 'Mendenhall', '7 Moose Crossing', 'Male'),
	(1010, 'Carma', 'Doyley', '35192 American Ash Parkway', 'Female'),
	(1011, 'Georgianna', 'Lattos', '526 Green Ridge Avenue', 'Female'),
	(1012, 'Mersey', 'Fishpond', '8 Bashford Trail', 'Female'),
	(1013, 'Oneida', 'Dundredge', '51 Cardinal Way', 'Female'),
	(1014, 'Dacia', 'Nower', '4460 Butterfield Plaza', 'Female');
/*!40000 ALTER TABLE `persons` ENABLE KEYS */;

-- Copiando estrutura para tabela rest_udemy.users
CREATE TABLE IF NOT EXISTS `users` (
  `ID` int(10) NOT NULL AUTO_INCREMENT,
  `Login` varchar(50) NOT NULL,
  `AccessKey` varchar(50) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Login` (`Login`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela rest_udemy.users: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` (`ID`, `Login`, `AccessKey`) VALUES
	(1, 'will', 'admin123'),
	(2, 'rapha', 'user123');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
