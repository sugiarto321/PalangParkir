using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace PalangParkir
{
    public class Connection
    {
        private MySqlConnection conn;
        private MySqlDataAdapter myAdapter;
        private static Connection dbConn ;
        
        //private string server;
        //private string database;
        //private string uid;
        //private string password;

        public Connection() { 
            myAdapter = new MySqlDataAdapter();
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
            OpenConnection();

        }

        private MySqlConnection openConnection() 
        { 
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }

        public MySqlConnection getConnection() {
            return this.conn;
        }

        public static Connection GetInstance()
        {
            if (dbConn == null)
            {
                dbConn = new Connection();
            }
    
            return dbConn;
        }


        /// <method>
        /// Select Query
        /// </method>
        public DataTable executeSelectQuery(String _query, MySqlParameter[] sqlParameter)
        {
            MySqlCommand myCommand = new MySqlCommand();
            DataTable dataTable = new DataTable();
            dataTable = null;
            DataSet ds = new DataSet();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(ds);
                dataTable = ds.Tables[0];
            }
            catch (MySqlException e)
            {
                Console.Write("Error - Connection.executeSelectQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                return null;
            }
            finally
            {

            }
            return dataTable;
        }
        /// <method>
        /// Insert Query
        /// </method>
        public bool executeInsertQuery(String _query, MySqlParameter[] sqlParameter)
        {
            MySqlCommand myCommand = new MySqlCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.InsertCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.Write("Error - Connection.executeInsertQuery - Query: " + _query + " \nException: \n" + e.StackTrace.ToString());
                return false;
            }
            finally
            {
            }
            return true;
        }

        /// <method>
        /// Update Query
        /// </method>
        public bool executeUpdateQuery(String _query, MySqlParameter[] sqlParameter)
        {
            MySqlCommand myCommand = new MySqlCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.UpdateCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.Write("Error - Connection.executeUpdateQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                return false;
            }
            finally
            {
            }
            return true;
        }

        ////Constructor
        //public void DBConnect()
        //{
        //    Initialize();
        //}

        //Initialize values
        //private void Initialize()
        //{
        //    server = "localhost";
        //    database = "palangparkir";
        //    uid = "root";
        //    password = "";
        //    string connectionString;
        //    connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        //    connection = new MySqlConnection(connectionString);
        //    OpenConnection();
        //}


        ////open connection to database
        public bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                //1042: MySql not Active.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    case 1042:
                        MessageBox.Show("Mysql Belum Aktif");
                        break;
                }
                return false;
            }
        }

        ////Close connection
        //private bool CloseConnection()
        //{
        //    try
        //    {
        //        connection.Close();
        //        return true;
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}
        ////Insert statement
        //public void Insert()
        //{
        //    string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

        //    //open connection
        //    if (this.OpenConnection() == true)
        //    {
        //        //create command and assign the query and connection from the constructor
        //        MySqlCommand cmd = new MySqlCommand(query, connection);

        //        //Execute command
        //        cmd.ExecuteNonQuery();

        //        //close connection
        //        this.CloseConnection();
        //    }
        //}

        ////Update statement
        //public void Update()
        //{
        //    string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

        //    //Open connection
        //    if (this.OpenConnection() == true)
        //    {
        //        //create mysql command
        //        MySqlCommand cmd = new MySqlCommand();
        //        //Assign the query using CommandText
        //        cmd.CommandText = query;
        //        //Assign the connection using Connection
        //        cmd.Connection = connection;

        //        //Execute query
        //        cmd.ExecuteNonQuery();

        //        //close connection
        //        this.CloseConnection();
        //    }
        //}

        ////Delete statement
        //public void Delete()
        //{
        //    string query = "DELETE FROM tableinfo WHERE name='John Smith'";

        //    if (this.OpenConnection() == true)
        //    {
        //        MySqlCommand cmd = new MySqlCommand(query, connection);
        //        cmd.ExecuteNonQuery();
        //        this.CloseConnection();
        //    }
        //}

        ////Select statement
        //public List<string>[] Select()
        //{
        //    string query = "SELECT * FROM tableinfo";

        //    //Create a list to store the result
        //    List<string>[] list = new List<string>[3];
        //    list[0] = new List<string>();
        //    list[1] = new List<string>();
        //    list[2] = new List<string>();

        //    //Open connection
        //    if (this.OpenConnection() == true)
        //    {
        //        //Create Command
        //        MySqlCommand cmd = new MySqlCommand(query, connection);
        //        //Create a data reader and Execute the command
        //        MySqlDataReader dataReader = cmd.ExecuteReader();

        //        //Read the data and store them in the list
        //        while (dataReader.Read())
        //        {
        //            list[0].Add(dataReader["id"] + "");
        //            list[1].Add(dataReader["name"] + "");
        //            list[2].Add(dataReader["age"] + "");
        //        }

        //        //close Data Reader
        //        dataReader.Close();

        //        //close Connection
        //        this.CloseConnection();

        //        //return list to be displayed
        //        return list;
        //    }
        //    else
        //    {
        //        return list;
        //    }
        //}

        ////Count statement
        //public int Count()
        //{
        //    string query = "SELECT Count(*) FROM tableinfo";
        //    int Count = -1;

        //    //Open Connection
        //    if (this.OpenConnection() == true)
        //    {
        //        //Create Mysql Command
        //        MySqlCommand cmd = new MySqlCommand(query, connection);

        //        //ExecuteScalar will return one value
        //        Count = int.Parse(cmd.ExecuteScalar() + "");

        //        //close Connection
        //        this.CloseConnection();

        //        return Count;
        //    }
        //    else
        //    {
        //        return Count;
        //    }
        //}
    }
}
