using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WorldTournament
{
    public class DBConnect
    {   
        //Connection to the azure sql using a builder. This builder will be called in others functions
        public SqlConnection Connect()
        {
            SqlConnectionStringBuilder Builder = new SqlConnectionStringBuilder();

            Builder.DataSource = "";
            Builder.UserID = "";
            Builder.Password = "";
            Builder.InitialCatalog = "";

            SqlConnection Connection = new SqlConnection(Builder.ConnectionString);

            return Connection;
        }

        // A simple Select using the ID as a single parameter
        public Fighter SelectByID(int SearchID)
        {
            Fighter SelectFighter = new Fighter();
            try
            {
                var Connection = Connect();

                using (Connection)
                {
                    Connection.Open();

                    // After opening the connection, a sql query is stored in a string
                    String query = $"SELECT * FROM Fighter WHERE ID={SearchID}";

                    // Using the query string and the previously open connection, a command is crated,
                    // which will be used for the actual query request
                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                SelectFighter.ID = Convert.ToInt32(Reader["ID"]);
                                SelectFighter.Name = Reader["Name"].ToString();
                                SelectFighter.Height = Convert.ToInt32(Reader["Height"]);
                                SelectFighter.Weight = Convert.ToDouble(Reader["Weight"]);
                                SelectFighter.PunchScore = Convert.ToInt32(Reader["PunchScore"]);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show("Sorry, something went wrong");
            }

            return SelectFighter;
        }

        // A Select function using custom parameters.
        public List<Fighter> SelectByMultiple(List<string> QueryParams)
        {
            List<Fighter> ListSelectFighter = new List<Fighter>();

            if (QueryParams.Count == 1)
            {
                try
                {
                    var Connection = Connect();

                    using (Connection)
                    {
                        Connection.Open();

                        // After opening the connection, a sql query is stored in a string
                        String query = $"SELECT * FROM Fighter WHERE {QueryParams[0]}";

                        // Using the query string and the previously open connection, a command is crated,
                        // which will be used for the actual query request
                        using (SqlCommand Command = new SqlCommand(query, Connection))
                        {
                            using (SqlDataReader Reader = Command.ExecuteReader())
                            {
                                while (Reader.Read())
                                {
                                    Fighter SelectFighter = new Fighter();
                                    SelectFighter.ID = Convert.ToInt32(Reader["ID"]);
                                    SelectFighter.Name = Reader["Name"].ToString();
                                    SelectFighter.Height = Convert.ToInt32(Reader["Height"]);
                                    SelectFighter.Weight = Convert.ToDouble(Reader["Weight"]);
                                    SelectFighter.PunchScore = Convert.ToInt32(Reader["PunchScore"]);
                                    ListSelectFighter.Add(SelectFighter);
                                }                                
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.ToString());
                    MessageBox.Show("Sorry, something went wrong");
                }

                
                return ListSelectFighter;
            }
            else
            {
                try
                {
                    var Connection = Connect();

                    using (Connection)
                    {
                        Connection.Open();

                        // After opening the connection, a sql query is stored in a string
                        String query = $"SELECT * FROM Fighter WHERE {QueryParams[0]}";

                        // For each additional parameter, theres a iteration in the Params List, adding
                        // all parameters to the sql query string
                        foreach (string Param in QueryParams.Skip(1)) {
                            query = query + $"\n AND {Param}";
                        }

                        // Using the query string and the previously open connection, a command is crated,
                        // which will be used for the actual query request
                        using (SqlCommand Command = new SqlCommand(query, Connection))
                        {
                            using (SqlDataReader Reader = Command.ExecuteReader())
                            {
                                while (Reader.Read())
                                {
                                    Fighter SelectFighter = new Fighter();
                                    SelectFighter.ID = Convert.ToInt32(Reader["ID"]);
                                    SelectFighter.Name = Reader["Name"].ToString();
                                    SelectFighter.Height = Convert.ToInt32(Reader["Height"]);
                                    SelectFighter.Weight = Convert.ToDouble(Reader["Weight"]);
                                    SelectFighter.PunchScore = Convert.ToInt32(Reader["PunchScore"]);
                                    ListSelectFighter.Add(SelectFighter);
                                }
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.ToString());
                    MessageBox.Show("Sorry, something went wrong");
                }

                return ListSelectFighter;
            }
            
        }

        public List<Fighter> SelectAll()
        {
            List<Fighter> ListSelectFighter = new List<Fighter>();

                try
                {
                    var Connection = Connect();

                    using (Connection)
                    {
                        Connection.Open();

                        // After opening the connection, a sql query is stored in a string
                        String query = $"SELECT * FROM Fighter";

                        // Using the query string and the previously open connection, a command is crated,
                        // which will be used for the actual query request
                        using (SqlCommand Command = new SqlCommand(query, Connection))
                        {
                            using (SqlDataReader Reader = Command.ExecuteReader())
                            {
                                while (Reader.Read())
                                {
                                    Fighter SelectFighter = new Fighter();
                                    SelectFighter.ID = Convert.ToInt32(Reader["ID"]);
                                    SelectFighter.Name = Reader["Name"].ToString();
                                    SelectFighter.Height = Convert.ToInt32(Reader["Height"]);
                                    SelectFighter.Weight = Convert.ToDouble(Reader["Weight"]);
                                    SelectFighter.PunchScore = Convert.ToInt32(Reader["PunchScore"]);
                                    ListSelectFighter.Add(SelectFighter);
                                }
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.ToString());
                    MessageBox.Show("Sorry, something went wrong");
                }


                return ListSelectFighter;
        }


        // Function to insert a new fighter into the database
        public void Insert(Fighter NewFighter)
        {
            var Connection = Connect();

            try
            {
                using (Connection)
                {
                    Connection.Open();

                    string query = $"INSERT INTO Fighter (ID, Name, Height, Weight, PunchScore)" +
                        $"VALUES ({NewFighter.ID}, '{NewFighter.Name}', {NewFighter.Height}, {NewFighter.Weight}, {NewFighter.PunchScore})";

                    SqlCommand Command = new SqlCommand(query, Connection);
                    Command.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString() + "\n");
                MessageBox.Show("Sorry, something went wrong");
            }
        }

        // Function to delete a single fighter from the database, using the ID as parameter
        public void Delete(int FighterID)
        {
            var Connection = Connect();

            try
            {
                using (Connection)
                {
                    Connection.Open();

                    string query = $"DELETE FROM Fighter WHERE ID={FighterID}";

                    SqlCommand Command = new SqlCommand(query, Connection);
                    Command.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show("Sorry, something went wrong");
            }
        }

        public void Edit(List<string> QueryParams, int FighterID)
        {
            if (QueryParams.Count == 1)
            {
                try
                {
                    var Connection = Connect();

                    using (Connection)
                    {
                        Connection.Open();

                        // After opening the connection, a sql query is stored in a string
                        String query = $"UPDATE Fighter " +
                            $"SET {QueryParams[0]}" + 
                            $"WHERE ID = {FighterID}";

                        SqlCommand Command = new SqlCommand(query, Connection);
                        Command.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.ToString());
                    MessageBox.Show("Sorry, something went wrong");
                }
            }
            else
            {
                try
                {
                    var Connection = Connect();

                    using (Connection)
                    {
                        Connection.Open();

                        // After opening the connection, a sql query is stored in a string
                        String query = $"UPDATE Fighter " +
                            $"SET {QueryParams[0]}";

                        // For each additional parameter, theres a iteration in the Params List, adding
                        // all parameters to the sql query string
                        foreach (string Param in QueryParams.Skip(1))
                        {
                           query = query + $" ,{Param}";
                        }

                        query = query + $" WHERE ID = {FighterID}";

                        SqlCommand Command = new SqlCommand(query, Connection);
                        Command.ExecuteNonQuery();
                        
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.ToString());
                    MessageBox.Show("Sorry, something went wrong");
                }

                
            }
        }

        public int Counting(List<string> QueryParams)
        {
            var Connection = Connect();

            try
            {
                using (Connection)
                {
                    Connection.Open();

                    String query = $"SELECT COUNT(*) FROM Fighter WHERE {QueryParams[0]}";

                    foreach (string Param in QueryParams.Skip(1))
                    {
                        query = query + $"\n AND {Param}";
                    }

                    query = query + ";";

                    int count = 0;
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        using (SqlDataReader Reader = command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                count = Convert.ToInt32(Reader[0]);
                            }
                        }
                    }

                    MessageBox.Show($"Count : {count}");

                    return count;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show("Sorry, something went wrong");
                return 0;
            }
            
            
        }
    }
}