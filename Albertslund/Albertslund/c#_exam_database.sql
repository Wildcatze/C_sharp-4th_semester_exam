SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

DROP SCHEMA IF EXISTS `c#_exam`;
CREATE SCHEMA IF NOT EXISTS `c#_exam`;
USE `c#_exam`;

-- ----------------------------------------------------------------------------
-- From the Excel *csv files the same row will always be the reading of the  -- 
-- same house in all of the excel documents and the reading_id will be       --
-- correlated to the row where the reading is made in excel.                 --
-- Example: reading_id is 15 then this must be the row 15 in every excel.    --
-- ----------------------------------------------------------------------------

CREATE TABLE IF NOT EXISTS `c#_exam`.`readings`
(`reading_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
`timestamp` TIMESTAMP NOT NULL,
`energy_used` VARCHAR(10) NOT NULL,
`water_used` VARCHAR(10) NOT NULL,
`user_id` INT,
PRIMARY KEY (`reading_id`),
UNIQUE INDEX `reading_id` (`reading_id` ASC) VISIBLE);

START TRANSACTION;
USE `c#_exam`;
INSERT INTO `c#_exam`.`readings` (`reading_id`, `timestamp`, `energy_used`, `water_used`,`user_id`)
	VALUES (1, '2020-02-27 23:59:00', '3179,5', '56387,8',1);
INSERT INTO `c#_exam`.`readings` (`reading_id`,  `timestamp`, `energy_used`, `water_used`,`user_id`)
	VALUES (2, '2020-02-27 23:59:00', '12,178', '366,869',2);
INSERT INTO `c#_exam`.`readings` (`reading_id`,  `timestamp`, `energy_used`, `water_used`,`user_id`)
	VALUES (3, '2020-02-27 23:59:00', '19,661', '695,487',3);
INSERT INTO `c#_exam`.`readings` (`reading_id`,  `timestamp`, `energy_used`, `water_used`,`user_id`)
	VALUES (4, '2020-02-27 23:35:00', '8,592', '290,605',4);
INSERT INTO `c#_exam`.`readings` (`reading_id`,  `timestamp`, `energy_used`, `water_used`,`user_id`)
	VALUES (5, '2020-02-27 23:07:00', '13,945', '403,497',5);
INSERT INTO `c#_exam`.`readings` (`reading_id`,  `timestamp`, `energy_used`, `water_used`,`user_id`)
	VALUES (6, '2020-02-27 23:58:00', '15', '387,685',6);
INSERT INTO `c#_exam`.`readings` (`reading_id`,  `timestamp`, `energy_used`, `water_used`,`user_id`)
	VALUES (7, '2020-02-27 23:58:00', '13,274', '504,379',7);
INSERT INTO `c#_exam`.`readings` (`reading_id`,  `timestamp`, `energy_used`, `water_used`,`user_id`)
	VALUES (8, '2020-02-27 23:58:00', '11,971', '347,939',8);
INSERT INTO `c#_exam`.`readings` (`reading_id`,  `timestamp`, `energy_used`, `water_used`,`user_id`)
	VALUES (9, '2020-02-27 23:59:00', '12,511', '353,787',9);
INSERT INTO `c#_exam`.`readings` (`reading_id`,  `timestamp`, `energy_used`, `water_used`,`user_id`)
	VALUES (10, '2020-02-27 23:53:00', '17,456', '494,915',10);
COMMIT;

CREATE TABLE IF NOT EXISTS `c#_exam`.`user`
(`user_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
`first_name` VARCHAR(20) NOT NULL,
`second_name` VARCHAR(20) NOT NULL,
`username` VARCHAR(20) NOT NULL UNIQUE,
`password` VARCHAR(20) NOT NULL,
`reading_id` INT UNSIGNED NULL DEFAULT NULL,
`contact_id` INT UNSIGNED NULL DEFAULT NULL,
`address_id` INT UNSIGNED NULL DEFAULT NULL,
`house_id` INT UNSIGNED NULL DEFAULT NULL,
PRIMARY KEY (`user_id`),
UNIQUE INDEX `user_id` (`user_id` ASC) VISIBLE,

INDEX `reading_id_fk` (`reading_id` ASC) VISIBLE,
CONSTRAINT `reading_id_fk`
    FOREIGN KEY (`reading_id`)
    REFERENCES `c#_exam`.`readings` (`reading_id`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION,
    
INDEX `contact_id_fk` (`contact_id` ASC) VISIBLE,
CONSTRAINT `contact_id_fk`
    FOREIGN KEY (`contact_id`)
    REFERENCES `c#_exam`.`user_contact` (`contact_id`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION,
    
INDEX `address_id_fk` (`address_id` ASC) VISIBLE,
CONSTRAINT `address_id_fk`
    FOREIGN KEY (`address_id`)
    REFERENCES `c#_exam`.`user_address` (`address_id`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION,
    
INDEX `house_id_fk` (`house_id` ASC) VISIBLE,
CONSTRAINT `house_id_fk`
    FOREIGN KEY (`house_id`)
    REFERENCES `c#_exam`.`user_house` (`house_id`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION);
    
START TRANSACTION;
USE `c#_exam`;
INSERT INTO `c#_exam`.`user` (`user_id`, `first_name`, `second_name`, `username`, `password`, `reading_id`,  `contact_id`, `address_id`, `house_id`)
	VALUES (1, 'Dagmara', 'Przygocka', 'dagmara', 'tigerISmyDOG', 1, 1, 1, 1);
INSERT INTO `c#_exam`.`user` (`user_id`, `first_name`, `second_name`, `username`, `password`, `reading_id`,  `contact_id`, `address_id`, `house_id`)
	VALUES (2, 'Aleksandar', 'Minchev', 'alex', 'IwantAnewJOB', 2, 2, 2, 2);
INSERT INTO `c#_exam`.`user` (`user_id`, `first_name`, `second_name`, `username`, `password`, `reading_id`,  `contact_id`, `address_id`, `house_id`)
	VALUES (3, 'Dorin', 'Moldovan', 'dorin', 'IMissTheNetherlands', 3, 3, 3, 3);
INSERT INTO `c#_exam`.`user` (`user_id`, `first_name`, `second_name`, `username`, `password`, `reading_id`,  `contact_id`, `address_id`, `house_id`)
	VALUES (4, 'Alexandru', 'Gabriel', 'gabriel', 'notEnoughSleep', 4, 4, 4, 4);
INSERT INTO `c#_exam`.`user` (`user_id`, `first_name`, `second_name`, `username`, `password`, `reading_id`,  `contact_id`, `address_id`, `house_id`)
	VALUES (5, 'Janus', 'Pedersen', 'janus', 'password', 5, 5, 5, 5);
INSERT INTO `c#_exam`.`user` (`user_id`, `first_name`, `second_name`, `username`, `password`, `reading_id`,  `contact_id`, `address_id`, `house_id`)
	VALUES (6, 'Brad', 'Pitt', 'brad', 'password', 6, 6, 6, 6);
INSERT INTO `c#_exam`.`user` (`user_id`, `first_name`, `second_name`, `username`, `password`, `reading_id`,  `contact_id`, `address_id`, `house_id`)
	VALUES (7, 'Antonio', 'Banderas', 'antonio', 'password', 7, 7, 7, 7);
INSERT INTO `c#_exam`.`user` (`user_id`, `first_name`, `second_name`, `username`, `password`, `reading_id`,  `contact_id`, `address_id`, `house_id`)
	VALUES (8, 'Michael', 'Schumacher', 'michael', 'password', 8, 8, 8, 8);
INSERT INTO `c#_exam`.`user` (`user_id`, `first_name`, `second_name`, `username`, `password`, `reading_id`,  `contact_id`, `address_id`, `house_id`)
	VALUES (9, 'Niels', 'Bohr', 'niels', 'password', 9, 9, 9, 9);
INSERT INTO `c#_exam`.`user` (`user_id`, `first_name`, `second_name`, `username`, `password`, `reading_id`,  `contact_id`, `address_id`, `house_id`)
	VALUES (10, 'Nikola', 'Tesla', 'nikola', 'password', 10, 10, 10, 10);
COMMIT;

CREATE TABLE IF NOT EXISTS 	`c#_exam`.`user_contact`
(`contact_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
`email` VARCHAR(65) NOT NULL,
`phone` VARCHAR(25) NOT NULL,
`social_media` VARCHAR(65),
PRIMARY KEY (`contact_id`),
UNIQUE INDEX `contact_id` (`contact_id` ASC) VISIBLE);

START TRANSACTION;
USE `c#_exam`;
INSERT INTO `c#_exam`.`user_contact` (`contact_id`, `email`, `phone`, `social_media`)
	VALUES (1, 'email@gmail.com', '(+45) 12 34 56 78', 'myself.facebook.com');
INSERT INTO `c#_exam`.`user_contact` (`contact_id`, `email`, `phone`, `social_media`)
	VALUES (2, 'email@gmail.com', '(+45) 12 34 56 78', 'myself.facebook.com');
INSERT INTO `c#_exam`.`user_contact` (`contact_id`, `email`, `phone`, `social_media`)
	VALUES (3, 'email@gmail.com', '(+45) 12 34 56 78', 'myself.facebook.com');
INSERT INTO `c#_exam`.`user_contact` (`contact_id`, `email`, `phone`, `social_media`)
	VALUES (4, 'email@gmail.com', '(+45) 12 34 56 78', 'myself.facebook.com');
INSERT INTO `c#_exam`.`user_contact` (`contact_id`, `email`, `phone`, `social_media`)
	VALUES (5, 'email@gmail.com', '(+45) 12 34 56 78', 'myself.facebook.com');
INSERT INTO `c#_exam`.`user_contact` (`contact_id`, `email`, `phone`, `social_media`)
	VALUES (6, 'email@gmail.com', '(+45) 12 34 56 78', 'myself.facebook.com');
INSERT INTO `c#_exam`.`user_contact` (`contact_id`, `email`, `phone`, `social_media`)
	VALUES (7, 'email@gmail.com', '(+45) 12 34 56 78', 'myself.facebook.com');
INSERT INTO `c#_exam`.`user_contact` (`contact_id`, `email`, `phone`, `social_media`)
	VALUES (8, 'email@gmail.com', '(+45) 12 34 56 78', 'myself.facebook.com');
INSERT INTO `c#_exam`.`user_contact` (`contact_id`, `email`, `phone`, `social_media`)
	VALUES (9, 'email@gmail.com', '(+45) 12 34 56 78', 'myself.facebook.com');
INSERT INTO `c#_exam`.`user_contact` (`contact_id`, `email`, `phone`, `social_media`)
	VALUES (10, 'email@gmail.com', '(+45) 12 34 56 78', 'myself.facebook.com');
COMMIT;

CREATE TABLE IF NOT EXISTS `c#_exam`.`user_address`
(`address_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
`street_name` VARCHAR(50) NOT NULL,
`street_no` INT(5) UNSIGNED NOT NULL,
`ZIP` INT(4) UNSIGNED NOT NULL,
`region` VARCHAR(20) NOT NULL,
PRIMARY KEY (`address_id`),
UNIQUE INDEX `address_id` (`address_id` ASC) VISIBLE);

START TRANSACTION;
USE `c#_exam`;
INSERT INTO `c#_exam`.`user_address` (`address_id`, `street_name`, `street_no`, `ZIP`, `region`)
	VALUES(1, 'Damgårdsvej', 1, 2620, 'Albertslund');
INSERT INTO `c#_exam`.`user_address` (`address_id`, `street_name`, `street_no`, `ZIP`, `region`)
	VALUES(2, 'Damgårdsvej', 2, 2620, 'Albertslund');
INSERT INTO `c#_exam`.`user_address` (`address_id`, `street_name`, `street_no`, `ZIP`, `region`)
	VALUES(3, 'Damgårdsvej', 3, 2620, 'Albertslund');
INSERT INTO `c#_exam`.`user_address` (`address_id`, `street_name`, `street_no`, `ZIP`, `region`)
	VALUES(4, 'Damgårdsvej', 4, 2620, 'Albertslund');
INSERT INTO `c#_exam`.`user_address` (`address_id`, `street_name`, `street_no`, `ZIP`, `region`)
	VALUES(5, 'Damgårdsvej', 5, 2620, 'Albertslund');
INSERT INTO `c#_exam`.`user_address` (`address_id`, `street_name`, `street_no`, `ZIP`, `region`)
	VALUES(6, 'Damgårdsvej', 6, 2620, 'Albertslund');
INSERT INTO `c#_exam`.`user_address` (`address_id`, `street_name`, `street_no`, `ZIP`, `region`)
	VALUES(7, 'Damgårdsvej', 7, 2620, 'Albertslund');
INSERT INTO `c#_exam`.`user_address` (`address_id`, `street_name`, `street_no`, `ZIP`, `region`)
	VALUES(8, 'Damgårdsvej', 8, 2620, 'Albertslund');
INSERT INTO `c#_exam`.`user_address` (`address_id`, `street_name`, `street_no`, `ZIP`, `region`)
	VALUES(9, 'Damgårdsvej', 9, 2620, 'Albertslund');
INSERT INTO `c#_exam`.`user_address` (`address_id`, `street_name`, `street_no`, `ZIP`, `region`)
	VALUES(10, 'Damgårdsvej', 10, 2620, 'Albertslund');
COMMIT;

CREATE TABLE IF NOT EXISTS `c#_exam`.`user_house`
(`house_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
`house_type` VARCHAR(15) NOT NULL,
`house_area` VARCHAR(10) NOT NULL,
`heating_system` VARCHAR(20) NOT NULL,
PRIMARY KEY (`house_id`),
UNIQUE INDEX `house_id` (`house_id` ASC) VISIBLE);

START TRANSACTION;
USE `c#_exam`;
INSERT INTO `c#_exam`.`user_house` (`house_id`, `house_type`, `house_area`, `heating_system`)
	VALUES(1, 'apartment', '64,5', 'public heating');
INSERT INTO `c#_exam`.`user_house` (`house_id`, `house_type`, `house_area`, `heating_system`)
	VALUES(2, 'apartment', '64,5', 'public heating');
INSERT INTO `c#_exam`.`user_house` (`house_id`, `house_type`, `house_area`, `heating_system`)
	VALUES(3, 'apartment', '64,5', 'public heating');
INSERT INTO `c#_exam`.`user_house` (`house_id`, `house_type`, `house_area`, `heating_system`)
	VALUES(4, 'apartment', '64,5', 'public heating');
INSERT INTO `c#_exam`.`user_house` (`house_id`, `house_type`, `house_area`, `heating_system`)
	VALUES(5, 'apartment', '64,5', 'public heating');
INSERT INTO `c#_exam`.`user_house` (`house_id`, `house_type`, `house_area`, `heating_system`)
	VALUES(6, 'apartment', '64,5', 'public heating');
INSERT INTO `c#_exam`.`user_house` (`house_id`, `house_type`, `house_area`, `heating_system`)
	VALUES(7, 'apartment', '64,5', 'public heating');
INSERT INTO `c#_exam`.`user_house` (`house_id`, `house_type`, `house_area`, `heating_system`)
	VALUES(8, 'apartment', '64,5', 'public heating');
INSERT INTO `c#_exam`.`user_house` (`house_id`, `house_type`, `house_area`, `heating_system`)
	VALUES(9, 'apartment', '64,5', 'public heating');
INSERT INTO `c#_exam`.`user_house` (`house_id`, `house_type`, `house_area`, `heating_system`)
	VALUES(10, 'apartment', '64,5', 'public heating');
COMMIT;