
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using LibrarieModele;

namespace DataBase
{
    public class Database
    {
        private readonly string connectionString;

        //static public readonly string logFileName = "log.txt";

        private DbReturnCodes operationReturnCode;

        //
        // Constructor
        //
        public Database(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Checker
        public bool IsAvailable
        {
            get
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("SELECT 1", connection))
                        {
                            command.ExecuteScalar();
                        }
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //
        // CRUD Operations
        //

        #region Independent
        //
        // Independent
        //

        //// Create
        //public DbReturnCodes AddLocuitor(string nume, string prenume, Sexe sex, DateTime dataNasterii, string cnp, int camera)
        //{
        //    try
        //    {
        //        string queryString = "INSERT INTO Locuitori (nume, prenume, sex, data_nasterii, cnp, camera) " +
        //                             "VALUES (@Nume, @Prenume, @Sex, @dataNasterii, @Cnp, @Camera)";

        //        nume = Capitalize(nume.Trim());
        //        prenume = Capitalize(prenume.Trim());
        //        cnp = cnp.Trim();

        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();

        //            DbReturnCodes operationReturnCode = GetLocuitor(nume, prenume, sex, dataNasterii, cnp, camera, out _, connection);

        //            if (operationReturnCode == DbReturnCodes.RECORD_DONT_EXISTS)
        //            {
        //                using (SqlCommand command = new SqlCommand(queryString, connection))
        //                {
        //                    command.Parameters.Add("@Nume", SqlDbType.VarChar).Value = nume;
        //                    command.Parameters.Add("@Prenume", SqlDbType.VarChar).Value = prenume;
        //                    command.Parameters.Add("@Sex", SqlDbType.VarChar).Value = sex.ToString();
        //                    command.Parameters.Add("@dataNasterii", SqlDbType.Date).Value = dataNasterii;
        //                    command.Parameters.Add("@Cnp", SqlDbType.VarChar).Value = cnp;
        //                    command.Parameters.Add("@Camera", SqlDbType.Int).Value = camera;

        //                    if (command.ExecuteNonQuery() == 1) return DbReturnCodes.SUCCES;
        //                    else return DbReturnCodes.OPERATION_FAILED;
        //                }
        //            }
        //            else return (operationReturnCode == DbReturnCodes.RECORD_EXISTS) ? DbReturnCodes.RECORD_EXISTS
        //                    : operationReturnCode;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return DbReturnCodes.OPERATION_FAILED;
        //    }
        //}

        //// Read
        //public DbReturnCodes GetAllLocuitori(out DataTable locuitori, SortBy sortBy = SortBy.id)
        //{
        //    locuitori = null;

        //    try
        //    {
        //        string queryString = $"SELECT * FROM Locuitori ORDER BY {sortBy}";

        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            using (SqlCommand command = new SqlCommand(queryString, connection))
        //            {
        //                DbReturnCodes operationReturnCode = DataExtractor(command, out DataTable dataTable);
        //                if (operationReturnCode == DbReturnCodes.RECORD_EXISTS)
        //                {
        //                    RenameColumnsOfTable(ref dataTable);
        //                    locuitori = dataTable;
        //                }
        //                return operationReturnCode;
        //            }
        //        }
        //    }
        //    catch (Exception) { return DbReturnCodes.OPERATION_FAILED; }
        //}

        //// Update
        //public DbReturnCodes UpdateLocuitor(int id, string nume, string prenume, Sexe sex, DateTime dataNasterii, string cnp, int camera)
        //{
        //    if (id < 1) return DbReturnCodes.INVALID_INPUT_DATA;

        //    try
        //    {
        //        string queryString = "UPDATE Locuitori SET nume=@Nume, prenume=@Prenume, sex=@Sex, " +
        //                             "data_nasterii=@dataNasterii, cnp=@Cnp, camera=@Camera WHERE id=@Id";

        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();

        //            DbReturnCodes operationReturnCode = GetLocuitor(id, out _, connection);

        //            if (operationReturnCode == DbReturnCodes.RECORD_EXISTS)
        //            {
        //                using (SqlCommand command = new SqlCommand(queryString, connection))
        //                {
        //                    command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
        //                    command.Parameters.Add("@Nume", SqlDbType.VarChar).Value = Capitalize(nume.Trim());
        //                    command.Parameters.Add("@Prenume", SqlDbType.VarChar).Value = Capitalize(prenume.Trim());
        //                    command.Parameters.Add("@Sex", SqlDbType.VarChar).Value = sex.ToString();
        //                    command.Parameters.Add("@dataNasterii", SqlDbType.Date).Value = dataNasterii;
        //                    command.Parameters.Add("@Cnp", SqlDbType.VarChar).Value = cnp.Trim();
        //                    command.Parameters.Add("@Camera", SqlDbType.Int).Value = camera;

        //                    if (command.ExecuteNonQuery() == 1) return DbReturnCodes.SUCCES;
        //                    else return DbReturnCodes.OPERATION_FAILED;
        //                }
        //            }
        //            else return (operationReturnCode == DbReturnCodes.RECORD_DONT_EXISTS) ? DbReturnCodes.RECORD_DONT_EXISTS
        //                    : operationReturnCode;
        //        }
        //    }
        //    catch (Exception) { return DbReturnCodes.OPERATION_FAILED; }
        //}

        //// Delete
        //public DbReturnCodes DeleteLocuitor(int id)
        //{
        //    // validate input data
        //    if (id < 1) return DbReturnCodes.INVALID_INPUT_DATA;

        //    try
        //    {
        //        // create query string
        //        string queryString = "DELETE FROM Locuitori WHERE id=@Id";

        //        // create new connection
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            // open connection
        //            connection.Open();
        //            // find locuitor by ID
        //            DbReturnCodes operationReturnCode = GetLocuitor(id, out _, connection);
        //            // if this locuitor already exists
        //            if (operationReturnCode == DbReturnCodes.RECORD_EXISTS)
        //            {
        //                // create command
        //                using (SqlCommand command = new SqlCommand(queryString, connection))
        //                {
        //                    // add parameter
        //                    command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
        //                    // check command execution
        //                    if (command.ExecuteNonQuery() == 1) return DbReturnCodes.SUCCES;
        //                    else return DbReturnCodes.OPERATION_FAILED;
        //                }
        //            }
        //            // if this locuitor don't exists
        //            else return (operationReturnCode == DbReturnCodes.RECORD_DONT_EXISTS) ? DbReturnCodes.RECORD_DONT_EXISTS
        //                    : operationReturnCode;
        //        }
        //    }
        //    catch (Exception) { return DbReturnCodes.OPERATION_FAILED; }
        //}

        //// Suplimentar methods

        //private DbReturnCodes DataExtractor(SqlCommand command, out DataTable dataTable)
        //{
        //    dataTable = new DataTable();

        //    try
        //    {
        //        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
        //        {
        //            adapter.Fill(dataTable);

        //            return dataTable.Rows.Count > 0 ? DbReturnCodes.RECORD_EXISTS
        //                   : DbReturnCodes.RECORD_DONT_EXISTS;
        //        }
        //    }
        //    catch (Exception) { return DbReturnCodes.OPERATION_FAILED; }
        //}

        //public DbReturnCodes AnswerConverter(DataTable dataTable, out List<Locuitor> locuitori)
        //{
        //    locuitori = new List<Locuitor>();

        //    try
        //    {
        //        if (dataTable != null && dataTable.Rows.Count > 0)
        //        {
        //            foreach (DataRow locuitor in dataTable.Rows)
        //            {
        //                int id = Convert.ToInt32(locuitor["ID"]);
        //                string nume = locuitor["Nume"].ToString();
        //                string prenume = locuitor["Prenume"].ToString();
        //                Sexe sex = (Sexe)Enum.Parse(typeof(Sexe), locuitor["Sex"].ToString());
        //                DateTime dataNasterii = Convert.ToDateTime(locuitor["Data nasterii"].ToString());
        //                string cnp = locuitor["CNP"].ToString();
        //                int camera = Convert.ToInt32(locuitor["Camera"]);

        //                locuitori.Add(new Locuitor(id, nume, prenume, sex, dataNasterii, cnp, camera));
        //            }
        //            return DbReturnCodes.SUCCES;
        //        }
        //        else return DbReturnCodes.RECORD_DONT_EXISTS;
        //    }
        //    catch (Exception) { return DbReturnCodes.OPERATION_FAILED; }
        //}

        //public DbReturnCodes GetLocuitor(string nume, string prenume, Sexe sex, DateTime dataNasterii, string cnp, int camera, out DataTable dataTable, SqlConnection connection = null)
        //{
        //    dataTable = null;

        //    try
        //    {
        //        string queryString = "SELECT * from Locuitori WHERE " +
        //                             "nume=@Nume and prenume=@Prenume and " +
        //                             "sex=@Sex and data_nasterii=@dataNasterii and " +
        //                             "cnp=@Cnp and camera=@Camera";

        //        if (connection == null)
        //        {
        //            using (SqlConnection newConnection = new SqlConnection(connectionString))
        //            {
        //                newConnection.Open();

        //                using (SqlCommand command = new SqlCommand(queryString, newConnection))
        //                {
        //                    command.Parameters.Add("@Nume", SqlDbType.VarChar).Value = Capitalize(nume.Trim());
        //                    command.Parameters.Add("@Prenume", SqlDbType.VarChar).Value = Capitalize(prenume.Trim());
        //                    command.Parameters.Add("@Sex", SqlDbType.VarChar).Value = sex.ToString();
        //                    command.Parameters.Add("@dataNasterii", SqlDbType.Date).Value = dataNasterii;
        //                    command.Parameters.Add("@Cnp", SqlDbType.VarChar).Value = cnp.Trim();
        //                    command.Parameters.Add("@Camera", SqlDbType.Int).Value = camera;

        //                    operationReturnCode = DataExtractor(command, out DataTable dataTable0);
        //                    dataTable = dataTable0;
        //                    return operationReturnCode;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            using (SqlCommand command = new SqlCommand(queryString, connection))
        //            {
        //                command.Parameters.Add("@Nume", SqlDbType.VarChar).Value = nume;
        //                command.Parameters.Add("@Prenume", SqlDbType.VarChar).Value = prenume;
        //                command.Parameters.Add("@Sex", SqlDbType.VarChar).Value = sex.ToString();
        //                command.Parameters.Add("@dataNasterii", SqlDbType.Date).Value = dataNasterii;
        //                command.Parameters.Add("@Cnp", SqlDbType.VarChar).Value = cnp;
        //                command.Parameters.Add("@Camera", SqlDbType.Int).Value = camera;

        //                operationReturnCode = DataExtractor(command, out DataTable dataTable0);
        //                dataTable = dataTable0;
        //                return operationReturnCode;
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return DbReturnCodes.OPERATION_FAILED;
        //    }
        //}

        //public DbReturnCodes GetLocuitor(int id, out DataTable dataTable, SqlConnection connection = null)
        //{
        //    dataTable = null;

        //    try
        //    {
        //        string queryString = "SELECT * FROM Locuitori WHERE id=@Id";

        //        if (connection == null)
        //        {
        //            using (SqlConnection newConnection = new SqlConnection(connectionString))
        //            {
        //                newConnection.Open();

        //                using (SqlCommand command = new SqlCommand(queryString, newConnection))
        //                {
        //                    command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

        //                    operationReturnCode = DataExtractor(command, out DataTable dataTable0);
        //                    dataTable = dataTable0;

        //                    return (RenameColumnsOfTable(ref dataTable) == DbReturnCodes.SUCCES) ?
        //                            operationReturnCode : DbReturnCodes.OPERATION_FAILED;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            using (SqlCommand command = new SqlCommand(queryString, connection))
        //            {
        //                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

        //                operationReturnCode = DataExtractor(command, out DataTable dataTable0);
        //                dataTable = dataTable0;

        //                return (RenameColumnsOfTable(ref dataTable) == DbReturnCodes.SUCCES) ?
        //                        operationReturnCode : DbReturnCodes.OPERATION_FAILED;
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return DbReturnCodes.OPERATION_FAILED;
        //    }
        //}

        //private DbReturnCodes RenameColumnsOfTable(ref DataTable dataTable)
        //{
        //    try
        //    {
        //        foreach (DataColumn dataColumn in dataTable.Columns)
        //        {
        //            switch (dataColumn.ColumnName)
        //            {
        //                case "id":
        //                    dataColumn.ColumnName = "ID";
        //                    break;

        //                case "nume":
        //                    dataColumn.ColumnName = "Nume";
        //                    break;

        //                case "prenume":
        //                    dataColumn.ColumnName = "Prenume";
        //                    break;

        //                case "sex":
        //                    dataColumn.ColumnName = "Sex";
        //                    break;

        //                case "data_nasterii":
        //                    dataColumn.ColumnName = "Data nasterii";
        //                    break;

        //                case "cnp":
        //                    dataColumn.ColumnName = "CNP";
        //                    break;

        //                case "camera":
        //                    dataColumn.ColumnName = "Camera";
        //                    break;
        //            }
        //        }
        //        return DbReturnCodes.SUCCES;
        //    }
        //    catch (Exception)
        //    {
        //        return DbReturnCodes.OPERATION_FAILED;
        //    }
        //}
        #endregion Independent

        static public string Capitalize(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;

            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }

        //
        // Dependent
        //

        public DbReturnCodes GetLastId(out int id)
        {
            id = 0;

            try
            {
                string queryString = "SELECT MAX(id) AS LastID FROM Locuitori";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            id = Convert.ToInt32(result);
                            return DbReturnCodes.SUCCES;
                        }
                        else return DbReturnCodes.RECORD_DONT_EXISTS;
                    }
                }
            }
            catch (Exception)
            {
                return DbReturnCodes.OPERATION_FAILED;
            }
        }

        // Create
        public DbReturnCodes AddLocuitor(string nume, string prenume, Sexe sex, DateTime dataNasterii, string cnp, int camera, out int id)
        {
            id = 0;

            try
            {
                string queryString = "INSERT INTO Locuitori (nume, prenume, sex, data_nasterii, cnp, camera) " +
                                     "VALUES (@Nume, @Prenume, @Sex, @dataNasterii, @Cnp, @Camera);" +
                                     "SELECT SCOPE_IDENTITY()";

                nume = Capitalize(nume.Trim());
                prenume = Capitalize(prenume.Trim());
                cnp = cnp.Trim();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        command.Parameters.Add("@Nume", SqlDbType.VarChar).Value = nume;
                        command.Parameters.Add("@Prenume", SqlDbType.VarChar).Value = prenume;
                        command.Parameters.Add("@Sex", SqlDbType.VarChar).Value = sex.ToString();
                        command.Parameters.Add("@dataNasterii", SqlDbType.Date).Value = dataNasterii;
                        command.Parameters.Add("@Cnp", SqlDbType.VarChar).Value = cnp;
                        command.Parameters.Add("@Camera", SqlDbType.Int).Value = camera;

                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            id = Convert.ToInt32(result);
                            return DbReturnCodes.SUCCES;
                        }
                        else return DbReturnCodes.OPERATION_FAILED;
                    }
                }
            }
            catch (Exception)
            {
                return DbReturnCodes.OPERATION_FAILED;
            }
        }

        // Read
        public DbReturnCodes GetAllLocuitori(out DataTable locuitori, SortBy sortBy = SortBy.id)
        {
            locuitori = null;

            try
            {
                string queryString = $"SELECT * FROM Locuitori ORDER BY {sortBy}";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        DbReturnCodes operationReturnCode = DataExtractor(command, out DataTable dataTable);
                        if (operationReturnCode == DbReturnCodes.RECORD_EXISTS)
                        {
                            RenameColumnsOfTable(ref dataTable);
                            locuitori = dataTable;
                        }
                        return operationReturnCode;
                    }
                }
            }
            catch (Exception) { return DbReturnCodes.OPERATION_FAILED; }
        }

        // Update
        public DbReturnCodes UpdateLocuitor(int id, string nume, string prenume, Sexe sex, DateTime dataNasterii, string cnp, int camera)
        {
            if (id < 1) return DbReturnCodes.INVALID_INPUT_DATA;

            try
            {
                string queryString = "UPDATE Locuitori SET nume=@Nume, prenume=@Prenume, sex=@Sex, " +
                                     "data_nasterii=@dataNasterii, cnp=@Cnp, camera=@Camera WHERE id=@Id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                        command.Parameters.Add("@Nume", SqlDbType.VarChar).Value = Capitalize(nume.Trim());
                        command.Parameters.Add("@Prenume", SqlDbType.VarChar).Value = Capitalize(prenume.Trim());
                        command.Parameters.Add("@Sex", SqlDbType.VarChar).Value = sex.ToString();
                        command.Parameters.Add("@dataNasterii", SqlDbType.Date).Value = dataNasterii;
                        command.Parameters.Add("@Cnp", SqlDbType.VarChar).Value = cnp.Trim();
                        command.Parameters.Add("@Camera", SqlDbType.Int).Value = camera;

                        if (command.ExecuteNonQuery() == 1) return DbReturnCodes.SUCCES;
                        else return DbReturnCodes.OPERATION_FAILED;
                    }
                }
            }
            catch (Exception) { return DbReturnCodes.OPERATION_FAILED; }
        }

        // Delete
        public DbReturnCodes DeleteLocuitor(int id)
        {
            // validate input data
            if (id < 1) return DbReturnCodes.INVALID_INPUT_DATA;

            try
            {
                // create query string
                string queryString = "DELETE FROM Locuitori WHERE id=@Id";

                // create new connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // open connection
                    connection.Open();

                    // create command
                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        // add parameter
                        command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                        // check command execution
                        if (command.ExecuteNonQuery() == 1) return DbReturnCodes.SUCCES;
                        else return DbReturnCodes.OPERATION_FAILED;
                    }
                }
            }
            catch (Exception) { return DbReturnCodes.OPERATION_FAILED; }
        }

        // Suplimentar methods

        private DbReturnCodes DataExtractor(SqlCommand command, out DataTable dataTable)
        {
            dataTable = new DataTable();

            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);

                    return dataTable.Rows.Count > 0 ? DbReturnCodes.RECORD_EXISTS
                           : DbReturnCodes.RECORD_DONT_EXISTS;
                }
            }
            catch (Exception) { return DbReturnCodes.OPERATION_FAILED; }
        }

        public DbReturnCodes AnswerConverter(DataTable dataTable, out List<Locuitor> locuitori)
        {
            locuitori = new List<Locuitor>();

            try
            {
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach (DataRow locuitor in dataTable.Rows)
                    {
                        int id = Convert.ToInt32(locuitor["ID"]);
                        string nume = locuitor["Nume"].ToString();
                        string prenume = locuitor["Prenume"].ToString();
                        Sexe sex = (Sexe)Enum.Parse(typeof(Sexe), locuitor["Sex"].ToString());
                        DateTime dataNasterii = Convert.ToDateTime(locuitor["Data nasterii"].ToString());
                        string cnp = locuitor["CNP"].ToString();
                        int camera = Convert.ToInt32(locuitor["Camera"]);

                        locuitori.Add(new Locuitor(id, nume, prenume, sex, dataNasterii, cnp, camera));
                    }
                    return DbReturnCodes.SUCCES;
                }
                else return DbReturnCodes.RECORD_DONT_EXISTS;
            }
            catch (Exception) { return DbReturnCodes.OPERATION_FAILED; }
        }

        public DbReturnCodes GetLocuitor(string nume, string prenume, Sexe sex, DateTime dataNasterii, string cnp, int camera, out DataTable dataTable, SqlConnection connection = null)
        {
            dataTable = null;

            try
            {
                string queryString = "SELECT * from Locuitori WHERE " +
                                     "nume=@Nume and prenume=@Prenume and " +
                                     "sex=@Sex and data_nasterii=@dataNasterii and " +
                                     "cnp=@Cnp and camera=@Camera";

                if (connection == null)
                {
                    using (SqlConnection newConnection = new SqlConnection(connectionString))
                    {
                        newConnection.Open();

                        using (SqlCommand command = new SqlCommand(queryString, newConnection))
                        {
                            command.Parameters.Add("@Nume", SqlDbType.VarChar).Value = Capitalize(nume.Trim());
                            command.Parameters.Add("@Prenume", SqlDbType.VarChar).Value = Capitalize(prenume.Trim());
                            command.Parameters.Add("@Sex", SqlDbType.VarChar).Value = sex.ToString();
                            command.Parameters.Add("@dataNasterii", SqlDbType.Date).Value = dataNasterii;
                            command.Parameters.Add("@Cnp", SqlDbType.VarChar).Value = cnp.Trim();
                            command.Parameters.Add("@Camera", SqlDbType.Int).Value = camera;

                            operationReturnCode = DataExtractor(command, out DataTable dataTable0);
                            dataTable = dataTable0;
                            return operationReturnCode;
                        }
                    }
                }
                else
                {
                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        command.Parameters.Add("@Nume", SqlDbType.VarChar).Value = nume;
                        command.Parameters.Add("@Prenume", SqlDbType.VarChar).Value = prenume;
                        command.Parameters.Add("@Sex", SqlDbType.VarChar).Value = sex.ToString();
                        command.Parameters.Add("@dataNasterii", SqlDbType.Date).Value = dataNasterii;
                        command.Parameters.Add("@Cnp", SqlDbType.VarChar).Value = cnp;
                        command.Parameters.Add("@Camera", SqlDbType.Int).Value = camera;

                        operationReturnCode = DataExtractor(command, out DataTable dataTable0);
                        dataTable = dataTable0;
                        return operationReturnCode;
                    }
                }
            }
            catch (Exception)
            {
                return DbReturnCodes.OPERATION_FAILED;
            }
        }

        public DbReturnCodes GetLocuitor(int id, out DataTable dataTable, SqlConnection connection = null)
        {
            dataTable = null;

            try
            {
                string queryString = "SELECT * FROM Locuitori WHERE id=@Id";

                if (connection == null)
                {
                    using (SqlConnection newConnection = new SqlConnection(connectionString))
                    {
                        newConnection.Open();

                        using (SqlCommand command = new SqlCommand(queryString, newConnection))
                        {
                            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                            operationReturnCode = DataExtractor(command, out DataTable dataTable0);
                            dataTable = dataTable0;

                            return (RenameColumnsOfTable(ref dataTable) == DbReturnCodes.SUCCES) ?
                                    operationReturnCode : DbReturnCodes.OPERATION_FAILED;
                        }
                    }
                }
                else
                {
                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                        operationReturnCode = DataExtractor(command, out DataTable dataTable0);
                        dataTable = dataTable0;

                        return (RenameColumnsOfTable(ref dataTable) == DbReturnCodes.SUCCES) ?
                                operationReturnCode : DbReturnCodes.OPERATION_FAILED;
                    }
                }
            }
            catch (Exception)
            {
                return DbReturnCodes.OPERATION_FAILED;
            }
        }

        private DbReturnCodes RenameColumnsOfTable(ref DataTable dataTable)
        {
            try
            {
                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    switch (dataColumn.ColumnName)
                    {
                        case "id":
                            dataColumn.ColumnName = "ID";
                            break;

                        case "nume":
                            dataColumn.ColumnName = "Nume";
                            break;

                        case "prenume":
                            dataColumn.ColumnName = "Prenume";
                            break;

                        case "sex":
                            dataColumn.ColumnName = "Sex";
                            break;

                        case "data_nasterii":
                            dataColumn.ColumnName = "Data nasterii";
                            break;

                        case "cnp":
                            dataColumn.ColumnName = "CNP";
                            break;

                        case "camera":
                            dataColumn.ColumnName = "Camera";
                            break;
                    }
                }
                return DbReturnCodes.SUCCES;
            }
            catch (Exception)
            {
                return DbReturnCodes.OPERATION_FAILED;
            }
        }

        //
        // Admins
        //

        public DbReturnCodes CheckAdmin(string login, string password, out DataTable admin)
        {
            admin = null;

            try
            {
                string queryString = "SELECT * FROM Admins WHERE " +
                                     "admin_login=@login AND admin_password=@password";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        command.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                        command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

                        operationReturnCode = DataExtractor(command, out DataTable dataTable);
                        admin = dataTable;

                        if (operationReturnCode == DbReturnCodes.RECORD_EXISTS)
                        {
                            return DbReturnCodes.RECORD_EXISTS;
                        }
                        else if (operationReturnCode == DbReturnCodes.RECORD_DONT_EXISTS)
                        {
                            return DbReturnCodes.RECORD_DONT_EXISTS;
                        }
                        else return DbReturnCodes.OPERATION_FAILED;
                    }
                }
            }
            catch (Exception) { return DbReturnCodes.OPERATION_FAILED; }
        }
    }
}
