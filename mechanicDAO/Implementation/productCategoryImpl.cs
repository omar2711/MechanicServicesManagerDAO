using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mechanicDAO.Interfaces;
using mechanicDAO.Model;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using Microsoft.SqlServer.Server;

namespace mechanicDAO.Implementation
{
    public class productCategoryImpl : BaseImpl, IproductCategory
    {
        public int Delete(Model.productCategory t)
        {
            string query = @"UPDATE productCategory SET status = 0, modificationDate = CURRENT_TIMESTAMP, userId = @userId WHERE id = " + t.ID;
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

        public int Insert(Model.productCategory t)
        {
            string query = @"INSERT INTO productCategory(name, userId) VALUES (@name, 1)";
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

        public System.Data.DataTable Select()
        {
            string query = @"SELECT id, name AS Categoria, creationDate AS 'Fecha de Creacion' , modificationDate AS 'Fecha de Modificacion', userId AS 'Id del Empleado' FROM productCategory WHERE status = 1";
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

        public int Update(Model.productCategory t)
        {
            string query = @"UPDATE productCategory SET name = @name, modificationDate = CURRENT_TIMESTAMP, userId = @userId WHERE id = " + t.ID;
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", t.Name);
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

        public productCategory Get(byte id)
        {
            productCategory t = null;

            string query = @"SELECT id, name AS Categoria, status, creationDate AS 'Fecha de Creacion' , modificationDate AS 'Fecha de Modificacion', userId AS 'Id del Empleado' FROM productCategory WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = null;

            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    t = new productCategory(byte.Parse(reader[0].ToString()), reader[1].ToString(), byte.Parse(reader[2].ToString()), DateTime.Parse(reader[3].ToString()), DateTime.Parse(reader[4].ToString()), byte.Parse(reader[5].ToString()));
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
                reader.Close();
            }
            return t;

            
            

        }
    }       
}
