using mechanicDAO.Interfaces;
using mechanicDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mechanicDAO.Implementation
{
    public class roleImpl : BaseImpl, IRole
    {
        public int Delete(role t)
        {
            string query = @"UPDATE role SET status = 0, modificationDate = CURRENT_TIMESTAMP, userId = @userId WHERE id = " + t.ID;
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@userId", t.UserID);
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

        public int Insert(role t)
        {
            string query = @"INSERT INTO role(name, description ,userId) VALUES (@name, 1)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", t.Name);
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

        public DataTable Select()
        {
            string query = @"SELECT id, name AS 'Nombre del Rol', description AS 'Descripcion del Rol',creationDate AS 'Fecha de Creacion' , modificationDate AS 'Fecha de Modificacion', userId AS 'Id del Empleado' FROM role WHERE status = 1";
            SqlCommand command = CreateBasicCommand(query);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable table = new DataTable();
            try
            {
                command.Connection.Open();
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

        public int Update(role t)
        {
            string query = @"UPDATE role SET name = @name, description = @description ,modificationDate = CURRENT_TIMESTAMP, userId = @userId WHERE id = " + t.ID;
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@description", t.Description);

            command.Parameters.AddWithValue("@userId", "1");
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

        public DataTable SelectComboRole()
        {
            string query = @"SELECT TOP (1000) [id]
                          ,[name]
                          ,[description]
                          ,[status]
                          ,[creationDate]
                          ,[modificationDate]
                          ,[userId]
                          FROM [dbMechanic].[dbo].[role]";

            SqlCommand command = CreateBasicCommand(query);

            try
            {
                return ExecuteDataTableCommand(command);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
