WITH DeptAvg AS
(
    SELECT DeptId
    FROM Employees
    GROUP BY DeptId
    HAVING AVG(Salary) > 70000
),
RankedEmployees AS
(
    SELECT 
        d.DeptName,
        e.Salary AS HighestSalary,
        e.Name AS EmployeeName,
        DENSE_RANK() OVER (PARTITION BY e.DeptId ORDER BY e.Salary DESC) AS RankNum
    FROM Employees e
    JOIN Department d ON e.DeptId = d.DeptId
    WHERE e.DeptId IN (SELECT DeptId FROM DeptAvg)
)
SELECT DeptName, HighestSalary, EmployeeName
FROM RankedEmployees
WHERE RankNum = 1;
