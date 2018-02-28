-- ORDERING RESULTS

-- Populations of all countries in descending order
--SELECT name, population FROM country ORDER BY population DESC 

--Names of countries and continents in ascending order
--SELECT name, continent FROM country ORDER BY continent ASC, name ASC




-- LIMITING RESULTS
-- The name and average life expectancy of the countries with the 10 highest life expectancies.

-- Postgres
/*
SELECT name, lifeexpectancy 
FROM country 
WHERE lifeexpectancy IS NOT NULL 
ORDER BY lifeexpectancy DESC 
LIMIT 10;
*/

-- SQL

/*
SELECT TOP 10 name, lifeexpectancy 
FROM country 
WHERE lifeexpectancy IS NOT NULL 
ORDER BY lifeexpectancy DESC;
*/


-- CONCATENATING OUTPUTS

-- The name & state of all cities in California, Oregon, or Washington. 
-- "city, state", sorted by state then city

-- Postgres
/*
SELECT (name || ', ' || district) as name_and_state 
FROM city 
WHERE district='California' OR district='Oregon' OR district='Washington' 
ORDER BY district, name;
*/

-- SQL

/*
SELECT (name + ', ' + district) as name_and_state 
FROM city 
WHERE district='California' OR district='Oregon' OR district='Washington' 
ORDER BY district, name;
*/



-- AGGREGATE FUNCTIONS
-- Average Life Expectancy in the World
--SELECT AVG(lifeexpectancy) FROM country;

-- Total population in Ohio
--SELECT SUM(population) FROM city WHERE name = 'Cincinnati';

-- The surface area of the smallest country in the world
--SELECT MAX(surfacearea) FROM country;

-- The 10 largest countries in the world
-- Postgres
--SELECT * FROM country ORDER BY surfacearea DESC LIMIT 10;
-- SQL
--SELECT TOP 10 * FROM country ORDER BY surfacearea DESC

-- The number of countries who declared independence in 1991
--SELECT COUNT(*) as independence FROM country Where indepyear = 1991;
--SELECT MIN(2018 - indepyear) as year_since, name FROM country WHERE indepyear IS NOT NULL GROUP BY name
--SELECT MAX(population) as min_pop, countrycode FROM city Group By countrycode Order By countrycode ASC
--SELECT TOP 1 population as min_pop, countrycode FROM city Order By population ASC
--SELECT AVG(population) as avg_pop, MIN(population) as min_pop, MAX(population) as max_pop, name FROM city Group By name


-- GROUP BY EXERCISES
-- Count the number of countries where each language is spoken, order show them from most countries to least
/*
select language, count(countrycode) as countries 
from countrylanguage 
group by language 
order by countries desc;
*/

-- Average life expectancy of each continent ordered from highest to lowest
--select continent, avg(lifeexpectancy) as avg_lifeexpectancy from country group by continent order by avg_lifeexpectancy desc;

-- Exclude Antarctica from consideration for average life expectancy
--select continent, avg(lifeexpectancy) as avg_lifeexpectancy from country where continent <> 'Antarctica' group by continent order by avg_lifeexpectancy desc;

-- Sum of the population of cities in each state in the USA ordered by state name
--select sum(population) as population from city where countrycode='USA';

-- The average population of cities in each state in the USA ordered by state name
--select district, avg(population) from city where countrycode='USA' group by district order by district;
--Select population, district, countrycode From city 
--WHERE countrycode = (Select TOP 1 code FROM country WHERE continent = 'Asia');

Select TOP 1 code FROM country WHERE continent = 'Asia'

--Select code FROM country WHERE code = 'AFG'
--Select population, district, countrycode FROM city WHERE countrycode = 'AFG'
--Select population, district, countrycode FROM city WHERE countrycode = 'AFG' OR countrycode = 'NLD'

-- Additional samples
-- You may alias column and table names to provide more descriptive names
--SELECT name AS CityName FROM city AS cities;

-- Alias can also be used to create shorthand references, such c for city and co for country.
--SELECT c.name as City, co.name as Country FROM city AS c, country AS co;

-- Ordering allows columns to be displayed in ascending order, or descending order (Look at Arlington)
--SELECT name, population FROM city WHERE countryCode='USA' ORDER BY name ASC, population DESC;

-- Limiting results allows rows to be returned in 'limited' clusters where LIMIT says how many, and an optional OFFSET specifies number of rows to skip
--SELECT name, population FROM city LIMIT 10 OFFSET 10;

-- Postgres has a number of string functions like SUBSTR. It also supports string concatenation, so we can build completed sentences if desired
--SELECT (name || ' is in the state of ' || district) AS city_state FROM city WHERE countryCode='USA';

-- Aggregate functions provide the ability to COUNT, SUM, AVG, and determine MIN and MAX. Only returns a single row of value(s).
--SELECT COUNT(name) AS city_count FROM city;  -- Counts the number of rows
--SELECT COUNT(population) FROM city;		-- Counts the number of rows
--SELECT SUM(population) AS total_city_population, COUNT(population) as number_of_cities, AVG(population) AS avergage_population FROM city;
--SELECT MIN(population) AS smallest_population, MAX(population) AS largest_population FROM city;

-- GROUP BY clusters rows by a column value
--SELECT  countrycode, MIN(population), MAX(population) FROM city GROUP BY countrycode;
