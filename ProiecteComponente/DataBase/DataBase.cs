
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DataBases
{
    public class DataBase
    {
        //private SqlConnection sqlConnection;

        private readonly string connectionString;

        static public readonly string logFileName = "E:\\Git\\Proiecte\\PIU\\proiectPIU\\ProiecteComponente\\DataBase\\log.txt";

        public DataBase(string connectionString)
        {
            using (StreamWriter streamWriter = new StreamWriter(logFileName, false)) { }

            if (string.IsNullOrEmpty(connectionString))
            {
                using (StreamWriter streamWriter = new StreamWriter(logFileName, true))
                {
                    streamWriter.WriteLine("Constructor 'public DataBase(string connectionString)':\nConnection string cannot be null or empty.\n");
                }
            }

            try
            {
                //sqlConnection = new SqlConnection(connectionString);
                this.connectionString = connectionString;
            }
            catch (SqlException ex)
            {
                using (StreamWriter streamWriter = new StreamWriter(logFileName, true))
                {
                    streamWriter.WriteLine($"Failed to create a database connection.\n{ex.Message}\n");
                }
            }
        }

        public bool IsAvailable
        {
            get
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (var sqlCommand = new SqlCommand("SELECT 1", connection))
                        {
                            sqlCommand.ExecuteScalar();
                        }
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    using (StreamWriter streamWriter = new StreamWriter(logFileName, true))
                    {
                        streamWriter.WriteLine($"Property 'public bool IsAvailable':\n{ex.Message}\n");
                    }
                    return false;
                }
            }
        }

        //public SqlConnection GetConnection
        //{
        //    get { return sqlConnection; }
        //}

        //public void OpenConnection()
        //{
        //    if (sqlConnection.State == ConnectionState.Closed)
        //    {
        //        sqlConnection.Open();
        //    }
        //}

        //public void CloseConnection()
        //{
        //    if (sqlConnection.State == ConnectionState.Open)
        //    {
        //        sqlConnection.Close();
        //    }
        //}

        //
        // CRUD Operations
        //

        // Create
        public ReturnCodes AddLocuitor(string nume, string prenume, string sex, string dataNasterii, string cnp, int camera)
        {
            try
            {
                ReturnCodes operationResult = CheckLocuitor(nume, prenume, sex, dataNasterii, cnp, camera);

                if (operationResult == ReturnCodes.RECORD_DONT_EXISTS)
                {
                    string queryString = "INSERT INTO Locuitori (nume, prenume, sex, data_nasterii, cnp, camera) " +
                                         "VALUES (@nume, @prenume, @sex, @dataNasterii, @cnp, @camera)";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand sqlCommand = new SqlCommand(queryString, connection))
                        {
                            //sqlCommand.Parameters.AddWithValue("@nume", Capitalize(nume));
                            //sqlCommand.Parameters.AddWithValue("@prenume", Capitalize(prenume));
                            //sqlCommand.Parameters.AddWithValue("@sex", sex);
                            //sqlCommand.Parameters.AddWithValue("@dataNasterii", dataNasterii);
                            //sqlCommand.Parameters.AddWithValue("@cnp", cnp);
                            //sqlCommand.Parameters.AddWithValue("@camera", camera);

                            sqlCommand.Parameters.Add("@nume", SqlDbType.VarChar).Value = Capitalize(nume);
                            sqlCommand.Parameters.Add("@prenume", SqlDbType.VarChar).Value = Capitalize(prenume);
                            sqlCommand.Parameters.Add("@sex", SqlDbType.VarChar).Value = sex;
                            sqlCommand.Parameters.Add("@data_nasterii", SqlDbType.DateTime2).Value = DateTime.Parse(dataNasterii);
                            sqlCommand.Parameters.Add("@cnp", SqlDbType.VarChar).Value = cnp;
                            sqlCommand.Parameters.Add("@camera", SqlDbType.Int).Value = camera;

                            return (sqlCommand.ExecuteNonQuery() == 1) ? ReturnCodes.SUCCES
                                    : ReturnCodes.OPERATION_FAILED;
                        }
                    }
                }
                else if (operationResult == ReturnCodes.RECORD_EXISTS) return ReturnCodes.RECORD_EXISTS;
                else return operationResult;
            }
            catch (SqlException ex)
            {
                using (StreamWriter streamWriter = new StreamWriter(logFileName, true))
                {
                    streamWriter.WriteLine($"Method 'public ReturnCodes AddLocuitor(string nume, string prenume, string sex, string dataNasterii, string cnp, int camera)':\n{ex.Message}\n");
                }
                return ReturnCodes.OPERATION_FAILED;
            }
        }

        // Read
        public ReturnCodes AllLocuitori()
        {
            try
            {
                string queryString = $"SELECT * FROM Locuitori";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryString, connection))
                    {
                        return DataExtractor(sqlCommand, out _);
                    }
                }
            }
            catch (SqlException ex)
            {
                using (StreamWriter streamWriter = new StreamWriter(logFileName, true))
                {
                    streamWriter.WriteLine($"Method 'ReturnCodes AllLocuitori()':\n{ex.Message}\n");
                }
                return ReturnCodes.OPERATION_FAILED;
            }
        }

        // Update
        public ReturnCodes UpdateLocuitor(int id, string nume, string prenume, string sex, string dataNasterii, string cnp, int camera)
        {
            try
            {
                ReturnCodes operationResultCode = CheckLocuitor(id);

                if (operationResultCode == ReturnCodes.RECORD_EXISTS)
                {
                    string queryString = "UPDATE Locuitori SET nume = @nume, prenume = @prenume, sex = @sex, " +
                                          "data_nasterii = @dataNasterii, cnp = @cnp, camera = @camera WHERE id = @id";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand sqlCommand = new SqlCommand(queryString, connection))
                        {
                            sqlCommand.Parameters.AddWithValue("@nume", Capitalize(nume));
                            sqlCommand.Parameters.AddWithValue("@prenume", Capitalize(prenume));
                            sqlCommand.Parameters.AddWithValue("@sex", sex);
                            sqlCommand.Parameters.AddWithValue("@dataNasterii", dataNasterii);
                            sqlCommand.Parameters.AddWithValue("@cnp", cnp);
                            sqlCommand.Parameters.AddWithValue("@camera", camera);

                            return (sqlCommand.ExecuteNonQuery() == 1) ? ReturnCodes.SUCCES
                                    : ReturnCodes.OPERATION_FAILED;
                        }
                    }
                }
                else if (operationResultCode == ReturnCodes.RECORD_DONT_EXISTS) return ReturnCodes.RECORD_DONT_EXISTS;
                else return operationResultCode;
            }
            catch (SqlException ex)
            {
                using (StreamWriter streamWriter = new StreamWriter(logFileName, true))
                {
                    streamWriter.WriteLine($"Method 'public ReturnCodes UpdateLocuitor(int id, string nume, string prenume, string sex, string dataNasterii, string cnp, int camera)':\n{ex.Message}\n");
                }
                return ReturnCodes.OPERATION_FAILED;
            }
        }

        // Delete
        public ReturnCodes DeleteLocuitor(int id)
        {
            try
            {
                ReturnCodes operationResult = CheckLocuitor(id);

                if (operationResult == ReturnCodes.RECORD_EXISTS)
                {
                    string queryString = "DELETE FROM Locuitori WHERE id = @id";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand sqlCommand = new SqlCommand(queryString, connection))
                        {
                            sqlCommand.Parameters.AddWithValue("@id", id);

                            return (sqlCommand.ExecuteNonQuery() == 1) ? ReturnCodes.SUCCES
                                    : ReturnCodes.OPERATION_FAILED;
                        }
                    }
                }
                else if (operationResult == ReturnCodes.RECORD_DONT_EXISTS) return ReturnCodes.RECORD_DONT_EXISTS;
                else return operationResult;
            }
            catch (SqlException ex)
            {
                using (StreamWriter streamWriter = new StreamWriter(logFileName, true))
                {
                    streamWriter.WriteLine($"Method 'public ReturnCodes DeleteLocuitor(int id)':\n{ex.Message}\n");
                }
                return ReturnCodes.OPERATION_FAILED;
            }
        }

        // Suplimentar methods

        private ReturnCodes DataExtractor(SqlCommand sqlCommand, out DataTable dataTable)
        {
            dataTable = new DataTable();

            try
            {
                using (sqlCommand)
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                    {
                        adapter.Fill(dataTable);
                    }
                }

                return dataTable.Rows.Count > 0 ? ReturnCodes.RECORD_EXISTS : ReturnCodes.RECORD_DONT_EXISTS;
            }
            catch (SqlException ex)
            {
                using (StreamWriter streamWriter = new StreamWriter(logFileName, true))
                {
                    streamWriter.WriteLine($"Method 'private ReturnCodes DataExtractor(SqlCommand sqlCommand, out DataTable dataTable)':\n{ex.Message}\n");
                }
                return ReturnCodes.OPERATION_FAILED;
            }
        }

        public ReturnCodes CheckLocuitor(int id)
        {
            try
            {
                string queryString = "SELECT * FROM Locuitori WHERE id = @id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryString, connection))
                    {
                        sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

                        return DataExtractor(sqlCommand, out _);
                    }
                }
            }
            catch (SqlException ex)
            {
                using (StreamWriter streamWriter = new StreamWriter(logFileName, true))
                {
                    streamWriter.WriteLine($"Method 'public ReturnCodes CheckLocuitor(int id)':\n{ex.Message}\n");
                }
                return ReturnCodes.OPERATION_FAILED;
            }
        }

        public ReturnCodes CheckLocuitor(string nume, string prenume, string sex, string dataNasterii, string cnp, int camera)
        {
            try
            {
                string queryString = "SELECT * FROM Locuitori WHERE " +
                                     "nume = @nume AND " +
                                     "prenume = @prenume AND " +
                                     "sex = @sex AND " +
                                     "data_nasterii = @dataNasterii AND " +
                                     "cnp = @cnp AND " +
                                     "camera = @camera";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryString, connection))
                    {
                        sqlCommand.Parameters.Add("@nume", SqlDbType.VarChar).Value = Capitalize(nume);
                        sqlCommand.Parameters.Add("@prenume", SqlDbType.VarChar).Value = Capitalize(prenume);
                        sqlCommand.Parameters.Add("@sex", SqlDbType.VarChar).Value = sex;
                        sqlCommand.Parameters.Add("@data_nasterii", SqlDbType.DateTime2).Value = DateTime.Parse(dataNasterii);
                        sqlCommand.Parameters.Add("@cnp", SqlDbType.VarChar).Value = cnp;
                        sqlCommand.Parameters.Add("@camera", SqlDbType.Int).Value = camera;

                        return DataExtractor(sqlCommand, out _);
                    }
                }
            }
            catch (SqlException ex)
            {
                using (StreamWriter streamWriter = new StreamWriter(logFileName, true))
                {
                    streamWriter.WriteLine($"Method 'public ReturnCodes CheckLocuitor(string nume, string prenume, string sex, string dataNasterii, string cnp, int camera)':\n{ex.Message}\n");
                }
                return ReturnCodes.OPERATION_FAILED;
            }
        }

        static public string Capitalize(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;

            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }
    }
}
