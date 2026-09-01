-- Question 1: Normalization (3NF Schema)
CREATE TABLE Customers
(
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName VARCHAR(100) NOT NULL,
    CustomerPhone VARCHAR(20),
    CustomerCity VARCHAR(50)
);

CREATE TABLE SalesPersons
(
    SalesPersonID INT IDENTITY(1,1) PRIMARY KEY,
    SalesPersonName VARCHAR(100) NOT NULL
);

CREATE TABLE Products
(
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL
);

CREATE TABLE Orders
(
    OrderID INT PRIMARY KEY,
    OrderDate DATE NOT NULL,
    CustomerID INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerID),
    SalesPersonID INT NOT NULL FOREIGN KEY REFERENCES SalesPersons(SalesPersonID)
);

CREATE TABLE OrderItems
(
    OrderItemID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderID),
    ProductID INT NOT NULL FOREIGN KEY REFERENCES Products(ProductID),
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10,2) NOT NULL
);

-- Question 2: Third Highest Total Sales (Analytical Query)
WITH OrderTotals AS
(
    SELECT 
        OrderID,
        SUM(TRY_CAST(q.value AS DECIMAL(10,2)) * TRY_CAST(p.value AS DECIMAL(10,2))) AS TotalSales
    FROM Sales_Raw
    CROSS APPLY 
    (
        SELECT value, ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) AS rn 
        FROM STRING_SPLIT(Quantities, ',')
    ) q
    JOIN 
    (
        SELECT value, ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) AS rn 
        FROM STRING_SPLIT(UnitPrices, ',')
    ) p ON q.rn = p.rn
    GROUP BY OrderID
),
RankedOrders AS
(
    SELECT TotalSales, DENSE_RANK() OVER (ORDER BY TotalSales DESC) AS RankNum
    FROM OrderTotals
)
SELECT DISTINCT TotalSales
FROM RankedOrders
WHERE RankNum = 3;

-- Question 3: GROUP BY & HAVING (Salesperson with Total Sales > 60000)
WITH ParsedSales AS
(
    SELECT 
        SalesPerson,
        TRY_CAST(q.value AS DECIMAL(10,2)) * TRY_CAST(p.value AS DECIMAL(10,2)) AS ItemTotal
    FROM Sales_Raw
    CROSS APPLY 
    (
        SELECT value, ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) AS rn 
        FROM STRING_SPLIT(Quantities, ',')
    ) q
    JOIN 
    (
        SELECT value, ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) AS rn 
        FROM STRING_SPLIT(UnitPrices, ',')
    ) p ON q.rn = p.rn
)
SELECT SalesPerson, SUM(ItemTotal) AS TotalSales
FROM ParsedSales
GROUP BY SalesPerson
HAVING SUM(ItemTotal) > 60000;

-- Question 4: Subquery Usage (Customers spending above average)
WITH CustomerTotals AS
(
    SELECT 
        CustomerName,
        SUM(TRY_CAST(q.value AS DECIMAL(10,2)) * TRY_CAST(p.value AS DECIMAL(10,2))) AS TotalSpent
    FROM Sales_Raw
    CROSS APPLY 
    (
        SELECT value, ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) AS rn 
        FROM STRING_SPLIT(Quantities, ',')
    ) q
    JOIN 
    (
        SELECT value, ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) AS rn 
        FROM STRING_SPLIT(UnitPrices, ',')
    ) p ON q.rn = p.rn
    GROUP BY CustomerName
)
SELECT CustomerName, TotalSpent
FROM CustomerTotals
WHERE TotalSpent > (SELECT AVG(TotalSpent) FROM CustomerTotals);

-- Question 5: String & Date Functions (Uppercase name, month, filter Jan 2026)
SELECT 
    UPPER(CustomerName) AS CustomerName_Uppercase,
    MONTH(TRY_CAST(OrderDate AS DATE)) AS OrderMonth,
    OrderDate
FROM Sales_Raw
WHERE TRY_CAST(OrderDate AS DATE) >= '2026-01-01' AND TRY_CAST(OrderDate AS DATE) <= '2026-01-31';
