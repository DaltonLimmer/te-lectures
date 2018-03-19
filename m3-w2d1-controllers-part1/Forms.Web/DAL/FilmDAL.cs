using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Forms.Web.Models;

namespace Forms.Web.DAL
{
    public class FilmDAL : IFilmDAL /* Step 1A */
    {
        private string connectionString;

        public FilmDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Film> SearchFilms(string title, string description, int? releaseYear, int? minLength, int? maxLength, string rating)
        {
            IList<Film> films = new List<Film>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = BuildSqlCommand(title, description, releaseYear, minLength, maxLength, rating);
                    cmd.Connection = conn;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Film film = MapFilmFromReader(reader);
                        films.Add(film);
                    }

                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return films;
        }


        private Film MapFilmFromReader(SqlDataReader reader)
        {
            return new Film()
            {
                Id = Convert.ToInt32(reader["film_id"]),
                Title = Convert.ToString(reader["title"]),
                Description = Convert.ToString(reader["description"]),
                ReleaseYear = Convert.ToInt32(reader["release_year"]),
                Length = Convert.ToInt32(reader["length"]),
                Rating = Convert.ToString(reader["rating"])
            };
        }

        private SqlCommand BuildSqlCommand(string title, string description, int? releaseYear, int? minLength, int? maxLength, string rating)
        {
            SqlCommand cmd = new SqlCommand();
            string sql = "SELECT * FROM film WHERE ";
            string logicOperator = "";

            if (!String.IsNullOrEmpty(title))
            {
                sql += $"{logicOperator} title LIKE @title ";
                cmd.Parameters.AddWithValue("@title", "%" + title + "%");
                logicOperator = "AND";
            }

            if (!String.IsNullOrEmpty(description))
            {                
                sql += $"{logicOperator} description LIKE @description ";
                cmd.Parameters.AddWithValue("@description", "%" + description + "%");
                logicOperator = "AND";
            }

            if (releaseYear.HasValue)
            {
                sql += $"{logicOperator} releaseYear = @releaseYear ";
                cmd.Parameters.AddWithValue("@releaseYear", releaseYear.Value);
                logicOperator = "AND";
            }

            if (minLength.HasValue)
            {
                sql += $"{logicOperator} length >= @minLength ";
                cmd.Parameters.AddWithValue("@minLength", minLength.Value);
                logicOperator = "AND";
            }

            if (maxLength.HasValue)
            {
                sql += $"{logicOperator} length <= @maxLength ";
                cmd.Parameters.AddWithValue("@maxLength", maxLength.Value);
                logicOperator = "AND";
            }

            if (!String.IsNullOrEmpty(rating))
            {
                sql += $"{logicOperator} rating = @rating";
                cmd.Parameters.AddWithValue("@rating", rating);                
            }

            sql += ";";

            cmd.CommandText = sql;

            return cmd;
        }

    }
}