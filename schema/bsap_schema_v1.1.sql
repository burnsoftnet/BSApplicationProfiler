/*
SQLyog Ultimate v12.2.4 (64 bit)
MySQL - 5.6.35 : Database - bsap
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`bsap` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `bsap`;

GRANT USAGE ON *.* TO 'bsap_agent'@'%';
DROP USER 'bsap_agent'@'%';
CREATE USER 'bsap_agent'@'%';
SET PASSWORD FOR 'bsap_agent'@'%' = PASSWORD('bs.app.monitor.agent');
GRANT ALL PRIVILEGES ON *.* TO 'bsap_agent'@'%';
GRANT ALL PRIVILEGES ON bsap.* TO 'bsap_agent'@'%';
FLUSH PRIVILEGES;

GRANT USAGE ON *.* TO 'bsap_admin'@'%';
DROP USER 'bsap_admin'@'%';
CREATE USER 'bsap_admin'@'%';
SET PASSWORD FOR 'bsap_admin'@'%' = PASSWORD('bs.app.monitor.admin');
GRANT ALL PRIVILEGES ON *.* TO 'bsap_admin'@'%';
GRANT ALL PRIVILEGES ON bsap.* TO 'bsap_admin'@'%';
FLUSH PRIVILEGES;


/*Table structure for table `DB_Version` */

DROP TABLE IF EXISTS `DB_Version`;

CREATE TABLE `DB_Version` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `verNo` VARCHAR(45) DEFAULT NULL,
  `dtUpdated` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=INNODB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

INSERT INTO `DB_Version` (verNo) VALUES(1.1);
/*Table structure for table `agents` */

DROP TABLE IF EXISTS `agents`;

CREATE TABLE `agents` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `computername` VARCHAR(45) DEFAULT NULL COMMENT 'computer name',
  `maxmem` VARCHAR(45) DEFAULT NULL COMMENT 'memory',
  `cpuspeed` VARCHAR(45) DEFAULT NULL COMMENT 'CPU Speed',
  `cpuname` VARCHAR(255) DEFAULT NULL COMMENT 'cpu name',
  `operatingsystem` VARCHAR(45) DEFAULT NULL COMMENT 'OS Type',
  `dtcreated` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'Date and Time Created',
  `dtReported` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'Last Date & time it reported back',
  PRIMARY KEY (`id`)
) ENGINE=MYISAM AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

/*Table structure for table `app_project_main_log` */

DROP TABLE IF EXISTS `app_project_main_log`;

CREATE TABLE `app_project_main_log` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `apmid` INT(11) DEFAULT NULL COMMENT 'App Project Main Process ID',
  `logname` VARCHAR(255) DEFAULT NULL COMMENT 'log name',
  `logpath` VARCHAR(255) DEFAULT NULL COMMENT 'the path the log is normally stored at',
  `clearlog` INT(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MYISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Table structure for table `app_project_main_process` */

DROP TABLE IF EXISTS `app_project_main_process`;

CREATE TABLE `app_project_main_process` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `APNID` INT(11) NOT NULL COMMENT 'App Project Name ID',
  `process_display_name` VARCHAR(255) DEFAULT NULL COMMENT 'Friendly Process Display Name',
  `process_name` VARCHAR(50) DEFAULT NULL COMMENT 'the executable name',
  `match_parameters` INT(11) DEFAULT '0' COMMENT 'useful for web monitoring, you can match the parameters passed to the host process',
  `parameters` VARCHAR(255) DEFAULT NULL COMMENT 'process parameters	',
  `haslogs` INT(11) DEFAULT '0' COMMENT 'Does it produce logs files?',
  `clear_logs_on_start` INT(11) DEFAULT '0' COMMENT 'Clear logs on start of process',
  `useNTEvent` INT(11) DEFAULT '0' COMMENT 'Monitor the NT Event Log',
  `NTSource` VARCHAR(45) DEFAULT NULL COMMENT 'NT Event Source Name',
  `NTEventID` VARCHAR(45) DEFAULT NULL COMMENT 'NT Event log ID',
  `interval` INT(11) DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=MYISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Table structure for table `app_project_name` */

DROP TABLE IF EXISTS `app_project_name`;

CREATE TABLE `app_project_name` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) DEFAULT NULL COMMENT 'Application/Project Name',
  `appdesc` TEXT COMMENT 'Application/Project Description',
  `enabled` INT(11) DEFAULT '1' COMMENT 'Enabled test monitoring',
  `has_subprocess` INT(11) DEFAULT '0' COMMENT 'Application has other processes that it runs ',
  PRIMARY KEY (`id`)
) ENGINE=MYISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Table structure for table `app_project_sub_log` */

DROP TABLE IF EXISTS `app_project_sub_log`;

CREATE TABLE `app_project_sub_log` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `apspid` INT(11) DEFAULT NULL COMMENT 'App Project Sub Process ID',
  `logname` VARCHAR(255) DEFAULT NULL COMMENT 'log name',
  `logpath` VARCHAR(255) DEFAULT NULL COMMENT 'the path the log is normally stored at',
  `clearlog` INT(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MYISAM DEFAULT CHARSET=latin1;

/*Table structure for table `app_project_sub_process` */

DROP TABLE IF EXISTS `app_project_sub_process`;

CREATE TABLE `app_project_sub_process` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `APNID` INT(11) NOT NULL COMMENT 'App Project Name ID',
  `APMPID` INT(11) NOT NULL COMMENT 'App Project Main Process ID',
  `process_display_name` VARCHAR(255) DEFAULT NULL COMMENT 'Friendly Process Display Name',
  `process_name` VARCHAR(50) DEFAULT NULL COMMENT 'the executable name',
  `match_parameters` INT(11) DEFAULT '0' COMMENT 'useful for web monitoring, you can match the parameters passed to the host process',
  `parameters` VARCHAR(255) DEFAULT NULL COMMENT 'process parameters	',
  `haslogs` INT(11) DEFAULT '0' COMMENT 'Does it produce logs files?',
  `clear_logs_on_start` INT(11) DEFAULT '0' COMMENT 'Clear logs on start of process',
  `useNTEvent` INT(11) DEFAULT '0' COMMENT 'Monitor the NT Event Log',
  `NTSource` VARCHAR(45) DEFAULT NULL COMMENT 'NT Event Source Name',
  `NTEventID` VARCHAR(45) DEFAULT NULL COMMENT 'NT Event log ID',
  PRIMARY KEY (`id`)
) ENGINE=MYISAM DEFAULT CHARSET=latin1;

/*Table structure for table `logs_main` */

DROP TABLE IF EXISTS `logs_main`;

CREATE TABLE `logs_main` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `sessionid` INT(11) DEFAULT NULL COMMENT 'Session ID',
  `APNID` INT(11) DEFAULT NULL COMMENT 'Main App Project Name ID',
  `filename` VARCHAR(255) DEFAULT NULL,
  `logdetails` TEXT COMMENT 'line from log file',
  PRIMARY KEY (`id`)
) ENGINE=MYISAM AUTO_INCREMENT=23 DEFAULT CHARSET=latin1;

/*Table structure for table `monitoring_session` */

DROP TABLE IF EXISTS `monitoring_session`;

CREATE TABLE `monitoring_session` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `APNID` INT(11) DEFAULT NULL COMMENT 'App Project Name ID',
  `AID` INT(11) DEFAULT NULL COMMENT 'Agent ID',
  `sessiondt` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'Session Data and Time',
  `sessionend` TIMESTAMP NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MYISAM AUTO_INCREMENT=40 DEFAULT CHARSET=latin1;

/*Table structure for table `process_stats_main` */

DROP TABLE IF EXISTS `process_stats_main`;

CREATE TABLE `process_stats_main` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `SessionID` INT(11) DEFAULT NULL COMMENT 'ID of the session to time that the testing first started',
  `apnid` INT(11) DEFAULT NULL COMMENT 'App Project Name ID',
  `apmpid` INT(11) DEFAULT NULL COMMENT 'App Project Main Process ID',
  `AID` INT(11) DEFAULT NULL COMMENT 'Agent ID	',
  `dt` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'date and time of information gathered',
  `imagename` VARCHAR(255) DEFAULT NULL COMMENT 'process name',
  `username` VARCHAR(255) DEFAULT NULL COMMENT 'name of user running the process',
  `cpu` DOUBLE DEFAULT NULL COMMENT 'cpu use age',
  `memoryused` INT(11) DEFAULT NULL COMMENT 'memory used',
  `handles` INT(11) DEFAULT NULL COMMENT 'process handles',
  `threads` INT(11) DEFAULT NULL COMMENT 'process threads used',
  `commandline` TEXT COMMENT 'Command line used',
  PRIMARY KEY (`id`)
) ENGINE=MYISAM AUTO_INCREMENT=340 DEFAULT CHARSET=latin1;

/* Procedure structure for procedure `sp_clear_all_monitoring_data` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_clear_all_monitoring_data` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`bsap_admin`@`%` PROCEDURE `sp_clear_all_monitoring_data`()
BEGIN
	DECLARE done INT DEFAULT 0;
	DELETE from process_stats_main;
	DELETE from logs_main;
	DELETE from monitoring_session;
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_delete_session` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_delete_session` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`bsap_admin`@`%` PROCEDURE `sp_delete_session`(session_id int)
BEGIN
	DECLARE done INT DEFAULT 0;
	DELETE from process_stats_main where SessionID=session_id;
	DELETE from logs_main where sessionid=session_id;
	DELETE from monitoring_session where id=session_id;
END */$$
DELIMITER ;

/*Table structure for table `view_agents` */

DROP TABLE IF EXISTS `view_agents`;

/*!50001 DROP VIEW IF EXISTS `view_agents` */;
/*!50001 DROP TABLE IF EXISTS `view_agents` */;

/*!50001 CREATE TABLE  `view_agents`(
 `id` int(11) ,
 `computername` varchar(45) ,
 `maxmem` varchar(45) ,
 `cpuspeed` varchar(45) ,
 `cpuname` varchar(255) ,
 `operatingsystem` varchar(45) ,
 `dtcreated` timestamp ,
 `dtReported` timestamp ,
 `SessionCount` bigint(21) 
)*/;

/*Table structure for table `view_all_processes_and_projects` */

DROP TABLE IF EXISTS `view_all_processes_and_projects`;

/*!50001 DROP VIEW IF EXISTS `view_all_processes_and_projects` */;
/*!50001 DROP TABLE IF EXISTS `view_all_processes_and_projects` */;

/*!50001 CREATE TABLE  `view_all_processes_and_projects`(
 `ProcessID` int(11) ,
 `apnid` int(11) ,
 `process_display_name` varchar(255) ,
 `process_name` varchar(50) ,
 `match_parameters` int(11) ,
 `parameters` varchar(255) ,
 `haslogs` int(11) ,
 `interval` int(11) ,
 `name` varchar(255) ,
 `enabled` int(11) ,
 `has_subprocess` int(11) ,
 `appdesc` text 
)*/;

/*Table structure for table `web_view_agents` */

DROP TABLE IF EXISTS `web_view_agents`;

/*!50001 DROP VIEW IF EXISTS `web_view_agents` */;
/*!50001 DROP TABLE IF EXISTS `web_view_agents` */;

/*!50001 CREATE TABLE  `web_view_agents`(
 `id` int(11) ,
 `computername` varchar(45) ,
 `maxmem` varchar(45) ,
 `cpuspeed` varchar(45) ,
 `cpuname` varchar(255) ,
 `operatingsystem` varchar(45) ,
 `dtcreated` timestamp ,
 `dtReported` timestamp ,
 `SessionCount` bigint(21) ,
 `Web_SessionCount` varchar(117) 
)*/;

/*Table structure for table `web_view_app_project_name` */

DROP TABLE IF EXISTS `web_view_app_project_name`;

/*!50001 DROP VIEW IF EXISTS `web_view_app_project_name` */;
/*!50001 DROP TABLE IF EXISTS `web_view_app_project_name` */;

/*!50001 CREATE TABLE  `web_view_app_project_name`(
 `id` int(11) ,
 `name` varchar(255) ,
 `appdesc` text ,
 `enabled` varchar(3) ,
 `web_name` varchar(255) ,
 `byagent` varchar(255) ,
 `TotalSessions` bigint(21) 
)*/;

/*Table structure for table `web_view_monitoring_session` */

DROP TABLE IF EXISTS `web_view_monitoring_session`;

/*!50001 DROP VIEW IF EXISTS `web_view_monitoring_session` */;
/*!50001 DROP TABLE IF EXISTS `web_view_monitoring_session` */;

/*!50001 CREATE TABLE  `web_view_monitoring_session`(
 `id` int(11) ,
 `apnid` int(11) ,
 `ProjectName` varchar(255) ,
 `web_ProjectName` varchar(255) ,
 `aid` int(11) ,
 `sessiondt` timestamp ,
 `sessionend` timestamp ,
 `computername` varchar(45) ,
 `maxmem` varchar(45) ,
 `cpuspeed` varchar(45) ,
 `cpuname` varchar(255) ,
 `operatingsystem` varchar(45) ,
 `web_sessiondt` varchar(255) ,
 `web_computername` varchar(255) ,
 `HasLogs` varchar(3) 
)*/;

/*View structure for view view_agents */

/*!50001 DROP TABLE IF EXISTS `view_agents` */;
/*!50001 DROP VIEW IF EXISTS `view_agents` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`bsap_admin`@`%` SQL SECURITY DEFINER VIEW `view_agents` AS select `a`.`id` AS `id`,`a`.`computername` AS `computername`,`a`.`maxmem` AS `maxmem`,`a`.`cpuspeed` AS `cpuspeed`,`a`.`cpuname` AS `cpuname`,`a`.`operatingsystem` AS `operatingsystem`,`a`.`dtcreated` AS `dtcreated`,`a`.`dtReported` AS `dtReported`,(select count(0) from `web_view_monitoring_session` where (`web_view_monitoring_session`.`aid` = `a`.`id`)) AS `SessionCount` from `agents` `a` */;

/*View structure for view view_all_processes_and_projects */

/*!50001 DROP TABLE IF EXISTS `view_all_processes_and_projects` */;
/*!50001 DROP VIEW IF EXISTS `view_all_processes_and_projects` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`bsap_admin`@`%` SQL SECURITY DEFINER VIEW `view_all_processes_and_projects` AS select `apmp`.`id` AS `ProcessID`,`apmp`.`APNID` AS `apnid`,`apmp`.`process_display_name` AS `process_display_name`,`apmp`.`process_name` AS `process_name`,`apmp`.`match_parameters` AS `match_parameters`,`apmp`.`parameters` AS `parameters`,`apmp`.`haslogs` AS `haslogs`,`apmp`.`interval` AS `interval`,`apn`.`name` AS `name`,`apn`.`enabled` AS `enabled`,`apn`.`has_subprocess` AS `has_subprocess`,`apn`.`appdesc` AS `appdesc` from (`app_project_main_process` `apmp` join `app_project_name` `apn` on((`apn`.`id` = `apmp`.`APNID`))) */;

/*View structure for view web_view_agents */

/*!50001 DROP TABLE IF EXISTS `web_view_agents` */;
/*!50001 DROP VIEW IF EXISTS `web_view_agents` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`bsap_admin`@`%` SQL SECURITY DEFINER VIEW `web_view_agents` AS select `a`.`id` AS `id`,`a`.`computername` AS `computername`,`a`.`maxmem` AS `maxmem`,`a`.`cpuspeed` AS `cpuspeed`,`a`.`cpuname` AS `cpuname`,`a`.`operatingsystem` AS `operatingsystem`,`a`.`dtcreated` AS `dtcreated`,`a`.`dtReported` AS `dtReported`,`a`.`SessionCount` AS `SessionCount`,cast((case `a`.`SessionCount` when 0 then '0' else concat('<a href="All_Sessions_By_Agent.aspx?AID=',cast(`a`.`id` as char(50) charset utf8),'">',`a`.`SessionCount`,'</a>') end) as char(255)) AS `Web_SessionCount` from `view_agents` `a` */;

/*View structure for view web_view_app_project_name */

/*!50001 DROP TABLE IF EXISTS `web_view_app_project_name` */;
/*!50001 DROP VIEW IF EXISTS `web_view_app_project_name` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`bsap_admin`@`%` SQL SECURITY DEFINER VIEW `web_view_app_project_name` AS select `apn`.`id` AS `id`,`apn`.`name` AS `name`,`apn`.`appdesc` AS `appdesc`,concat((case `apn`.`enabled` when 1 then 'YES' when 0 then 'NO' end)) AS `enabled`,cast(concat('<a href="Project_list_all_sessions.aspx?ID=',`apn`.`id`,'">',`apn`.`name`,'</a>') as char(255) charset utf8) AS `web_name`,cast(concat('<a href="Project_list_all_sessions_by_agent.aspx?ID=',`apn`.`id`,'">',convert(concat(_latin1'<img src="images/computer.png"') using utf8),'</a>') as char(255) charset utf8) AS `byagent`,(select count(0) from `monitoring_session` where (`monitoring_session`.`APNID` = `apn`.`id`)) AS `TotalSessions` from `app_project_name` `apn` */;

/*View structure for view web_view_monitoring_session */

/*!50001 DROP TABLE IF EXISTS `web_view_monitoring_session` */;
/*!50001 DROP VIEW IF EXISTS `web_view_monitoring_session` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`bsap_admin`@`%` SQL SECURITY DEFINER VIEW `web_view_monitoring_session` AS select `ms`.`id` AS `id`,`ms`.`APNID` AS `apnid`,`apn`.`name` AS `ProjectName`,cast(concat('<a href="Project_list_all_sessions?ID=',`ms`.`id`,'">',`apn`.`name`,'</a>') as char(255) charset utf8) AS `web_ProjectName`,`ms`.`AID` AS `aid`,`ms`.`sessiondt` AS `sessiondt`,`ms`.`sessionend` AS `sessionend`,`a`.`computername` AS `computername`,`a`.`maxmem` AS `maxmem`,`a`.`cpuspeed` AS `cpuspeed`,`a`.`cpuname` AS `cpuname`,`a`.`operatingsystem` AS `operatingsystem`,cast(concat('<a href="Session_Details.aspx?SessionID=',`ms`.`id`,'&APNID=',`ms`.`APNID`,'">',`ms`.`sessiondt`,'</a>') as char(255) charset utf8) AS `web_sessiondt`,cast(concat('<a href="Session_Details_by_agent.aspx?SessionID=',`ms`.`id`,'&APNID=',`ms`.`APNID`,'&AID=',`ms`.`AID`,'">',`a`.`computername`,'</a>') as char(255) charset utf8) AS `web_computername`,(case (select count(0) from `logs_main` where (`logs_main`.`sessionid` = `ms`.`id`)) when 0 then 'NO' else 'YES' end) AS `HasLogs` from ((`monitoring_session` `ms` join `agents` `a` on((`a`.`id` = `ms`.`AID`))) join `app_project_name` `apn` on((`apn`.`id` = `ms`.`APNID`))) */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
