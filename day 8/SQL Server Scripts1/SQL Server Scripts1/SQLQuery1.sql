
CREATE TABLE Employees (
    ID INT PRIMARY KEY,
    Name VARCHAR(50),
    Salary INT
);

INSERT INTO Employees (ID, Name, Salary) VALUES
(1, 'Ali', 5000),
(2, 'Sara', 7000),
(3, 'John', 6000),
(4, 'Mona', 9000),
(5, 'Ziad', 4500);
GO

CREATE PROCEDURE GetSecondHighestSalary
AS
BEGIN
    SELECT TOP 1 Name, Salary AS SecondHighestSalary
    FROM Employees
    WHERE Salary < (SELECT MAX(Salary) FROM Employees)
    ORDER BY Salary DESC;
END;
GO

EXEC GetSecondHighestSalary;
GO


CREATE PROCEDURE salarhigher
 @x FLOAT
AS 
BEGIN
    UPDATE Employees 
    SET Salary = Salary * @x;
END;
GO


EXEC salarhigher @x = 1.2;
GO

CREATE PROCEDURE UpdateSalaryByRange
AS
BEGIN
  
    UPDATE Employees
    SET Salary = Salary * 1.10
    WHERE Salary BETWEEN 5000 AND 6000;


    UPDATE Employees
    SET Salary = Salary * 1.15
    WHERE Salary BETWEEN 6001 AND 8000;

    UPDATE Employees
    SET Salary = Salary * 1.20
    WHERE Salary BETWEEN 8001 AND 15000;
END;
GO


EXEC UpdateSalaryByRange;
GO


SELECT Name, Salary FROM Employees;
