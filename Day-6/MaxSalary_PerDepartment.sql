WITH RankedEmployees AS
(
    SELECT 
        Dept,
        Name,
        Salary,
        DENSE_RANK() OVER (PARTITION BY Dept ORDER BY Salary DESC) AS RankNum
    FROM Employees
)
SELECT Dept, Name, Salary
FROM RankedEmployees
WHERE RankNum = 1;
