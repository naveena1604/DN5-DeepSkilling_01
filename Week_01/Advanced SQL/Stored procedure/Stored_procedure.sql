-- Drop and Create Database
DROP DATABASE IF EXISTS EmployeeManagement;

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
    EmployeeID INT AUTO_INCREMENT PRIMARY KEY,
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
(2,'Finance'),
(3,'IT'),
(4,'Marketing');

INSERT INTO Employees
(FirstName, LastName, DepartmentID, Salary, JoinDate)
VALUES
('John','Doe',1,5000.00,'2020-01-15'),
('Jane','Smith',2,6000.00,'2019-03-22'),
('Michael','Johnson',3,7000.00,'2018-07-30'),
('Emily','Davis',4,5500.00,'2021-11-05'),
('Robert','Brown',3,7500.00,'2022-05-12'),
('Sophia','Wilson',1,5200.00,'2021-09-18');

-- ==========================================
-- View Data
-- ==========================================

SELECT * FROM Departments;

SELECT * FROM Employees;

-- ==========================================
-- EXERCISE 1
-- Create Stored Procedure to Retrieve Employees
-- by Department
-- ==========================================

DELIMITER $$

CREATE PROCEDURE sp_GetEmployeesByDepartment
(
    IN p_DepartmentID INT
)
BEGIN

    SELECT
        EmployeeID,
        FirstName,
        LastName,
        DepartmentID,
        Salary,
        JoinDate

    FROM Employees

    WHERE DepartmentID = p_DepartmentID;

END $$

DELIMITER ;

-- ==========================================
-- EXERCISE 4
-- Execute Stored Procedure
-- ==========================================

CALL sp_GetEmployeesByDepartment(1);

CALL sp_GetEmployeesByDepartment(2);

CALL sp_GetEmployeesByDepartment(3);

CALL sp_GetEmployeesByDepartment(4);

-- ==========================================
-- EXERCISE 5
-- Stored Procedure to Return Total Employees
-- in a Department
-- ==========================================

DELIMITER $$

CREATE PROCEDURE sp_TotalEmployeesInDepartment
(
    IN p_DepartmentID INT
)
BEGIN

    SELECT
        DepartmentID,
        COUNT(*) AS TotalEmployees

    FROM Employees

    WHERE DepartmentID = p_DepartmentID

    GROUP BY DepartmentID;

END $$

DELIMITER ;

-- ==========================================
-- Execute Exercise 5
-- ==========================================

CALL sp_TotalEmployeesInDepartment(1);

CALL sp_TotalEmployeesInDepartment(2);

CALL sp_TotalEmployeesInDepartment(3);

CALL sp_TotalEmployeesInDepartment(4);