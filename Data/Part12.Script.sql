
Select * from tblEmployee

Alter table tblEmployee Add City nvarchar(50)



GO

ALTER PROCEDURE [dbo].[spGetEmployee] 
@Id int 
AS 
BEGIN
	SELECT Id, Name, Gender, DateOfBirth, EmployeeType, AnnualSalary, HourlyPay, HoursWorked, City 
	FROM  tblEmployee 
	WHERE Id = @id
END 




GO

ALTER PROCEDURE [dbo].[spSaveEmployee]
	@Id int, 
	@Name nvarchar(50), 
	@Gender nvarchar(50), 
	@DateOfBirth DateTime, 
	@EmployeeType int, 
	@AnnualSalary int = null, 
	@HourlyPay int = null, 
	@HoursWorked int = null, 
	@City nvarchar(50) = null 
AS 
BEGIN 
	INSERT INTO 	tblEmployee 
	VALUES (@Id, @Name, @Gender, @DateOfBirth, @EmployeeType, @AnnualSalary, @HourlyPay, @HoursWorked, @City) 
END 




