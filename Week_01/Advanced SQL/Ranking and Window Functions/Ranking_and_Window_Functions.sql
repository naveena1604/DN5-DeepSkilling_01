CREATE DATABASE OnlineRetailStore;
USE OnlineRetailStore;
CREATE TABLE Products
(
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);
INSERT INTO Products
VALUES
(101, 'Laptop', 'Electronics', 80000),
(102, 'Smartphone', 'Electronics', 65000),
(103, 'Tablet', 'Electronics', 65000),
(104, 'Headphones', 'Electronics', 5000),
(105, 'Smart Watch', 'Electronics', 12000),

(201, 'Refrigerator', 'Home Appliances', 55000),
(202, 'Washing Machine', 'Home Appliances', 42000),
(203, 'Microwave', 'Home Appliances', 15000),
(204, 'Air Conditioner', 'Home Appliances', 55000),
(205, 'Vacuum Cleaner', 'Home Appliances', 9000),

(301, 'Novel', 'Books', 500),
(302, 'Dictionary', 'Books', 1200),
(303, 'Magazine', 'Books', 250),
(304, 'Encyclopedia', 'Books', 1200),
(305, 'Comic Book', 'Books', 350);
SELECT *
FROM Products;

SELECT
    ProductID,
    ProductName,
    Category,
    Price,
    ROW_NUMBER() OVER (
        PARTITION BY Category
        ORDER BY Price DESC
    ) AS RowNum
FROM Products;

SELECT
    ProductID,
    ProductName,
    Category,
    Price,
    RANK() OVER (
        PARTITION BY Category
        ORDER BY Price DESC
    ) AS ProductRank
FROM Products;

SELECT
    ProductID,
    ProductName,
    Category,
    Price,
    DENSE_RANK() OVER (
        PARTITION BY Category
        ORDER BY Price DESC
    ) AS DenseRank
FROM Products;

WITH ProductRanking AS
(
    SELECT
        ProductID,
        ProductName,
        Category,
        Price,
        ROW_NUMBER() OVER (
            PARTITION BY Category
            ORDER BY Price DESC
        ) AS RowNum
    FROM Products
)

SELECT *
FROM ProductRanking
WHERE RowNum <= 3
ORDER BY Category, RowNum; 