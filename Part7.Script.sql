

/* 
SELECT * FROM tblEmployee 

*/

GO

IF EXISTS(SELECT 0 FROM tblEmployee)
BEGIN 
		Delete from tblEmployee 
END 
GO


/*
Alter table tblEmployee Add 
EmployeeType int, AnnualSalary int, HourlyPay int, HoursWorked int; 
*/

GO

ALTER PROCEDURE spGetEmployee 
@Id int 
AS 
BEGIN
	SELECT Id, Name, Gender, DateOfBirth, EmployeeType, AnnualSalary, HourlyPay, HoursWorked 
	FROM  tblEmployee 
	WHERE Id = @id
END 


GO

ALTER PROCEDURE spSaveEmployee
	@Id int, 
	@Name nvarchar(50), 
	@Gender nvarchar(50), 
	@DateOfBirth DateTime, 
	@EmployeeType int, 
	@AnnualSalary int = null, 
	@HourlyPay int = null, 
	@HoursWorked int = null 
AS 
BEGIN 
	INSERT INTO 	tblEmployee 
	VALUES (@Id, @Name, @Gender, @DateOfBirth, @EmployeeType, @AnnualSalary, @HourlyPay, @HoursWorked) 
END 
