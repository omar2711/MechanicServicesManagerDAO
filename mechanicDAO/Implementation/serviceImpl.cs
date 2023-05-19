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
    public class serviceImpl : BaseImpl, IService
    {
        public int Delete(service t)
        {
            string query = @"UPDATE service SET status = 0, modificationDate = CURRENT_TIMESTAMP, userId = @userId WHERE id = " + t.ID;
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@userId", SessionClass.ID);
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

        public int Insert(service t)
        {
            string query = @"INSERT INTO service(name, detail, price, userId) VALUES (@serviceName, @serviceDetail, @servicePrice, @userId)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@serviceName", t.ServiceName);
            command.Parameters.AddWithValue("@servicePrice", t.ServicePrice);
            command.Parameters.AddWithValue("@serviceDetail", t.ServiceDetail);
            command.Parameters.AddWithValue("@userId", SessionClass.ID);
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
            string query = @"SELECT id, name AS Servicio, detail AS 'Descripcion del Servicio', price AS Precio, creationDate AS 'Fecha de Creacion' , modificationDate AS 'Fecha de Modificacion', userId AS 'Id del Empleado' FROM service WHERE status = 1";
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

        public int Update(service t)
        {
            string query = @"UPDATE service SET name = @serviceName, detail = @serviceDetail, price = @servicePrice, modificationDate = CURRENT_TIMESTAMP, userId = @userId WHERE id = " + t.ID;
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@serviceName", t.ServiceName);
            command.Parameters.AddWithValue("@serviceDetail", t.ServiceDetail);
            command.Parameters.AddWithValue("@servicePrice", t.ServicePrice);
            command.Parameters.AddWithValue("@userId", SessionClass.ID);
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
    }
}
