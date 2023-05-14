using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace mechanicDAO.Implementation
{
    public class BaseImpl
    {
        string connectionString = "Server=REDESA;Database=dbMechanic; Integrated Security=true";
        public SqlCommand CreateBasicCommand()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            return command;
        }

        public SqlCommand CreateBasicCommand(string query)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            return command;
        }

        public List<SqlCommand> CreateNBasicCommand(int n)
        {
            List<SqlCommand> commands = new List<SqlCommand>();
            SqlConnection connection = new SqlConnection(connectionString);
            for (int i = 0; i < n; i++)
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                commands.Add(command);
            }
            return commands;
        }


        public string GetGenerateIDTable(string tableName)
        {
            string query = " SELECT IDENT_CURRENT('" + tableName + "')+IDENT_INCR('" + tableName + "')";
            SqlCommand command = CreateBasicCommand(query);

            try
            {
                command.Connection.Open();
                return command.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }


        }


        public int ExecuteBasicCommand(SqlCommand command)
        {
            try
            {
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
        }


        public void ExecuteNBasicCommand(List<SqlCommand> commands)
        {
            SqlTransaction t = null;
            SqlCommand command0 = commands[0];
            try
            {
                command0.Connection.Open();
                t = command0.Connection.BeginTransaction();
                foreach (SqlCommand item in commands)
                {
                    item.Transaction = t;
                    item.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch (Exception ex)
            {
                t.Rollback();
                throw ex;
            }
            finally
            {
                command0.Connection.Close();
            }

        }

        public DataTable ExecuteDataTableCommand(SqlCommand command)
        {
            try
            {
                command.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        /// <summary>
        /// Se debe cerrar la conexión del SqlCommand cuando se use este método
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteDataReaderCommand(SqlCommand command)
        {
            SqlDataReader reader = null;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return reader;
        }
    }
}
