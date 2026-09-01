SELECT EmpId, [Jan], [Feb], [Mar], [Apr], [May], [Jun], [Jul], [Aug], [Sep], [Oct], [Nov], [Dec]
FROM
(
    SELECT EmpId, Month, TotalPresent
    FROM Attendance
) AS SourceTable
PIVOT
(
    SUM(TotalPresent)
    FOR Month IN ([Jan], [Feb], [Mar], [Apr], [May], [Jun], [Jul], [Aug], [Sep], [Oct], [Nov], [Dec])
) AS PivotTable;
