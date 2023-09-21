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

                    using (cmd)
                    {
                        Videogame newVideogame = CreateVideogame();

                        cmd.Parameters.Add(new SqlParameter("@name", newVideogame.Name));
                        cmd.Parameters.Add(new SqlParameter("@overview", newVideogame.Overview));
                        cmd.Parameters.Add(new SqlParameter("@release_date", newVideogame.ReleaseDate));
                        cmd.Parameters.Add(new SqlParameter("@software_house_id", newVideogame.SoftwareHouseId));

                        int affectedRows = cmd.ExecuteNonQuery();

                        Console.WriteLine("Videogame added");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void SearchById()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=videogame_db;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                try
                {
                    connection.Open();

                    string query = "SELECT videogames.* FROM videogames WHERE id = @id";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    using (cmd)
                    {
                        int videogameId = Helpers.checkValidInt("Insert videogame id: ", "Insert a valid number");
                        cmd.Parameters.Add(new SqlParameter("@id", videogameId));
                        SqlDataReader reader = cmd.ExecuteReader();

                        using (reader)
                        {

                            while (reader.Read())
                            {
                                Videogame findedVideogame = new Videogame(0, reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetInt64(6));
                                Console.WriteLine(findedVideogame.ToString());

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void SearchByName()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=videogame_db;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                try
                {
                    connection.Open();

                    string query = "SELECT videogames.* FROM videogames WHERE name LIKE @Name;";
                    List<Videogame> videogames = new List<Videogame>();

                    SqlCommand cmd = new SqlCommand(query, connection);

                    using (cmd)
                    {

                        string videogameName = Helpers.checkValidString("Insert videogame name: ", "Can't be empty");
                        cmd.Parameters.Add(new SqlParameter("@Name", $"{videogameName}%"));
                        SqlDataReader reader = cmd.ExecuteReader();

                        using (reader)
                        {
                            while (reader.Read())
                            {
                                Videogame findedVideogame = new Videogame(0, reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetInt64(6));
                                videogames.Add(findedVideogame);
                            }
                        }
                    }

                    foreach (var videogame in videogames)
                    {
                        Console.WriteLine(videogame.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void DeleteGame()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=videogame_db;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM videogames WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    using (cmd)
                    {

                        int idVideogameToDelete = Helpers.checkValidInt("Remove videogame with id: ", "Insert a valid number...");
                        cmd.Parameters.Add(new SqlParameter("@id", idVideogameToDelete));
                        int affectedRows = cmd.ExecuteNonQuery();

                        Console.WriteLine("Videogame removed");
                    }
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
