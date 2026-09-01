-- Performance Optimization Query & Index Creation

-- Recommended Solution:
-- Create a Non-Clustered Composite Index with CustomerId as the leading column and OrderDate as the secondary column.

CREATE NONCLUSTERED INDEX IX_Orders_CustomerId_OrderDate
ON Orders (CustomerId, OrderDate);

/*
Explanation & Rationale:

1. Index Type: Non-Clustered Composite Index.
   - The primary key (typically OrderId) usually already serves as the Clustered Index on the table.
   - A Non-Clustered Index provides a dedicated B-tree structure without reorganizing the physical storage of the 20-million row table.

2. Column Order: (CustomerId, OrderDate)
   - Equality Column First: CustomerId is filtered using equality (= 1254). Placing it first in the composite key allows SQL Server to perform an exact seek to the customer's subset of rows.
   - Range Column Second: OrderDate is filtered using an inequality/range (> '2024-01-01'). Placing it second allows an efficient range scan only within that customer's records.

3. Impact:
   - Eliminates the expensive Table Scan (scanning 20 million rows) and replaces it with an Index Seek (reading only a handful of pages), dramatically reducing I/O and query execution time from seconds to milliseconds.
*/
