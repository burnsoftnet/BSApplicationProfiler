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

DROP TABLE IF EXISTS `DB_Version`;

CREATE TABLE `DB_Version` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `verNo` VARCHAR(45) NULL,
  `dtUpdated` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC));
  
  INSERT INTO `DB_Version` (verNo) VALUES(1.0);

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
  `dtReported` TIMESTAMP NULL COMMENT 'Last Date & time it reported back',
  PRIMARY KEY (`id`)
) ENGINE=MYISAM AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

/*Table structure for table `app_project_main_log` */

DROP TABLE IF EXISTS `app_project_main_log`;

CREATE TABLE `app_project_main_log` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `apmid` INT(11) DEFAULT NULL COMMENT 'App Project Main Process ID',
  `logname` VARCHAR(255) DEFAULT NULL COMMENT 'log name',
  `logpath` VARCHAR(255) DEFAULT NULL COMMENT 'the path the log is normally stored at',
  `clearlog` INT(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MYISAM AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

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
) ENGINE=MYISAM AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

/*Table structure for table `app_project_name` */

DROP TABLE IF EXISTS `app_project_name`;

CREATE TABLE `app_project_name` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) DEFAULT NULL COMMENT 'Application/Project Name',
  `appdesc` TEXT COMMENT 'Application/Project Description',
  `enabled` INT(11) DEFAULT '1' COMMENT 'Enabled test monitoring',
  `has_subprocess` INT(11) DEFAULT '0' COMMENT 'Application has other processes that it runs ',
  PRIMARY KEY (`id`)
) ENGINE=MYISAM AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

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
) ENGINE=MYISAM AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

/*Table structure for table `monitoring_session` */

DROP TABLE IF EXISTS `monitoring_session`;

CREATE TABLE `monitoring_session` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `APNID` INT(11) DEFAULT NULL COMMENT 'App Project Name ID',
  `AID` INT(11) DEFAULT NULL COMMENT 'Agent ID',
  `sessiondt` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'Session Data and Time',
  `sessionend` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'Session Data and Time',
  PRIMARY KEY (`id`)
) ENGINE=MYISAM AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

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
) ENGINE=MYISAM AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

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

/*View structure for view view_all_processes_and_projects */

/*!50001 DROP TABLE IF EXISTS `view_all_processes_and_projects` */;
/*!50001 DROP VIEW IF EXISTS `view_all_processes_and_projects` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`%` SQL SECURITY DEFINER VIEW `view_all_processes_and_projects` AS select `apmp`.`id` AS `ProcessID`,`apmp`.`APNID` AS `apnid`,`apmp`.`process_display_name` AS `process_display_name`,`apmp`.`process_name` AS `process_name`,`apmp`.`match_parameters` AS `match_parameters`,`apmp`.`parameters` AS `parameters`,`apmp`.`haslogs` AS `haslogs`,`apmp`.`interval` AS `interval`,`apn`.`name` AS `name`,`apn`.`enabled` AS `enabled`,`apn`.`has_subprocess` AS `has_subprocess`,`apn`.`appdesc` AS `appdesc` from (`app_project_main_process` `apmp` join `app_project_name` `apn` on((`apn`.`id` = `apmp`.`APNID`))) */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

DELIMITER $$
CREATE DEFINER=`root`@`%` PROCEDURE `sp_clear_all_monitoring_data`()
BEGIN
	DECLARE done INT DEFAULT 0;
	DELETE from process_stats_main;
	DELETE from logs_main;
	DELETE from monitoring_session;
END$$
DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`%` PROCEDURE `sp_delete_session`(session_id int)
BEGIN
	DECLARE done INT DEFAULT 0;
	DELETE from process_stats_main where SessionID=session_id;
	DELETE from logs_main where sessionid=session_id;
	DELETE from monitoring_session where id=session_id;
END$$
DELIMITER ;
