using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using NLog;

namespace SQLConnection
{
    public class SQL : IQueryDatabase, IAlterDatabase 
    {
        #region Member Variables

        private Logger _log;
        readonly SqlConnection _sqlConnection = null;
        SqlCommand _sqlCommand = null;

        #endregion

        #region Constructors

        public SQL()
        {
            // try...catch to record errors in log file
            LogManager.LoadConfiguration("NLog.config");
            _log = LogManager.GetCurrentClassLogger();
            // Get the connectrion string from app.config
            // Initialize and create a new SqlConnection object that is needed to connect to a SQL server
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            _sqlConnection = new SqlConnection(connectionString);
        }

        #endregion

        #region Alter Database

        public void AlterDatabaseTable(string tableName, string tableStructure)
        {
            try
            {
                string sqlQuery = $"ALTER TABLE {tableName} ({tableStructure})";

                using (_sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    if (_sqlConnection.State == ConnectionState.Closed) _sqlConnection.Open();
                    _sqlCommand.ExecuteNonQuery();
                    _sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                _log.Error(e.ToString());
            }
            
        }

        /// <summary>
        /// This method will create the database on SQL server
        /// </summary>
        /// 
        public void CreateDatabase()
        {
            // Create another SqlConnection to point to the server without the database name
            string serversqlConnString = $"Data Source={_sqlConnection.DataSource};" +
                                         $"Integrated Security = True;";
            SqlConnection sqlServerConn = new SqlConnection(serversqlConnString);

            // Create a SQL scripy to create the database. Check the SQL syntax of creating DB in W3schools
            string sqlScript = $"IF NOT EXISTS (SELECT 1 FROM sys.databases " +
                                   $"WHERE name = '{_sqlConnection.Database}')" +
                               $"CREATE DATABASE {_sqlConnection.Database}";

            // Create the SqlCommand object that will execute the SQL script above
            _sqlCommand = new SqlCommand(sqlScript, sqlServerConn);

            // Check if SqlConnection object is closed before opening otherwise an error will occour.
            if (sqlServerConn.State == ConnectionState.Closed)
            {
                //open the Sql connection object so Sql Command can execute 
                sqlServerConn.Open();

                // run the SQL script using the SqlCommand object 
                _sqlCommand.ExecuteNonQuery();

                // Close the SqlConnection object as soon as we are done with it.
                sqlServerConn.Close();
            }
        }

        /// <summary>
        /// This method will crate a database table on a specified server and database
        /// </summary>
        /// <param name="tableName">The Table name to be created</param>
        /// <param name="tableStrucutre">The table schema to be added in the table</param>

        public void CreateDatabaseTable(string tableName, string tableStrucutre)
        {
            string sqlQuery = $"IF NOT EXISTS (SELECT name FROM sysobjects " +
                             $"WHERE name = '{tableName}') " +
                            $"CREATE TABLE {tableName} ({tableStrucutre})";
            try
            {
                using (_sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    if (_sqlConnection.State == ConnectionState.Closed)
                        _sqlConnection.Open();
                    _sqlCommand.ExecuteNonQuery();
                    _sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                _log.Error(e.ToString());
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        /// <summary>
        /// This method will delete a record in the database
        /// </summary>
        /// <param name="tableName">Table Name</param>
        /// <param name="pkName">Primary Key Name</param>
        /// <param name="pkID">Primary Key ID</param>
        public void DeleteRecord(string tableName, string pkName, string pkID)
        {
            string sqlQuery = $"DELETE FROM {tableName} WHERE {pkName} = {pkID} SELECT SCOPE_IDENTITY()";

            try
            {
                using (_sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    if (_sqlConnection.State == ConnectionState.Closed) _sqlConnection.Open();
                    _sqlCommand.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                _log.Error(e.ToString());
            }
        }

        /// <summary>
        /// This method will insert a record in the database.
        /// </summary>
        /// <param name="tableName">Destination Table</param>
        /// <param name="columnNames">Column names of the table</param>
        /// <param name="columnValues">Column Values</param>
        /// <returns>NewIs</returns>
        public int InsertParentRecord(string tableName, string columnNames, string columnValues)
        {
            int Id = 0;

            try
            {
                string sqlQuery = $"INSERT INTO {tableName} ({columnNames}) " +
                                  $"VALUES ({columnValues}) " +
                                  $"SELECT SCOPE_IDENTITY()";
                using (_sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    if (_sqlConnection.State == ConnectionState.Closed) _sqlConnection.Open();
                    Id = (int)(decimal)_sqlCommand.ExecuteScalar();
                    _sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                _log.Error(e.ToString());
            }
            return Id;
        }

        /// <summary>
        /// This method will insert a recod in the table
        /// </summary>
        /// <param name="tableName">Table name where record will be inserted.</param>
        /// <param name="columnNames">Column names of the table.</param>
        /// <param name="columnValues">Colim values to be inserted.</param>
        /// <returns>An int  representing the primary key value of the newly inserted record
        /// </returns>
        public int InsertRecord(string tableName, string columnNames, string columnValues)
        {
            int id = 0;

            string sqlQuery = $"SET IDENTITY_INSERT {tableName} ON ; " +
                              $"INSERT INTO {tableName}({columnNames})  " +
                              $"Values ({columnValues}) ; " +
                              $"SET IDENTITY_INSERT {tableName} OFF ; " +
                              "SELECT SCOPE_IDENTITY(); ";

            try
            {
                using (_sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    if (_sqlConnection.State == ConnectionState.Closed)
                        _sqlConnection.Open();

                    id = (int)(decimal)_sqlCommand.ExecuteScalar(); 
                    _sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                _log.Error(e.ToString());

            }
            finally
            {
                _sqlConnection.Close();
            }

            return id;
        }

        public void SaveDatabaseTable(DataTable dataTable)
        {
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM {dataTable.TableName}", _sqlConnection))
                {
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.InsertCommand = commandBuilder.GetInsertCommand();
                    adapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                    adapter.DeleteCommand = commandBuilder.GetDeleteCommand();

                    if (_sqlConnection.State == ConnectionState.Closed) _sqlConnection.Open();
                    adapter.Update(dataTable);
                    _sqlConnection.Close();
                    dataTable.AcceptChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _log.Error(e.ToString());
            }
        }

        /// <summary>
        /// method will update a record in the database
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnNamesAndValues"></param>
        /// <param name="criteria"></param>
        /// <returns>bool IsOk</returns>
        public bool UpdateRecord(string tableName, string columnNamesAndValues, string criteria)
        {
            bool isOk = false;

            string sqlQuery = $"UPDATE {tableName} SET {columnNamesAndValues} WHERE {criteria}";

            try
            {
                using (_sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    if (_sqlConnection.State == ConnectionState.Closed) _sqlConnection.Open();
                    _sqlCommand.ExecuteNonQuery();
                    isOk = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                isOk = false;
                _log.Error(e.ToString());
            }
            return isOk;
        }
        #endregion

        #region Query Database

        /// <summary>
        /// This method will get an updateable table from the database.
        /// </summary>
        /// <param name="tableName">Source Table</param>
        /// <returns>DataTable</returns>

        public DataTable GetDataTable(string tableName)
        {
            DataTable table = new DataTable(tableName);

            try
            {
                // Using a SqlDataAdapter allows us to make a DataTable updateable as it represents a set of data
                // commands and a connection that are used to update SQL database
                using (SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM {tableName}", _sqlConnection))
                {
                    if (_sqlConnection.State == ConnectionState.Closed) _sqlConnection.Open();
                    // Based on the sql query we passed as a parameter, the SqlAdapter build-in Command object 
                    // send the sql query to SQL. SQL will return with the corresponding record set and populate our 
                    //DataTable named 'table'.
                    adapter.Fill(table);
                    _sqlConnection.Close();
                    // Configure our DataTable and specify the Primary key, which is in column 0 (or the first Column).
                    table.PrimaryKey = new DataColumn[] { table.Columns[0] };
                    // Specify that the primary key in column is auto-increment.
                    table.Columns[0].AutoIncrement = true;
                    // Seed the primary key value by using the last pkId value. Seeding the primary key value is to
                    // simply set up the starting value of the auto-incremnt.
                    // to get the current last pkId value
                    if (table.Rows.Count > 0)
                        table.Columns[0].AutoIncrementSeed = long.Parse(table.Rows[table.Rows.Count - 1][0].ToString());
                    // Set the auto-increment step by 1
                    table.Columns[0].AutoIncrementStep = 1;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                _log.Error(e.ToString());
            }

            return table;
        }

        /// <summary>
        /// This method will get an Read-Only table from the data.
        /// </summary>
        /// <param name="tableName">Source Table</param>
        /// <param name="isReadOnly">Specify if table is Read-Only</param>
        /// <returns>DataTable</returns>

        public DataTable GetDataTable(string tableName, bool isReadOnly)
        {
            if (isReadOnly == false) return GetDataTable(tableName);

            DataTable table = new DataTable(tableName);


            try
            {
                using (_sqlCommand = new SqlCommand($"SELECT * FROM {tableName}", _sqlConnection))
                {
                    if (_sqlConnection.State == ConnectionState.Closed) _sqlConnection.Open();
                    using (SqlDataReader reader = _sqlCommand.ExecuteReader())
                    {
                        table.Load(reader);
                        _sqlConnection.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                _log.Error(e.ToString());
            }

            return table;
        }


        /// <summary>
        /// This method will get an updateable table from the database.
        /// </summary>
        /// <param name="sqlQuery">SQL query to retrieve records.</param>
        /// <param name="tableName">Source Table</param>
        /// <returns>DataTable</returns>

        public DataTable GetDataTable(string sqlQuery, string tableName)
        {
            DataTable table = new DataTable(tableName);

            try
            {
                // Using a SqlAdapter allows us to make a Datatable updateable as it represents a set of
                // data commands and connection that are used to update a SQL database.
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, _sqlConnection))
                {
                    if (_sqlConnection.State == ConnectionState.Closed) _sqlConnection.Open();
                    // Based on the sql query we passed as a parameter, the SqlAdapter build-in Command object 
                    // send the sql query to SQL. SQL will return with the corresponding record set and populate our 
                    //DataTable named 'table'.
                    adapter.Fill(table);
                    _sqlConnection.Close();
                    // Configure our DataTable and specify the Primary key, which is in column 0 (or the first Column).
                    table.PrimaryKey = new DataColumn[] { table.Columns[0] };
                    // Specify that the primary key in column 0 is auto-increment
                    table.Columns[0].AutoIncrement = true;
                    // Seed the primary key value by using the last pkId value. Seeding the primary ket value is to
                    // simply set up the starting value of the auto increment.
                    // to get the current last pkId value
                    if (table.Rows.Count > 0)
                        table.Columns[0].AutoIncrementSeed = long.Parse(table.Rows[table.Rows.Count - 1][0].ToString());
                    // Set the auto increment step by 1
                    table.Columns[0].AutoIncrementStep = 1;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                _log.Error(e.ToString());
            }
            return table;
        }


        /// <summary>
        /// This method will get an Read-only table from the database.
        /// </summary>
        /// <param name="sqlQuery">SQL query to retrieve records</param>
        /// <param name="tableName">Source Table</param>
        /// <param name="isReadOnly">Specify if table is Read-Only</param>
        /// <returns>DataTable</returns>

        public DataTable GetDataTable(string sqlQuery, string tableName, bool isReadOnly)
        {
            DataTable table = new DataTable(tableName);

            try
            {
                using (_sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    if (_sqlConnection.State == ConnectionState.Closed) _sqlConnection.Open();
                    using (SqlDataReader reader = _sqlCommand.ExecuteReader())
                    {
                        table.Load(reader);
                        _sqlConnection.Close();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                _log.Error(e.ToString());
            }
            return table;
        }
        #endregion
    }
}
