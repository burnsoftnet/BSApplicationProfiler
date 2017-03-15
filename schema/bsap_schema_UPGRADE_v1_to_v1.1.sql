/* 
Database upgrade for the BSAP Database from version 1.0 to version 1.1
If this is a new installation, use the bsap_schema_v1.1.sql
THIS IS JUST FOR EXISTING STRUCTURES TO RETAIN DATA.
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

USE `bsap`;

INSERT INTO `DB_Version` (verNo) VALUES(1.1);

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