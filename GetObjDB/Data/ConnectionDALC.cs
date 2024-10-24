using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;


namespace GetObjDB.Data
{
    internal class ConnectionDALC
    {
        private string _connectionString;

        public ConnectionDALC(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public SqlConnection GetConnection() 
        {
            return new SqlConnection(_connectionString);
        }

        public DataTable ExecuteQuery(string query)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Console.WriteLine($"Error: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }

                return dataTable;
            }
        }

        public void ExecuteNonQuery(string query)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Console.WriteLine($"Error: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public DataTable ExecuteStoredProcedure(string procedureName, SqlParameter[] parameters)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(procedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);

                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Console.WriteLine($"Error: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }

                return dataTable;
            }
        }
        public bool TestConnection()
        {
            try
            {
                SqlConnection Conn = new SqlConnection("");
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "";
            }
            catch { }
            return true;
        }
    }
}
