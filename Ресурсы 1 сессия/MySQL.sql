CREATE TABLE `user` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Password` longtext NOT NULL,
  `FirstName` varchar(255) NOT NULL,
  `MiddleName` varchar(255) NOT NULL,
  `LastName` varchar(255) NOT NULL,
  `Login` varchar(255) NOT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `IX_User` (`Login`)
) ENGINE=InnoDB AUTO_INCREMENT=14;

LOCK TABLES `user` WRITE;

INSERT INTO `user` VALUES (1,' ','Альбина ','Галиуллина','Нафисовна','galiulina',0),(2,' ','Александр ','Кудряшов','Витальевич','kudryashov',0),(3,' ','Светлана ','Велижанина','Николаевна','velizhanina',0),(4,' ','Алевтина ','Плотникова','Валентиновна','plotnikova',0),(5,' ','Александр ','Мальцев','Сергеевич','malcev',0),(6,' ','Екатерина ','Морозова','Владимировна','morozova',0),(7,' ','Анастасия ','Пьянкова','Борисовна','pyankova',0),(11,' ','Дарья ','Куклева','Владимировна','kukleva',0),(12,' ','Владислав ','Кремлев','Юрьевич','kremlev',0),(13,' ','Андрей ','Лавринов','Борисович','lavrinov',0);

UNLOCK TABLES;


CREATE TABLE `manager` (
  `ID` int(11) NOT NULL,
  `JuniorMinimum` int(11) NOT NULL,
  `MiddleMinimum` int(11) NOT NULL,
  `SeniorMinimum` int(11) NOT NULL,
  `AnalysisCoefficient` double NOT NULL,
  `InstallationCoefficient` double NOT NULL,
  `SupportCoefficient` double NOT NULL,
  `TimeCoefficient` double NOT NULL,
  `DifficultyCoefficient` double NOT NULL,
  `ToMoneyCoefficient` double NOT NULL,
  PRIMARY KEY (`ID`),
  CONSTRAINT `FK_Manager_User` FOREIGN KEY (`ID`) REFERENCES `user` (`id`)
) ENGINE=InnoDB;

LOCK TABLES `manager` WRITE;

INSERT INTO `manager` VALUES (11,10000,20000,30000,0.9,0.7,0.4,1.9,2.5,200),(12,12000,24000,36000,0.8,0.5,0.2,1.5,2,195),(13,5000,15000,30000,1,1,0.2,3.4,2.9,250);

UNLOCK TABLES;


CREATE TABLE `executor` (
  `ID` int(11) NOT NULL,
  `ManagerID` int(11) NOT NULL,
  `Grade` varchar(20) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `executors_fk0` (`ManagerID`),
  CONSTRAINT `FK_Executor_User` FOREIGN KEY (`ID`) REFERENCES `user` (`id`),
  CONSTRAINT `executors_fk0` FOREIGN KEY (`ManagerID`) REFERENCES `manager` (`id`) ON UPDATE CASCADE
) ENGINE=InnoDB;

LOCK TABLES `executor` WRITE;

INSERT INTO `executor` VALUES (1,11,'junior'),(2,11,'middle'),(3,12,'senior'),(4,12,'junior'),(5,12,'middle'),(6,13,'junior'),(7,13,'junior');

UNLOCK TABLES;


DROP TABLE IF EXISTS `task`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `task` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ExecutorID` int(11) NOT NULL,
  `Title` varchar(255) NOT NULL,
  `Description` longtext,
  `CreateDateTime` datetime(6) NOT NULL,
  `Deadline` date NOT NULL,
  `Difficulty` double NOT NULL,
  `Time` int(11) NOT NULL,
  `Status` varchar(20) NOT NULL,
  `WorkType` varchar(45) NOT NULL,
  `CompletedDateTime` datetime(6) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `tasks_fk0` (`ExecutorID`),
  CONSTRAINT `tasks_fk0` FOREIGN KEY (`ExecutorID`) REFERENCES `executor` (`id`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=19;

LOCK TABLES `task` WRITE;

INSERT INTO `task` VALUES (10,1,'Проектирование системы для \"ООО Автопром-сервис\"',NULL,'2018-12-14 00:00:00.000000','2018-12-22',20,573,'запланирована','анализ и проектирование',NULL,0),(11,1,'Установка оборудования для \"ООО Автопром-сервис\"',NULL,'2018-12-15 00:00:00.000000','2018-12-23',25,613,'запланирована','установка оборудования',NULL,0),(12,2,'Анализ поломки оборудования у \"Пятерочка\"',NULL,'2018-12-16 00:00:00.000000','2018-12-24',12,667,'запланирована','техническое обслуживание и сопровождение',NULL,0),(13,3,'Подготовить коммерческое предложение для \"Евросеть\"',NULL,'2018-12-16 00:00:00.000000','2018-12-24',45,132,'запланирована','анализ и проектирование',NULL,0),(14,4,'Подготовить коммерческое предложение для \"Дикси\"',NULL,'2018-12-16 00:00:00.000000','2018-12-26',35,857,'запланирована','анализ и проектирование',NULL,0),(15,5,'Установка оборудования для \"ООО Магнит\"',NULL,'2018-12-17 00:00:00.000000','2018-12-29',32,627,'запланирована','установка оборудования',NULL,0),(16,5,'Установка оборудования для \"Бристоль\"',NULL,'2018-12-17 00:00:00.000000','2018-12-29',24,767,'запланирована','установка оборудования',NULL,0),(17,6,'Отправить пригласительные письма потенциальным клиентам',NULL,'2018-12-18 00:00:00.000000','2018-12-29',15,805,'запланирована','анализ и проектирование',NULL,0),(18,7,'Отработать возражения от \"Пчелки\"',NULL,'2018-12-20 00:00:00.000000','2018-12-30',34,749,'запланирована','анализ и проектирование',NULL,0);

UNLOCK TABLES;