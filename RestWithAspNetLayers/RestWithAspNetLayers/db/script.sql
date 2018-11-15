 

CREATE TABLE `persons` (
	`Id` int(10) unsigned null default null,
	`FirstName` varchar(50) null default null,
	`LastName` varchar(50) null default null,
	`Address` varchar(50) null default null,
	`Gender` varchar(50) null default null
)

ALTER TABLE PERSONS CHANGE ID ID INT(10) AUTO_INCREMENT PRIMARY KEY