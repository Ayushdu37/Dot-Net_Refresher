-- Method 1: Using NOT EXISTS (Recommended)
SELECT oi.*
FROM OrderItems oi
WHERE NOT EXISTS (
    SELECT 1 
    FROM Orders o 
    WHERE o.OrderId = oi.OrderId
);

-- Method 2: Using LEFT JOIN
SELECT oi.*
FROM OrderItems oi
LEFT JOIN Orders o ON oi.OrderId = o.OrderId
WHERE o.OrderId IS NULL;
