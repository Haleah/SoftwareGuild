USE GuildCars
GO


DROP TABLE IF EXISTS Purchase;

CREATE TABLE [Purchase]
(
 [purchaseId]    int IDENTITY(1,1) PRIMARY KEY,
 [name]          varchar(254) NOT NULL ,
 [email]         varchar(254) NOT NULL ,
 [streetOne]     varchar(254) NOT NULL ,
 [streetTwo]     varchar(254) NOT NULL ,
 [city]          varchar(60) NOT NULL ,
 [zipcode]       char(10) NOT NULL ,
 [phone]         varchar(15) NOT NULL ,
 [purchasePrice] decimal(9,2) NOT NULL ,
 [purchaseType]  varchar(50) NOT NULL ,
 [purchaseDate]  datetime2(7) NOT NULL ,
 [vehicleId]     int NOT NULL ,
 [employeeId]        int NOT NULL ,



 CONSTRAINT [FK_Purchase_Vehicle_vehicleId] FOREIGN KEY ([vehicleId])  REFERENCES [Vehicle]([vehicleId]),
 CONSTRAINT [FK_Purchase_Employee_employeeIdId] FOREIGN KEY ([employeeId])  REFERENCES [Employee]([employeeId])
);
GO


DROP TABLE IF EXISTS Vehicle;

CREATE TABLE [Vehicle]
(
 [vehicleId]    int IDENTITY(1,1) PRIMARY KEY,
 [vin]          varchar(50) NOT NULL ,
 [year]         char(10) NOT NULL ,
 [bodyStyle]    char(10) NOT NULL ,
 [transmission] char(10) NOT NULL ,
 [type]         char(10) NOT NULL ,
 [mileage]      int NOT NULL ,
 [color]        varchar(50) NOT NULL ,
 [interior]     varchar(50) NOT NULL ,
 [description]  varchar(254) NOT NULL ,
 [msrp]         decimal(9,2) NOT NULL ,
 [salePrice]    decimal(9,2) NOT NULL ,
 [modelId]      int NOT NULL ,



 CONSTRAINT [FK_Vehicle_Model_model] FOREIGN KEY ([modelId])  REFERENCES [Model]([modelId])
);
GO


DROP TABLE IF EXISTS Model;

CREATE TABLE [Model]
(
 [modelId]   int IDENTITY(1,1) PRIMARY KEY,
 [model]     varchar(50) NOT NULL ,
 [dateAdded] datetime2 NOT NULL ,
 [makeId]    int NOT NULL,
 [employeeId]    int NOT NULL ,


 CONSTRAINT [FK_Model_Make_makeId]FOREIGN KEY ([makeId]) REFERENCES[Make]([makeId]),
 CONSTRAINT [FK_Model_Employee_employeeId] FOREIGN KEY ([employeeId])  REFERENCES [Employee]([employeeId])
);
GO

DROP TABLE IF EXISTS Make;

CREATE TABLE [Make]
(
 [makeId]    int IDENTITY(1,1) PRIMARY KEY ,
 [make]      varchar(50) NOT NULL ,
 [dateAdded] datetime2(7) NOT NULL ,
 [employeeId] int NOT NULL,



 CONSTRAINT [FK_Make_Employee_employeeId] FOREIGN KEY ([employeeId])  REFERENCES [Employee]([employeeId]),

);
GO


DROP TABLE IF EXISTS Employee;

CREATE TABLE [Employee]
(
 [employeeId] int IDENTITY(1,1) PRIMARY KEY,
 [lastName]  varchar(50) NOT NULL ,
 [firstName] varchar(50) NOT NULL ,
 [email]     varchar(254) NOT NULL ,
 [role]      varchar(50) NOT NULL ,

);
GO



DROP TABLE IF EXISTS Specials;

CREATE TABLE [Specials]
(
 [specialId]   int IDENTITY(1,1) PRIMARY KEY,
 [title]       varchar(50) NOT NULL ,
 [description] varchar(max) NOT NULL ,



);
GO


DROP TABLE IF EXISTS Contact;

CREATE TABLE [Contact]
(
 [contactId]   int IDENTITY(1,1) PRIMARY KEY,
 [name]        varchar(100) NOT NULL ,
 [email]       varchar(100) NOT NULL ,
 [phoneNumber] varchar(15) NOT NULL ,
 [message]     varchar(254) NOT NULL ,



);
GO







































