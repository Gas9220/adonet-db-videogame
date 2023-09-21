using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace adonet_db_videogame
{
    public static class VideogameManager
    {
        public static void AddNewGame()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=videogame_db;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO videogames (name, overview, release_date, software_house_id) VALUES (@name, @overview, @release_date, @software_house_id);";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.Add(new SqlParameter("@name", "name"));
                    cmd.Parameters.Add(new SqlParameter("@overview", "overview"));
                    cmd.Parameters.Add(new SqlParameter("@release_date", "22/10/2025"));
                    cmd.Parameters.Add(new SqlParameter("@software_house_id", "1"));

                    int affectedRows = cmd.ExecuteNonQuery();

                    Console.WriteLine("Videogame added");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

    }
}
