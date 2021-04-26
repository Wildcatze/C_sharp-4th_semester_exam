SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

DROP SCHEMA IF EXISTS `c#_exam`;
CREATE SCHEMA IF NOT EXISTS `c#_exam`;
USE `c#_exam`;

CREATE TABLE IF NOT EXISTS `c#_exam`.`readings`
(`reading_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
`date` TIMESTAMP NOT NULL,
`energy_used` VARCHAR(10) NOT NULL,
`water_used` VARCHAR(10) NOT NULL,
PRIMARY KEY (`reading_id`),
UNIQUE INDEX `reading_id` (`reading_id` ASC) VISIBLE);

CREATE TABLE IF NOT EXISTS `c#_exam`.`user`
(`user_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
`first_name` VARCHAR(20) NOT NULL,
`second_name` VARCHAR(20) NOT NULL,
`username` VARCHAR(20) NOT NULL UNIQUE,
`password` VARCHAR(20) NOT NULL,
`reading_id` INT UNSIGNED NULL DEFAULT NULL,
`contact_id` INT UNSIGNED NULL DEFAULT NULL,
`address_id` INT UNSIGNED NULL DEFAULT NULL,
`bank_id` INT UNSIGNED NULL DEFAULT NULL,
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
    
INDEX `bank_id_fk` (`bank_id` ASC) VISIBLE,
CONSTRAINT `back_id_fk`
    FOREIGN KEY (`bank_id`)
    REFERENCES `c#_exam`.`user_bank` (`bank_id`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION,
    
INDEX `house_id_fk` (`house_id` ASC) VISIBLE,
CONSTRAINT `house_id_fk`
    FOREIGN KEY (`house_id`)
    REFERENCES `c#_exam`.`user_house` (`house_id`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION);

CREATE TABLE IF NOT EXISTS 	`c#_exam`.`user_contact`
(`contact_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
`email` VARCHAR(65) NOT NULL,
`phone` VARCHAR(25) NOT NULL,
`social_media` VARCHAR(65),
PRIMARY KEY (`contact_id`),
UNIQUE INDEX `contact_id` (`contact_id` ASC) VISIBLE);

CREATE TABLE IF NOT EXISTS `c#_exam`.`user_address`
(`address_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
`street_name` VARCHAR(50) NOT NULL,
`street_no` INT(5) UNSIGNED NOT NULL,
`ZIP` INT(4) UNSIGNED NOT NULL,
`region` VARCHAR(20) NOT NULL,
PRIMARY KEY (`address_id`),
UNIQUE INDEX `address_id` (`address_id` ASC) VISIBLE);

CREATE TABLE IF NOT EXISTS `c#_exam`.`user_bank`
(`bank_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
`account_no` INT UNSIGNED UNIQUE NOT NULL,
`bank_name` VARCHAR(30) NOT NULL,
PRIMARY KEY (`bank_id`),
UNIQUE INDEX `bank_id` (`bank_id` ASC) VISIBLE);

CREATE TABLE IF NOT EXISTS `c#_exam`.`user_house`
(`house_id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
`house_type` VARCHAR(15) NOT NULL,
`house_area` VARCHAR(5) NOT NULL,
`heating_system` VARCHAR(20) NOT NULL,
PRIMARY KEY (`house_id`),
UNIQUE INDEX `house_id` (`house_id` ASC) VISIBLE);

