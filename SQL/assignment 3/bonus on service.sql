SELECT * FROM bonus_on_service
WHERE (Ser_Type = 1 AND Emp_Type = 1 AND Ser_Years >= 10 AND Ser_YearsLeft >= 15 AND age >= 60)
OR (Ser_Type = 1 AND Emp_Type = 2 AND Ser_Years >= 12 AND Ser_YearsLeft >= 14 AND age >= 55)
OR (Ser_Type = 1 AND Emp_Type = 3 AND Ser_Years >= 12 AND Ser_YearsLeft >= 12 AND age >= 55)
OR (Ser_Type IN (2, 3, 4) AND Ser_Years >= 15 AND Ser_YearsLeft >= 20 AND age >= 65)