-- INSERT

-- 1. Add Klingon as a spoken language in the USA

--DELETE FROM countrylanguage WHERE language = 'Klingon'; 
--Select * From countrylanguage Where language = 'Klingon';

--Update countrylanguage
--Set isofficial = 1, percentage = .5
--Where language = 'Klingon';

--INSERT INTO countrylanguage (countrycode, language, isofficial, percentage)
--VALUES ('USA', 'Klingon', 0, .001);

-- 2. Add Klingon as a spoken language in Great Britain
--INSERT INTO countrylanguage (countrycode, language, isofficial, percentage)
--VALUES ('GBR', 'Klingon', 1, 1.0);


--BEGIN TRANSACTION
BEGIN TRY

INSERT INTO countrylanguage (countrycode, language, isofficial, percentage)
VALUES ('USA', 'Klingon', 0, .01);

INSERT INTO countrylanguage (countrycode, language)
VALUES ('GBR', 'Klingon');

--COMMIT TRANSACTION
END TRY

BEGIN CATCH
--ROLLBACK TRANSACTION
END CATCH


--DELETE FROM countrylanguage WHERE language = 'Klingon'; 
Select * From countrylanguage Where language = 'Klingon';

--COMMIT TRANSACTION
--ROLLBACK TRANSACTION

--Select * From countrylanguage Where language = 'Klingon';


--Select * From countrylanguage Where language = 'Klingon';

-- UPDATE

-- 1. Update the capital of the USA to Houston
--Select city.* From country Join city On country.capital = city.id
--WHERE code = 'USA';

--Select * From city Where name like('%Washington%');

--UPDATE country
--SET capital = 3813
--WHERE code = 'USA';

-- 2. Update the capital of the USA to Washington DC and the head of state


-- DELETE

-- 1. Delete English as a spoken language in the USA
-- 2. Delete all occurrences of the Klingon language 


-- REFERENTIAL INTEGRITY

-- 1. Try just adding Elvish to the country language table.
--INSERT INTO countrylanguage (language)
--VALUES ('Elvish');

-- 2. Try inserting English as a spoken language in the country ZZZ. What happens?

-- 3. Try deleting the country USA. What happens?


-- CONSTRAINTS

-- 1. Try inserting English as a spoken language in the USA

-- 2. Try again. What happens?

-- 3. Let's relocate the USA to the continent - 'Outer Space'


-- How to view all of the constraints

--SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
--SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
--SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS


-- TRANSACTIONS

-- 1. Try deleting all of the rows from the country language table and roll it back.

-- 2. Try updating all of the cities to be in the USA and roll it back

-- 3. Demonstrate two different SQL connections trying to access the same table where one happens to be inside of a transaction but hasn't committed yet.
/*
BEGIN TRANSACTION
DELETE FROM countrylanguage WHERE language = 'Klingon';  
INSERT INTO countrylanguage (countrycode, language, isofficial, percentage)
VALUES ('USA', 'Klingon', 0, .01);
COMMIT TRANSACTION
*/