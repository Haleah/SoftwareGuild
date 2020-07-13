USE Master;
GO

IF EXISTS (SELECT * FROM sysdatabases WHERE name='GuildCars')
	DROP DATABASE GuildCars;
GO

CREATE DATABASE GuildCars;
GO

Use GuildCars
Go