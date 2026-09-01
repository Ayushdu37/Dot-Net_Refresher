DELETE FROM Students
WHERE NOT EXISTS (
    SELECT 1 
    FROM Marks m 
    WHERE m.StudentId = Students.StudentId
);
