SELECT 
    ProductId,
    SaleMonth,
    Amount,
    SUM(Amount) OVER (
        PARTITION BY ProductId 
        ORDER BY SaleMonth 
        ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW
    ) AS CumulativeSales
FROM Sales;
