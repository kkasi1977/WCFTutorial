USE WORKS

GO 


CREATE TABLE tblEmployee
(
	Id int,
	Name nvarchar(50), 
	Gender nvarchar(50), 
	DateOfBirth datetime
)

GO 


INSERT INTO tblEmployee VALUES (1, 'Mark', 'Male', '10/10/1980')
INSERT INTO tblEmployee VALUES (2, 'Mary', 'Female', '11/10/1981')
INSERT INTO tblEmployee VALUES (3, 'John', 'Male', '8/10/1979')

GO 

CREATE PROCEDURE spGetEmployee
	@Id INT 
AS 
BEGIN
	 SELECT 
			Id, 
			Name, 
			Gender, 
			DateOfBirth 
	 FROM tblEmployee 
	 WHERE Id = @Id
END 


GO 

CREATE PROCEDURE spSaveEmployee
	@Id INT, 
	@Name NVARCHAR(50), 
	@Gender NVARCHAR(50), 
	@DateOfBirth DATETIME 
AS 
BEGIN
	INSERT INTO tblEmployee 
	VALUES (@Id, @Name, @Gender, @DateOfBirth)  
END 	



 