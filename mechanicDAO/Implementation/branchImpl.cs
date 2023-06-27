using mechanicDAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mechanicDAO.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace mechanicDAO.Implementation
{
    public class branchImpl : BaseImpl, IBranch
    {
        public int Delete(branch t)
        {
            string query = @"UPDATE branch SET status = 0, modificationDate = CURRENT_TIMESTAMP, userId = 1 WHERE id = " + t.ID;
            SqlCommand command = CreateBasicCommand(query);
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

        public int Insert(branch t)
        {
            string query = @"INSERT INTO branch(name, lat, long, provinceId, countryId, userId) values (@name, @lat, @long, @provinceId, @countryId, 1)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@lat", t.Lat);
            command.Parameters.AddWithValue("@long", t.Lng);
            command.Parameters.AddWithValue("@provinceId", t.provinceId);
            command.Parameters.AddWithValue("@countryId", t.countryId);

            try
            {
                return ExecuteBasicCommand(command);
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
            string query = @" SELECT B.id, B.name AS 'Nombre de la Sucursal',P.name AS Provincia, C.name AS Departamento, B.lat AS Latitud, B.long AS Longitud  
                              FROM branch B
                              INNER JOIN province P ON B.provinceId = P.id
                              INNER JOIN country C ON C.id = P.countryId
                              WHERE status = 1
                              ORDER BY 2";

            SqlCommand command = CreateBasicCommand(query);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
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

        public int Update(branch t)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectComboProvince(int Cid)
        {
            string query = @"SELECT TOP (1000) [id]
      ,[name]
      ,[countryId]
  FROM [dbMechanic].[dbo].[province] where countryId=@Cid";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@Cid", Cid);

            try
            {
                return ExecuteDataTableCommand(command);
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

        public DataTable SelectComboCountry()
        {
            string query = @"SELECT id, name FROM country";
            SqlCommand command = CreateBasicCommand(query);

            try
            {
                return ExecuteDataTableCommand(command);
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
