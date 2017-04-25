/* 
Database upgrade for the BSAP Database from version 1.1 to version 1.2
If this is a new installation, use the bsap_schema_v1.2.sql
THIS IS JUST FOR EXISTING STRUCTURES TO RETAIN DATA.
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

USE `bsap`;

INSERT INTO `DB_Version` (verNo) VALUES(1.2);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


ALTER TABLE `bsap`.`monitoring_session` 
ADD COLUMN `appversion` VARCHAR(45) NULL AFTER `sessionend`,
ADD COLUMN `appcomany` VARCHAR(255) NULL AFTER `appversion`,
ADD COLUMN `applastaccess` VARCHAR(45) NULL AFTER `appcomany`,
ADD COLUMN `applastwrite` VARCHAR(45) NULL AFTER `applastaccess`,
ADD COLUMN `createddatetime` VARCHAR(45) NULL AFTER `applastwrite`;

- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE DEFINER=`bsap_admin`@`%` PROCEDURE `sp_updateSessionEnded`()
BEGIN
	DECLARE done INT DEFAULT 0;
	Declare LastTime TIMESTAMP;
	declare SessID int;
	DECLARE SID CURSOR FOR select ID from monitoring_session where sessionend is null;
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;
	Open SID;
	REPEAT
		FETCH SID INTO SessID;
		IF NOT done THEN
			Set LastTime = (SELECT max(dt) FROM bsap.process_stats_main where sessionID=SessID);
			IF LastTime is null THEN
				DELETE from monitoring_session where ID=SessID;
			ELSE
				UPDATE monitoring_session set sessionend=LastTime where ID=SessID;
			END IF;
		END IF;
	UNTIL done END REPEAT;
	Close SID;
    END



CREATE 
    ALGORITHM = UNDEFINED 
    DEFINER = `bsap_admin`@`%` 
    SQL SECURITY DEFINER
VIEW `web_view_monitoring_session` AS
    select 
        `ms`.`id` AS `id`,
        `ms`.`APNID` AS `apnid`,
        `apn`.`name` AS `ProjectName`,
        cast(concat('<a href="Project_list_all_sessions?ID=',
                    `ms`.`id`,
                    '">',
                    `apn`.`name`,
                    '</a>')
            as char (255) charset utf8) AS `web_ProjectName`,
        `ms`.`AID` AS `aid`,
        `ms`.`sessiondt` AS `sessiondt`,
        `ms`.`sessionend` AS `sessionend`,
        `ms`.`appversion` AS `appversion`,
        `ms`.`appcomany` AS `appcomany`,
        `ms`.`applastaccess` AS `applastaccess`,
        `ms`.`applastwrite` AS `applastwrite`,
        `ms`.`createddatetime` AS `createddatetime`,
        `a`.`computername` AS `computername`,
        `a`.`maxmem` AS `maxmem`,
        `a`.`cpuspeed` AS `cpuspeed`,
        `a`.`cpuname` AS `cpuname`,
        `a`.`operatingsystem` AS `operatingsystem`,
        cast(concat('<a href="Session_Details.aspx?SessionID=',
                    `ms`.`id`,
                    '&APNID=',
                    `ms`.`APNID`,
                    '">',
                    `ms`.`sessiondt`,
                    '</a>')
            as char (255) charset utf8) AS `web_sessiondt`,
        cast(concat('<a href="Session_Details_by_agent.aspx?SessionID=',
                    `ms`.`id`,
                    '&APNID=',
                    `ms`.`APNID`,
                    '&AID=',
                    `ms`.`AID`,
                    '">',
                    `a`.`computername`,
                    '</a>')
            as char (255) charset utf8) AS `web_computername`,
        (case (select 
                count(0) AS `count(0)`
            from
                `logs_main`
            where
                (`logs_main`.`sessionid` = `ms`.`id`))
            when 0 then 'NO'
            else 'YES'
        end) AS `HasLogs`,
        cast(concat('<a href="Project_list_all_sessions?DID=',
                    `ms`.`id`,
                    '&ID=',
                    `ms`.`APNID`,
                    '">delete</a>')
            as char (255) charset utf8) AS `web_deletesession`
    from
        ((`monitoring_session` `ms`
        join `agents` `a` ON ((`a`.`id` = `ms`.`AID`)))
        join `app_project_name` `apn` ON ((`apn`.`id` = `ms`.`APNID`)))