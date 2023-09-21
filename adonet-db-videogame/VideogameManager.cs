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
        public static void InsertGame()
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

                    Videogame newVideogame = CreateVideogame();

                    cmd.Parameters.Add(new SqlParameter("@name", newVideogame.Name));
                    cmd.Parameters.Add(new SqlParameter("@overview", newVideogame.Overview));
                    cmd.Parameters.Add(new SqlParameter("@release_date", newVideogame.ReleaseDate));
                    cmd.Parameters.Add(new SqlParameter("@software_house_id", newVideogame.SoftwareHouseId));

                    int affectedRows = cmd.ExecuteNonQuery();

                    Console.WriteLine("Videogame added");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        private static Videogame CreateVideogame()
        {
            string name = Helpers.checkValidString("Videogame name: ", "Cannot be empty");
            string overview = Helpers.checkValidString("Videogame overview: ", "Cannot be empty");
            DateTime date = Helpers.checkValidDate("Videogame release date: ", "Date in wrong format");
            int swh = Helpers.checkValidInt("Videogame Software house: ", "Insert a valid number");

            Videogame newVideogame = new Videogame(0, name, overview, date, swh);

            return newVideogame;
        }
    }
}
