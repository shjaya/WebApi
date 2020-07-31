CREATE DATABASE ItemsStore
 
GO 
 
USE  ItemsStore
 
GO 
 
CREATE TABLE Category 
  ( 
     Id   BIGINT IDENTITY(1, 1) NOT NULL, 
     NAME NVARCHAR(50) NOT NULL, 
     PRIMARY KEY (Id) 
  ) 
 
GO 
 
CREATE TABLE SubCategory 
  ( 
     Id      BIGINT NOT NULL, 
     CategoryId BIGINT NULL, 
     Name       NVARCHAR(100) NULL, 
     PRIMARY KEY (Id), 
     FOREIGN KEY (CategoryId) REFERENCES Category(Id) 
  ) 
 
GO 
 
CREATE TABLE Item 
  ( 
     Id   BIGINT NOT NULL, 
	 SubCategoryId BIGINT NULL,
     NAME NVARCHAR(50) NULL, 
     DESCRIPTION NVARCHAR(50) NULL, 
     PRIMARY KEY (Id),
FOREIGN KEY (SubCategoryId) REFERENCES SubCategory(Id) 	 
  ) 
 
GO 

Use ItemsStore
Go
INSERT INTO Item
VALUES
(1,1,'Sports Car','For Sports Purpose'),
(2,2,'Regular Bike','For Daily Use'),
(3,3,'Office Chair','Normal Chair'),
(4,4,'Standing Desk','For Standing Work')
 
 INSERT INTO SubCategory
VALUES
(1,1,'Car'),
(2,1,'Bike'),
(3,2,'Chair'),
(4,2,'Desk')
 
INSERT INTO Category
VALUES
(1,'Vehicle'),
(2,'Office Items')

 