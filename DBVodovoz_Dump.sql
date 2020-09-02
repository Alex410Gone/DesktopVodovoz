-- MySQL dump 10.13  Distrib 8.0.20, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: vodovoz
-- ------------------------------------------------------
-- Server version	5.5.23

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `division`
--

DROP TABLE IF EXISTS `division`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `division` (
  `iddivision` int(11) NOT NULL AUTO_INCREMENT,
  `namedivision` varchar(100) NOT NULL,
  `iduser` int(11) DEFAULT NULL,
  PRIMARY KEY (`iddivision`),
  KEY `division_ibfk_1` (`iduser`),
  CONSTRAINT `division_ibfk_1` FOREIGN KEY (`iduser`) REFERENCES `users` (`iduser`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `division`
--

LOCK TABLES `division` WRITE;
/*!40000 ALTER TABLE `division` DISABLE KEYS */;
INSERT INTO `division` VALUES (1,'Подмосковное',1),(2,'Красногвардейское',5),(3,'Юго-Восточное',5),(4,'Западно-Восточное',2),(5,'ОП Ленинград',8),(6,'ОП Жемчуг',4),(7,'Московское',5),(8,'Свердловское',1),(11,'Чкаловское',2),(13,'Южное',1),(14,'Петровское',6);
/*!40000 ALTER TABLE `division` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `idorders` int(11) NOT NULL AUTO_INCREMENT,
  `nameproduct` varchar(100) NOT NULL,
  `iduser` int(11) DEFAULT NULL,
  PRIMARY KEY (`idorders`),
  KEY `orders_ibfk_1` (`iduser`),
  CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`iduser`) REFERENCES `users` (`iduser`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (1,'Молоко',3),(2,'Батон',2),(3,'Молоко',4),(4,'Шоколад',3),(5,'Чай',5),(6,'Вода',3),(7,'Вино',4),(8,'Газировка',8),(9,'Крупа',9),(10,'Капуста',4),(11,'Наушники',6);
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `iduser` int(11) NOT NULL AUTO_INCREMENT,
  `firstname` varchar(100) NOT NULL,
  `secondname` varchar(100) NOT NULL,
  `datebirth` datetime NOT NULL,
  `iddivision` int(11) NOT NULL,
  `middlename` varchar(100) NOT NULL,
  `gender` enum('Мужской','Женский') NOT NULL,
  PRIMARY KEY (`iduser`),
  KEY `iddivision` (`iddivision`)
) ENGINE=InnoDB AUTO_INCREMENT=72 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Лидия','Краснова','1967-12-25 00:00:00',1,'Михайловна','Женский'),(2,'Дмитрий','Заякин','1974-04-12 00:00:00',1,'Александрович','Мужской'),(3,'Василий','Мартынов','1972-01-27 00:00:00',2,'Сергеевич','Мужской'),(4,'Мария','Кодякова','1973-05-22 00:00:00',2,'Васильевна','Женский'),(5,'Сергей','Черняков','1986-02-05 00:00:00',3,'Александрович','Мужской'),(6,'Петр','Петров','1963-12-23 00:00:00',14,'Петрович','Мужской'),(7,'Иван','Петров','1988-04-25 00:00:00',7,'Сергеевич','Мужской'),(8,'Игорь','Соколов','1993-12-23 00:00:00',3,'Михайлович','Мужской'),(9,'Ольга','Иванова','1943-12-24 00:00:00',3,'Михайловна','Женский'),(10,'Надежда','Позднякова','1992-09-23 00:00:00',2,'Владимировна','Женский');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-08-18 16:32:21
