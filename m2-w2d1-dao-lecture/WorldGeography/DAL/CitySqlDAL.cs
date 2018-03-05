using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public class CitySqlDAL
    {
        private const string SQL_CountryCodeCities = "SELECT * FROM city WHERE countryCode = @countrycode ORDER BY city.district, city.name;";
        private const string SQL_GreaterThanPopulationCount = "SELECT * FROM city WHERE city.population > @population;";
        private const string SQL_AddCity = "Insert Into city (id, name, countrycode, district, population) Values (@id, @name, @countrycode, @district, @population);";

        private string connectionString;

        public CitySqlDAL(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }
        
        public void AddCity(City city)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_AddCity, conn);
                    cmd.Parameters.AddWithValue("@id", city.CityId);
                    cmd.Parameters.AddWithValue("@name", city.Name);
                    cmd.Parameters.AddWithValue("@countrycode", city.CountryCode);
                    cmd.Parameters.AddWithValue("@district", city.District);
                    cmd.Parameters.AddWithValue("@population", city.Population);

                    cmd.ExecuteReader();                    
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public List<City> GetCitiesByCountryCode(string countryCode)
        {
            List<City> output = new List<City>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_CountryCodeCities, conn);
                    cmd.Parameters.AddWithValue("@countrycode", countryCode);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        City item = GetCityFromReader(reader);
                        output.Add(item);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return output;
        }

        public List<City> GetCitiesGreaterThanPopulationCount(int populationCount)
        {
            List<City> output = new List<City>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GreaterThanPopulationCount, conn);
                    cmd.Parameters.AddWithValue("@population", populationCount);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        City item = GetCityFromReader(reader);
                        output.Add(item);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return output;
        }

        private City GetCityFromReader(SqlDataReader reader)
        {
            City item = new City();

            item.CityId = Convert.ToInt32(reader["id"]);
            item.Name = Convert.ToString(reader["name"]);
            item.CountryCode = Convert.ToString(reader["countrycode"]);
            item.District = Convert.ToString(reader["district"]);
            item.Population = Convert.ToInt32(reader["population"]);

            return item;
        }

        

    }
}
