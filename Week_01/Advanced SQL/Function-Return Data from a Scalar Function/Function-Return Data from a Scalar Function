DROP DATABASE IF EXISTS EmployeeManagement;

-- Create Database
CREATE DATABASE EmployeeManagement;

USE EmployeeManagement;

-- ==========================================
-- Create Tables
-- ==========================================

CREATE TABLE Departments
(
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

CREATE TABLE Employees
(
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT,
    Salary DECIMAL(10,2),
    JoinDate DATE,
    FOREIGN KEY (DepartmentID)
    REFERENCES Departments(DepartmentID)
);

-- ==========================================
-- Insert Sample Data
-- ==========================================

INSERT INTO Departments
VALUES
(1,'HR'),
(2,'IT'),
(3,'Finance');

INSERT INTO Employees
VALUES
(1,'John','Doe',1,5000.00,'2020-01-15'),
(2,'Jane','Smith',2,6000.00,'2019-03-22'),
(3,'Bob','Johnson',3,5500.00,'2021-07-01');

-- ==========================================
-- Exercise 1 (Required for Exercise 7)
-- Create Scalar Function
-- ==========================================

DELIMITER $$

CREATE FUNCTION fn_CalculateAnnualSalary
(
    p_Salary DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
DETERMINISTIC
BEGIN

    RETURN p_Salary * 12;

END $$

DELIMITER ;

-- ==========================================
-- Exercise 7
-- Return Annual Salary for EmployeeID = 1
-- ==========================================

SELECT
    EmployeeID,
    FirstName,
    LastName,
    Salary,
    fn_CalculateAnnualSalary(Salary) AS AnnualSalary
FROM Employees
WHERE EmployeeID = 1;