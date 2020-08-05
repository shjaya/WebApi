--DATABASE CREATION--
CREATE DATABASE ItemsStore 
GO  
--CREATE TABLES QUERY --
USE  ItemsStore 
GO  
CREATE TABLE Category 
  ( 
     Id   BIGINT IDENTITY(1,1) NOT NULL, 
     NAME NVARCHAR(50) NOT NULL, 
     PRIMARY KEY (Id) 
  )  
GO 
CREATE TABLE SubCategory 
  ( 
     Id      BIGINT IDENTITY(1,1) NOT NULL, 
     CategoryId BIGINT NOT NULL, 
     Name       NVARCHAR(100) NULL, 
     PRIMARY KEY (Id), 
     FOREIGN KEY (CategoryId) REFERENCES Category(Id) 
  )  
GO  
CREATE TABLE Item 
  ( 
     Id BIGINT IDENTITY(1,1)  NOT NULL, 
	 SubCategoryId BIGINT NOT NULL,
     NAME NVARCHAR(50) NULL, 
     DESCRIPTION NVARCHAR(50) NULL, 
     PRIMARY KEY (Id),
FOREIGN KEY (SubCategoryId) REFERENCES SubCategory(Id) 	 
  )  
GO 

--INSERT QUERY--
Use ItemsStore

Go

INSERT INTO Item
VALUES
(1,'Sports Car','For Sports Purpose'),
(2,'Regular Bike','For Daily Use'),
(3,'Office Chair','Normal Chair'),
(4,'Standing Desk','For Standing Work'),
(1,'Electric Car','Electric car'),
(1,'Petrol Car','Petrol car'),
(1,'Diesel Car','Diesel car'),
(2,'Bike','For Daily Use'),
(3,'Sitting Chair','Normal Chair'),
(4,'table','For general use'),
(4,'Rotating Desk','For Work')
 
 INSERT INTO SubCategory
VALUES
(1,'Car'),
(1,'Bike'),
(2,'Chair'),
(2,'Desk')
 
INSERT INTO Category
VALUES
('Vehicle'),
('Office Items')

 