USE GuildCars
GO



DROP PROCEDURE IF EXISTS CreateVehicle
GO

CREATE PROCEDURE CreateVehicle(
    @vin varchar (50),
	@year char (10),
	@bodyStyle char (10),
	@transmission char (10),
	@type char (10),
	@mileage int,
	@color varchar(50),
	@interior varchar (50),
	@description varchar (254),
	@msrp decimal (9,2),
	@salePrice decimal (9,2),
	@modelId int  
)
AS

INSERT INTO Vehicle(Vehicle.vin, Vehicle.year, Vehicle.bodyStyle, Vehicle.transmission, Vehicle.type, Vehicle.mileage, Vehicle.color, Vehicle.interior, Vehicle.description, Vehicle.msrp, Vehicle.salePrice, 
                         Vehicle.modelId)
	VALUES( @vin, @year, @bodyStyle, @transmission, @type, @mileage, @color, @interior, @description, @msrp, @salePrice, @modelId)
 
GO


DROP PROCEDURE IF EXISTS ReadAllVehicle
GO

CREATE PROCEDURE ReadAllVehicle
AS

SELECT        Vehicle.vehicleId, Vehicle.vin, Vehicle.year, Vehicle.bodyStyle, Vehicle.transmission, Vehicle.type, Vehicle.mileage, Vehicle.color, Vehicle.interior, Vehicle.description, Vehicle.msrp, Vehicle.salePrice, Make.makeId, 
                         Model.modelId, Make.make, Model.model
FROM            Vehicle INNER JOIN
                         
                         Model ON Vehicle.modelId = Model.modelId INNER JOIN
						 Make ON Model.makeId = Make.makeId 
 
GO



DROP PROCEDURE IF EXISTS ReadByVehicleId

GO


CREATE PROCEDURE ReadByVehicleId(
    @VehicleId int
)
AS

	SELECT        Vehicle.vehicleId, Vehicle.vin, Vehicle.year, Vehicle.bodyStyle, Vehicle.transmission, Vehicle.type, Vehicle.mileage, Vehicle.color, Vehicle.interior, Vehicle.description, Vehicle.msrp, Vehicle.salePrice, Make.makeId, 
                         Model.modelId, Make.make, Model.model
FROM            Vehicle INNER JOIN
                         
                         Model ON Vehicle.modelId = Model.modelId INNER JOIN
						 Make ON Model.makeId = Make.makeId 
						 WHERE VehicleId LIKE @vehicleId
 
GO


DROP PROCEDURE IF EXISTS UpdateVehicle
GO

CREATE PROCEDURE UpdateVehicle(
	@vehicleId int,
    @vin varchar (50),
	@year char (10),
	@bodyStyle char (10),
	@transmission char (10),
	@type char (10),
	@mileage int,
	@color varchar(50),
	@interior varchar (50),
	@description varchar (254),
	@msrp decimal (9,2),
	@salePrice decimal (9,2),
	@modelId int
)
AS

UPDATE vehicle
SET vin = @vin, year= @year, bodyStyle = @bodyStyle, transmission = @transmission, type = @type, mileage = @mileage, color = @color, interior = @interior, 
description = @description, msrp = @msrp, salePrice = @salePrice,modelId = @modelId
WHERE @vehicleId = vehicleId
 
GO


DROP PROCEDURE IF EXISTS DeleteVehicle
GO

CREATE PROCEDURE DeleteVehicle(
	@vehicleId int
)

AS

BEGIN
DELETE FROM Purchase
WHERE purchase.vehicleId = @vehicleId;
DELETE FROM Vehicle 
WHERE vehicleId= @vehicleId;

END

GO



DROP PROCEDURE IF EXISTS CreateEmployee
GO

CREATE PROCEDURE CreateEmployee(
    @lastName varchar (50),
	@firstName varchar (50),
	@email varchar (254),
	@role varchar (50)
)
AS

INSERT INTO Employee(lastName, firstName, email, role)
	VALUES(@lastName, @firstName, @email, @role)
 
GO


DROP PROCEDURE IF EXISTS ReadAllEmployee
GO



CREATE PROCEDURE ReadAllEmployee
AS

SELECT * FROM Employee
 
GO

DROP PROCEDURE IF EXISTS ReadByEmployeeId
GO



CREATE PROCEDURE ReadByEmployeeId(
    @employeeId int
)
AS

	SELECT * FROM Employee WHERE employeeId LIKE @employeeId
 
GO


DROP PROCEDURE IF EXISTS UpdateEmployee
GO


CREATE PROCEDURE UpdateEmployee(
	@employeeId int,
    @lastName varchar (50),
	@firstName varchar (50),
	@email varchar (254),
	@role varchar (50)
)
AS

UPDATE Employee
SET lastName = @lastName, firstName = @firstName, email = @email, role = @role
WHERE @employeeId = employeeId
 
GO


DROP PROCEDURE IF EXISTS DeleteEmployee
GO


CREATE PROCEDURE DeleteEmployee(
	@employeeId int
	)
AS

BEGIN
DELETE FROM Purchase
WHERE purchase.employeeId = @employeeId;
DELETE FROM Model
WHERE model.employeeId = @employeeId;
DELETE FROM Make
WHERE make.employeeId = @employeeId;
DELETE FROM Employee 
WHERE employeeId= @employeeId;

END

GO



DROP PROCEDURE IF EXISTS CreatePurchase
GO

CREATE PROCEDURE CreatePurchase(
	@name varchar (254),
	@email varchar (254),
	@streetOne varchar (254),
	@streetTwo varchar (254),
	@city varchar (60),
	@zipcode char (10),
	@phone varchar (15),
	@purchasePrice decimal (9,2),
	@purchaseType varchar (50),
	@purchaseDate DateTime2 (7),
	@vehicleId int,
	@employeeId int
)
AS

INSERT INTO Purchase(name, email, streetOne, streetTwo, city, zipcode, phone, purchasePrice, purchaseType, purchaseDate, vehicleId, employeeId)
	VALUES(@name, @email, @streetOne, @streetTwo, @city, @zipcode, @phone, @purchasePrice, @purchaseType, @purchaseDate, @vehicleId, @employeeId)
 
GO

DROP PROCEDURE IF EXISTS ReadAllPurchase
GO


CREATE PROCEDURE ReadAllPurchase
AS

SELECT * FROM Purchase
 
GO

DROP PROCEDURE IF EXISTS ReadByPurchaseId
GO


CREATE PROCEDURE ReadByPurchaseId(
    @purchaseId int
)
AS

	SELECT * FROM Purchase WHERE purchaseId LIKE @purchaseId
 
GO

DROP PROCEDURE IF EXISTS UpdatePurchase
GO




CREATE PROCEDURE UpdatePurchase(
	@purchaseId int,
	@name varchar (254),
	@email varchar (254),
	@streetOne varchar (254),
	@streetTwo varchar (254),
	@city varchar (60),
	@zipcode char (10),
	@phone varchar (15),
	@purchasePrice decimal (9,2),
	@purchaseType varchar (50),
	@purchaseDate DateTime2 (7),
	@vehicleId int,
	@employeeId int
)
AS

UPDATE Purchase
SET name = @name, email = @email, streetOne = @streetOne, streetTwo = @streetTwo, city = @city, zipcode = @zipcode, phone = @phone, 
	purchasePrice = @purchasePrice, purchaseType = @purchaseType, purchaseDate = @purchaseDate, vehicleId = @vehicleId, employeeId = @employeeId
WHERE @purchaseId = purchaseId
 
GO



DROP PROCEDURE IF EXISTS DeletePurchase
GO


CREATE PROCEDURE DeletePurchase(
	@purchaseId int
)
AS

DELETE FROM Purchase 
WHERE purchaseId= @purchaseId;

GO



DROP PROCEDURE IF EXISTS CreateSpecials
GO

CREATE PROCEDURE CreateSpecials(
	@title varchar (50),
	@description varchar (max)
)
AS

INSERT INTO Specials( title, description)
	VALUES( @title, @description)
 
GO


DROP PROCEDURE IF EXISTS ReadAllSpecials
GO

CREATE PROCEDURE ReadAllSpecials
AS

SELECT * FROM Specials
 
GO

DROP PROCEDURE IF EXISTS ReadBySpecialId
GO


CREATE PROCEDURE ReadBySpecialId(
    @specialId int
)
AS

	SELECT * FROM Specials WHERE specialId LIKE @specialId
 
GO


DROP PROCEDURE IF EXISTS UpdateSpecials
GO


CREATE PROCEDURE UpdateSpecials(
	@specialId int,
	@title varchar (50),
	@description varchar (max)
)
AS

UPDATE Specials
SET title = @title, description = @description
WHERE @specialId = specialId
 
GO

DROP PROCEDURE IF EXISTS DeleteSpecials
GO


CREATE PROCEDURE DeleteSpecials(
	@specialId int
)
AS

DELETE FROM Specials 
WHERE specialId= @specialId;

GO



DROP PROCEDURE IF EXISTS CreateMake
GO


CREATE PROCEDURE CreateMake(
	@make varchar (50),
	@dateAdded DateTime2 (7),
	@employeeId int
)
AS

INSERT INTO Make(make, dateAdded, employeeId)
	VALUES(@make, @dateAdded, @employeeId)
 
GO

DROP PROCEDURE IF EXISTS ReadAllMake
GO


CREATE PROCEDURE ReadAllMake
AS

SELECT * FROM Make
 
GO

DROP PROCEDURE IF EXISTS ReadByMakeId
GO


CREATE PROCEDURE ReadByMakeId(
    @makeId int
)
AS

	SELECT * FROM Make WHERE makeId LIKE @makeId
 
GO

DROP PROCEDURE IF EXISTS UpdateMake
GO


CREATE PROCEDURE UpdateMake(
	@makeId int,
	@make varchar (50),
	@dateAdded DateTime2 (7),
	@employeeId int
)
AS

UPDATE Make
SET make = @make, dateAdded = @dateAdded, employeeId = @employeeId
WHERE @makeId = makeId
 
GO



DROP PROCEDURE IF EXISTS CreateModel
GO

CREATE PROCEDURE CreateModel(
	@model varchar (50),
	@dateAdded DateTime2 (7),
	@makeId int,
	@EmployeeId int
)
AS

INSERT INTO Model(model, dateAdded, makeId, employeeId)
	VALUES( @model, @dateAdded, @makeId, @employeeId)
 
GO


DROP PROCEDURE IF EXISTS ReadAllModel
GO

CREATE PROCEDURE ReadAllModel
AS

SELECT * FROM Model
 
GO

DROP PROCEDURE IF EXISTS ReadByModelId
GO


CREATE PROCEDURE ReadByModelId(
    @modelId int
)
AS

	SELECT * FROM Model WHERE modelId LIKE @modelId
 
GO

DROP PROCEDURE IF EXISTS UpdateModel
GO



CREATE PROCEDURE UpdateModel(
	@modelId int,
	@model varchar (50),
	@dateAdded DateTime2 (7),
	@makeId int,
	@EmployeeId int
)
AS

UPDATE Model
SET model = @model, dateAdded = @dateAdded, makeId = @makeId, employeeId = @employeeId
WHERE @modelId = modelId
 
GO

DROP PROCEDURE IF EXISTS CreateContact
GO

CREATE PROCEDURE CreateContact(
	@name        varchar(100),
	@email       varchar(100),
	@phoneNumber varchar(15),
	@message    varchar(254) 
)
AS

INSERT INTO Contact(name, email, phoneNumber, message)
	VALUES( @name, @email, @phoneNumber, @message)
 
GO
