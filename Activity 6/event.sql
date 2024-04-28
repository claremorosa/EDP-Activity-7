CREATE DATABASE  IF NOT EXISTS `event` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `event`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: event
-- ------------------------------------------------------
-- Server version	8.0.36

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
-- Table structure for table `activities`
--

DROP TABLE IF EXISTS `activities`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `activities` (
  `activity_id` int NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `description` text,
  `cost` int DEFAULT NULL,
  PRIMARY KEY (`activity_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `activities`
--

LOCK TABLES `activities` WRITE;
/*!40000 ALTER TABLE `activities` DISABLE KEYS */;
INSERT INTO `activities` VALUES (1,'Museum Visit','Explore local museums',250),(2,'Hiking','Enjoy a scenic hike',500),(3,'Sightseeing Tour','Explore local attractions and landmarks',100),(4,'Cultural Festival','Attend a cultural festival or event',1000),(5,'Shopping','Enjoy shopping for local crafts and souvenirs',2500),(6,'Beach Day','Relax and have fun at the beach',5000),(7,'Mountain Trek','Embark on a challenging mountain trek',350),(8,'Historical Tour','Learn about the city rich history',500),(9,'Wildlife','Spot wildlife in their natural habitat',700),(10,'Boat Excursion','Take a boat trip on a scenic lake',900);
/*!40000 ALTER TABLE `activities` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itinerary`
--

DROP TABLE IF EXISTS `itinerary`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `itinerary` (
  `itinerary_id` int NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `start_date` date DEFAULT NULL,
  `end_date` date DEFAULT NULL,
  `user_id` int DEFAULT NULL,
  `cost` int DEFAULT NULL,
  PRIMARY KEY (`itinerary_id`),
  KEY `user_id` (`user_id`),
  CONSTRAINT `itinerary_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itinerary`
--

LOCK TABLES `itinerary` WRITE;
/*!40000 ALTER TABLE `itinerary` DISABLE KEYS */;
INSERT INTO `itinerary` VALUES (1,'Weekend Getaway','2024-02-10','2024-02-12',1,1000),(2,'Cultural Exploration','2024-03-15','2024-03-20',2,500),(3,'Adventure Weekend','2024-04-08','2024-04-10',3,2000),(4,'Nature Retreat','2024-05-20','2024-05-25',1,1500),(5,'Island Escape','2024-06-15','2024-06-20',2,5000),(6,'Historical Journey','2024-07-05','2024-07-10',3,2500),(7,'Wildlife Expedition','2024-08-18','2024-08-22',1,900),(8,'Desert Adventure','2024-09-12','2024-09-15',2,950),(9,'National Park Discovery','2024-10-05','2024-10-10',3,8000),(10,'Lakeside Serenity','2024-11-08','2024-11-12',1,650),(11,'Trial1','2026-05-01','2026-05-05',1,100),(12,'Clarisse','2024-02-06','2024-02-10',1,200),(13,'Family Vacation','2024-03-01','2024-03-10',2,10000),(14,'Ski Trip','2024-12-15','2024-12-20',3,4500),(15,'Road Trip Adventure','2025-11-01','2025-11-10',4,300);
/*!40000 ALTER TABLE `itinerary` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `ItineraryInsertTrigger` AFTER INSERT ON `itinerary` FOR EACH ROW BEGIN
    INSERT INTO ItineraryLog (event_type, event_description, event_timestamp)
    VALUES ('INSERT', CONCAT('New itinerary added: ', NEW.name), NOW());
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `AfterItineraryUpdate` AFTER UPDATE ON `itinerary` FOR EACH ROW BEGIN
    INSERT INTO ItineraryLog(event_type, event_description)
    VALUES ('UPDATE', CONCAT('Itinerary updated from ', OLD.name, ' to ', NEW.name));
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `AfterItineraryDelete` AFTER DELETE ON `itinerary` FOR EACH ROW BEGIN
    INSERT INTO ItineraryLog(event_type, event_description)
    VALUES ('DELETE', CONCAT('Itinerary deleted: ', OLD.name));
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `itinerary_details`
--

DROP TABLE IF EXISTS `itinerary_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `itinerary_details` (
  `itinerary_detail_id` int NOT NULL,
  `itinerary_id` int DEFAULT NULL,
  `day_number` int DEFAULT NULL,
  `location_id` int DEFAULT NULL,
  `activity_id` int DEFAULT NULL,
  PRIMARY KEY (`itinerary_detail_id`),
  KEY `itinerary_id` (`itinerary_id`),
  KEY `location_id` (`location_id`),
  KEY `activity_id` (`activity_id`),
  CONSTRAINT `itinerary_details_ibfk_1` FOREIGN KEY (`itinerary_id`) REFERENCES `itinerary` (`itinerary_id`),
  CONSTRAINT `itinerary_details_ibfk_2` FOREIGN KEY (`location_id`) REFERENCES `locations` (`location_id`),
  CONSTRAINT `itinerary_details_ibfk_3` FOREIGN KEY (`activity_id`) REFERENCES `activities` (`activity_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itinerary_details`
--

LOCK TABLES `itinerary_details` WRITE;
/*!40000 ALTER TABLE `itinerary_details` DISABLE KEYS */;
INSERT INTO `itinerary_details` VALUES (1,1,1,1,1),(2,1,2,2,2),(3,2,1,3,3),(4,2,2,4,4),(5,3,1,5,5),(6,3,2,6,6),(7,4,1,7,7),(8,4,2,8,8),(9,5,1,9,9),(10,5,2,10,10);
/*!40000 ALTER TABLE `itinerary_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `itinerarydetailsview`
--

DROP TABLE IF EXISTS `itinerarydetailsview`;
/*!50001 DROP VIEW IF EXISTS `itinerarydetailsview`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `itinerarydetailsview` AS SELECT 
 1 AS `itinerary_id`,
 1 AS `itinerary_name`,
 1 AS `start_date`,
 1 AS `end_date`,
 1 AS `day_number`,
 1 AS `location_name`,
 1 AS `activity_name`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `itinerarylog`
--

DROP TABLE IF EXISTS `itinerarylog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `itinerarylog` (
  `log_id` int NOT NULL AUTO_INCREMENT,
  `event_type` varchar(50) NOT NULL,
  `event_description` text NOT NULL,
  `event_timestamp` datetime DEFAULT NULL,
  PRIMARY KEY (`log_id`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itinerarylog`
--

LOCK TABLES `itinerarylog` WRITE;
/*!40000 ALTER TABLE `itinerarylog` DISABLE KEYS */;
INSERT INTO `itinerarylog` VALUES (1,'UPDATE','',NULL),(2,'UPDATE','',NULL),(3,'UPDATE','',NULL),(4,'UPDATE','',NULL),(5,'INSERT','New itinerary added: Weekend Getaway','2024-04-12 14:09:20'),(6,'INSERT','New itinerary added: Cultural Exploration','2024-04-12 14:09:20'),(7,'INSERT','New itinerary added: Adventure Weekend','2024-04-12 14:09:20'),(8,'INSERT','New itinerary added: Nature Retreat','2024-04-12 14:09:20'),(9,'INSERT','New itinerary added: Island Escape','2024-04-12 14:09:20'),(10,'INSERT','New itinerary added: Historical Journey','2024-04-12 14:09:20'),(11,'INSERT','New itinerary added: Wildlife Expedition','2024-04-12 14:09:20'),(12,'INSERT','New itinerary added: Desert Adventure','2024-04-12 14:09:20'),(13,'INSERT','New itinerary added: National Park Discovery','2024-04-12 14:09:20'),(14,'INSERT','New itinerary added: Lakeside Serenity','2024-04-12 14:09:20'),(15,'INSERT','New itinerary added: Trial1','2024-04-12 14:09:20'),(16,'INSERT','New itinerary added: Clarisse','2024-04-12 14:09:20'),(17,'INSERT','New itinerary added: Family Vacation','2024-04-12 14:09:20'),(18,'INSERT','New itinerary added: Ski Trip','2024-04-12 14:09:20'),(19,'INSERT','New itinerary added: Road Trip Adventure','2024-04-12 14:09:20'),(20,'UPDATE','Itinerary updated from Weekend Getaway to Weekend Getaway',NULL),(21,'UPDATE','Itinerary updated from Cultural Exploration to Cultural Exploration',NULL),(22,'UPDATE','Itinerary updated from Adventure Weekend to Adventure Weekend',NULL),(23,'UPDATE','Itinerary updated from Nature Retreat to Nature Retreat',NULL),(24,'UPDATE','Itinerary updated from Island Escape to Island Escape',NULL),(25,'UPDATE','Itinerary updated from Historical Journey to Historical Journey',NULL),(26,'UPDATE','Itinerary updated from Wildlife Expedition to Wildlife Expedition',NULL),(27,'UPDATE','Itinerary updated from Family Vacation to Family Vacation',NULL),(28,'UPDATE','Itinerary updated from Road Trip Adventure to Road Trip Adventure',NULL),(29,'UPDATE','Itinerary updated from Ski Trip to Ski Trip',NULL),(30,'UPDATE','Itinerary updated from Desert Adventure to Desert Adventure',NULL),(31,'UPDATE','Itinerary updated from National Park Discovery to National Park Discovery',NULL),(32,'UPDATE','Itinerary updated from Lakeside Serenity to Lakeside Serenity',NULL),(33,'UPDATE','Itinerary updated from Trial1 to Trial1',NULL),(34,'UPDATE','Itinerary updated from Clarisse to Clarisse',NULL);
/*!40000 ALTER TABLE `itinerarylog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `locations`
--

DROP TABLE IF EXISTS `locations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `locations` (
  `location_id` int NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `description` text,
  `visitor_count` int DEFAULT NULL,
  PRIMARY KEY (`location_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `locations`
--

LOCK TABLES `locations` WRITE;
/*!40000 ALTER TABLE `locations` DISABLE KEYS */;
INSERT INTO `locations` VALUES (1,'Musuem','A museum that has a lot of history',500),(2,'Camping','Good for hikers',1000),(3,'Beach','A beautiful beaches with rock formation',5000),(4,'Mountain Village','A peaceful village in the mountains',300),(5,'Historical Place','Rich in historical landmarks',400),(6,'Nature Hopping','Explore the beauty of untouched nature',100),(7,'Island','Relax on a tropical island',10000),(8,'Desert','Discover the wonders of a desert oasis',150),(9,'National Park','Enjoy the flora and fauna of a national park',700),(10,'Lakeside Viewing','Find tranquility by the lakeside',550);
/*!40000 ALTER TABLE `locations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `popularlocationsview`
--

DROP TABLE IF EXISTS `popularlocationsview`;
/*!50001 DROP VIEW IF EXISTS `popularlocationsview`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `popularlocationsview` AS SELECT 
 1 AS `location_name`,
 1 AS `num_itineraries`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `useritineraryview`
--

DROP TABLE IF EXISTS `useritineraryview`;
/*!50001 DROP VIEW IF EXISTS `useritineraryview`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `useritineraryview` AS SELECT 
 1 AS `username`,
 1 AS `itinerary_name`,
 1 AS `start_date`,
 1 AS `end_date`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `user_id` int NOT NULL,
  `username` varchar(50) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `age` int DEFAULT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'jan','janjan@gmail.com','han','inactive',NULL),(2,'may','may21@gmail.com','may2','inactive',NULL),(3,'joe','joe@gmail.com','123','inactive',NULL),(4,'walter','walter99@gmail.com','waltz','inactive',NULL),(5,'artesia','artersia0@gmail.com','arter','inactive',NULL),(6,'raiden','raiden@gmail.com','meimei','inactive',NULL),(7,'zhongli','zhongli07@gmail','zhozho','inactive',NULL),(8,'danica','dandan@gmail.com','dan01','inactive',NULL),(9,'bim','bim15@gmail.com','cla03','inactive',21),(10,'cla','cla03@gmail.com','bim15','active',20),(11,'justin','tatin@gmail.com','jay','inactive',NULL),(12,'eva','eva23@gmail.com','edwin','inactive',NULL),(13,'papamo','papamo@gmail.com','papamopink','inactive',NULL),(14,'mamamo','mamamo@gmail.com','mamamoblue','inactive',NULL),(15,'delight','light@gamil.com','lightbl','inactive',NULL);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'event'
--

--
-- Dumping routines for database 'event'
--
/*!50003 DROP FUNCTION IF EXISTS `GetTotalItineraries` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `GetTotalItineraries`() RETURNS int
    READS SQL DATA
BEGIN
    DECLARE total_itineraries INT;
    SELECT COUNT(*) INTO total_itineraries FROM Itinerary;
    RETURN total_itineraries;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `AddItinerary` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddItinerary`(
    IN p_name VARCHAR(255),
    IN p_start_date DATE,
    IN p_end_date DATE,
    IN p_user_id INT
)
BEGIN
    INSERT INTO Itinerary(name, start_date, end_date, user_id)
    VALUES (p_name, p_start_date, p_end_date, p_user_id);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `itinerarydetailsview`
--

/*!50001 DROP VIEW IF EXISTS `itinerarydetailsview`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `itinerarydetailsview` AS select `it`.`itinerary_id` AS `itinerary_id`,`it`.`name` AS `itinerary_name`,`it`.`start_date` AS `start_date`,`it`.`end_date` AS `end_date`,`itd`.`day_number` AS `day_number`,`loc`.`name` AS `location_name`,`act`.`name` AS `activity_name` from (((`itinerary` `it` join `itinerary_details` `itd` on((`it`.`itinerary_id` = `itd`.`itinerary_id`))) join `locations` `loc` on((`itd`.`location_id` = `loc`.`location_id`))) join `activities` `act` on((`itd`.`activity_id` = `act`.`activity_id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `popularlocationsview`
--

/*!50001 DROP VIEW IF EXISTS `popularlocationsview`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `popularlocationsview` AS select `loc`.`name` AS `location_name`,count(`itd`.`itinerary_id`) AS `num_itineraries` from (`locations` `loc` left join `itinerary_details` `itd` on((`loc`.`location_id` = `itd`.`location_id`))) group by `loc`.`location_id` order by `num_itineraries` desc */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `useritineraryview`
--

/*!50001 DROP VIEW IF EXISTS `useritineraryview`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `useritineraryview` AS select `u`.`username` AS `username`,`it`.`name` AS `itinerary_name`,`it`.`start_date` AS `start_date`,`it`.`end_date` AS `end_date` from (`users` `u` join `itinerary` `it` on((`u`.`user_id` = `it`.`user_id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-04-28 22:54:54
