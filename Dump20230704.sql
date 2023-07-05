-- MySQL dump 10.13  Distrib 8.0.21, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: tucarbure
-- ------------------------------------------------------
-- Server version	8.0.21

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
-- Table structure for table `carburants`
--

DROP TABLE IF EXISTS `carburants`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `carburants` (
  `id_carburant` int NOT NULL,
  `nom` varchar(45) DEFAULT NULL,
  `code_europeen` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_carburant`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `carburants`
--

LOCK TABLES `carburants` WRITE;
/*!40000 ALTER TABLE `carburants` DISABLE KEYS */;
INSERT INTO `carburants` VALUES (1,'Sans Plomb 98','E5'),(2,'Sans Plomb 95','E5'),(3,'Sans Plomb 95','E10'),(4,'Superéthanol','E85'),(5,'Gazole','B7'),(6,'GPL','GPL');
/*!40000 ALTER TABLE `carburants` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `disponibilites`
--

DROP TABLE IF EXISTS `disponibilites`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `disponibilites` (
  `carburants` int NOT NULL,
  `stations_services` int NOT NULL,
  `disponible` tinyint DEFAULT NULL,
  PRIMARY KEY (`carburants`,`stations_services`),
  KEY `carburants_idx` (`carburants`),
  KEY `stations-services_idx` (`stations_services`),
  CONSTRAINT `carburants` FOREIGN KEY (`carburants`) REFERENCES `carburants` (`id_carburant`),
  CONSTRAINT `stations-services` FOREIGN KEY (`stations_services`) REFERENCES `stations_services` (`id_stations_Service`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `disponibilites`
--

LOCK TABLES `disponibilites` WRITE;
/*!40000 ALTER TABLE `disponibilites` DISABLE KEYS */;
INSERT INTO `disponibilites` VALUES (1,1,1),(1,2,0),(1,3,1),(1,4,1),(1,5,1),(1,6,1),(2,1,1),(2,2,1),(2,3,1),(2,4,0),(2,6,1),(3,2,1),(3,3,1),(3,4,0),(3,5,1),(4,1,1),(4,2,1),(4,3,1),(4,6,1),(5,1,0),(5,4,1),(5,5,0),(5,6,1),(6,1,1),(6,2,1),(6,3,1),(6,4,1);
/*!40000 ALTER TABLE `disponibilites` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `releves`
--

DROP TABLE IF EXISTS `releves`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `releves` (
  `id_releve` int NOT NULL,
  `date_heure` datetime DEFAULT CURRENT_TIMESTAMP,
  `prix_carburant` float DEFAULT NULL,
  `fk_carburant` int DEFAULT NULL,
  `fk_station_service` int DEFAULT NULL,
  PRIMARY KEY (`id_releve`),
  KEY `fk-carburant_idx` (`fk_carburant`),
  KEY `fk-station-service_idx` (`fk_station_service`),
  CONSTRAINT `fk-carburant` FOREIGN KEY (`fk_carburant`) REFERENCES `carburants` (`id_carburant`),
  CONSTRAINT `fk-station-service` FOREIGN KEY (`fk_station_service`) REFERENCES `stations_services` (`id_stations_Service`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `releves`
--

LOCK TABLES `releves` WRITE;
/*!40000 ALTER TABLE `releves` DISABLE KEYS */;
INSERT INTO `releves` VALUES (1,'2023-07-03 11:28:23',1.7,1,1),(2,'2023-07-03 11:28:23',1.5,2,2),(3,'2023-07-03 11:28:23',1.75,3,4),(4,'2023-07-03 11:28:23',1.6,4,5),(5,'2023-07-03 11:28:23',1.62,5,6),(6,'2023-07-03 11:28:23',1.56,6,3),(7,'2023-07-04 16:19:40',1.68,1,2),(8,'2023-07-04 16:23:00',1.7,3,2),(9,'2023-07-04 16:23:00',1.16,4,2),(10,'2023-07-04 16:23:00',1.3,5,2),(11,'2023-07-04 16:28:20',1.1,6,2);
/*!40000 ALTER TABLE `releves` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stations_services`
--

DROP TABLE IF EXISTS `stations_services`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stations_services` (
  `id_stations_Service` int NOT NULL,
  `marque` varchar(45) DEFAULT NULL,
  `adressePostale` varchar(255) DEFAULT NULL,
  `longitude` float DEFAULT NULL,
  `latitude` float DEFAULT NULL,
  `ville` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_stations_Service`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stations_services`
--

LOCK TABLES `stations_services` WRITE;
/*!40000 ALTER TABLE `stations_services` DISABLE KEYS */;
INSERT INTO `stations_services` VALUES (1,'Shell',' Aire De La Baie De Somme, 80970 ',50.1673,1.75492,'Sailly-Flibeaucourt'),(2,'Leclerc',' Zone d activite du Mont des Bruyeres, 59230',50.4363,3.43981,'Saint-Amand-les-Eaux'),(3,'Auchan','122 Chemin des Bourgeois, 59300 ',50.3434,3.51672,'Valenciennes'),(4,'Access - TotalEnergies','27 Bd Saly, 59300',50.3534,3.51726,'Valenciennes'),(5,'ESSO EXPRESS','3 Bd Eisen, 59300 ',50.3636,3.52755,'Valenciennes'),(6,'BP','36 Avenu de Saint-Amand, 59300',50.3664,3.51047,'Valenciennes');
/*!40000 ALTER TABLE `stations_services` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-07-04 16:45:35
