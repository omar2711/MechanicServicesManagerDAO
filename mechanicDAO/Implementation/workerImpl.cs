using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mechanicDAO.Interfaces;
using mechanicDAO.Model;
using System.Data.SqlClient;
using System.ComponentModel;
using Microsoft.SqlServer.Server;
using System.Runtime.InteropServices.WindowsRuntime;

namespace mechanicDAO.Implementation
{
    public class workerImpl : BaseImpl, IWorker
    {
        public int Delete(worker t)
        {
            string query = @"UPDATE person SET status = 0, modificationDate = CURRENT_TIMESTAMP, userId = @userId WHERE id = " + t.ID;
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

        public void Insert(worker t)
        {
            string query1 = @"INSERT INTO person(name, secondName, lastName, secondLastName, ci, userId) VALUES (@name, @secondName, @lastName, @secondLastName, @ci, @userId)";
            string query2 = @"INSERT INTO worker (roleId, branchId, personId, userName, password, profilePic) VALUES (@roleId, @branchId, @personId, @userName, HASHBYTES('MD5', '@pass'), @profilePic)";

            List<SqlCommand> commands = CreateNBasicCommand(2);

            commands[0].CommandText= query1;
            commands[1].CommandText= query2;
            int id = int.Parse(GetGenerateIDTable("person"));

            commands[0].Parameters.AddWithValue("@name", t.Name);
            commands[0].Parameters.AddWithValue("@secondName", t.SecondName);
            commands[0].Parameters.AddWithValue("@lastName", t.LastName);
            commands[0].Parameters.AddWithValue("@secondLastName", t.SecondLastName);
            commands[0].Parameters.AddWithValue("@ci", t.CI);
            commands[0].Parameters.AddWithValue("@userId", SessionClass.ID);

            commands[1].Parameters.AddWithValue("@roleId", t.RoleID);
            commands[1].Parameters.AddWithValue("@branchId", t.BranchID);
            commands[1].Parameters.AddWithValue("@userName", t.UserName);
            commands[1].Parameters.AddWithValue("@pass", t.Password);
            commands[1].Parameters.AddWithValue("@profilePic", "1");
            commands[1].Parameters.AddWithValue("@personId", id);

            try
            {
                ExecuteNBasicCommand(commands);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                commands[0].Connection.Close();
                commands[1].Connection.Close();
            }
            
            

        }

        public DataTable Select()
        {
            string query = @"SELECT P.id, P.name AS Nombre, P.secondName AS 'Segundo Nombre', P.lastName AS 'Apellido Paterno', P.secondLastName AS 'Apellido Materno', P.ci AS CI, W.userName AS 'Nombre de Usuario', W.branchId AS Sucursal, R.name AS Rol, P.creationDate AS 'Fecha de Creacion', P.modificationDate AS 'Fecha de Modificacion', P.userId AS Usuario
                            FROM person P
                            INNER JOIN worker W ON P.id = W.personId
                            INNER JOIN role R ON R.id = W.roleId
                            WHERE P.status = 1";
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


        int IBase<worker>.Insert(worker t)
        {
            throw new NotImplementedException();
        }

        public int Update(worker t)
        {
            //update the person and worker atributes but without the password
            string query1 = @"UPDATE person SET name = @name, secondName = @secondName, lastName = @lastName, secondLastName = @secondLastName, ci = @ci, modificationDate = CURRENT_TIMESTAMP, userId = @userId WHERE id = " + t.ID;
            string query2 = @"UPDATE worker SET roleId = @roleId, branchId = @branchId, userName = @userName, modificationDate = CURRENT_TIMESTAMP WHERE id = " + t.ID;

            List<SqlCommand> commands = CreateNBasicCommand(2);

            commands[0].CommandText = query1;
            commands[1].CommandText = query2;

            commands[0].Parameters.AddWithValue("@name", t.Name);
            commands[0].Parameters.AddWithValue("@secondName", t.SecondName);
            commands[0].Parameters.AddWithValue("@lastName", t.LastName);
            commands[0].Parameters.AddWithValue("@secondLastName", t.SecondLastName);
            commands[0].Parameters.AddWithValue("@ci", t.CI);
            commands[0].Parameters.AddWithValue("@userId", SessionClass.ID);

            commands[1].Parameters.AddWithValue("@roleId", t.RoleID);
            commands[1].Parameters.AddWithValue("@branchId", t.BranchID);
            commands[1].Parameters.AddWithValue("@userName", t.UserName);

            try
            {
                ExecuteNBasicCommand(commands);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                commands[0].Connection.Close();
                commands[1].Connection.Close();
            }
        }

        public DataTable Login(string userName, string password)
        {
            string query = @"SELECT W.personId, W.userName, W.roleId, W.password
                                FROM worker W INNER JOIN person P ON P.id = W.personId
                                WHERE P.status = 1 AND W.userName = @userName AND W.password = HASHBYTES('MD5', '@pass')";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@userName", userName);
            command.Parameters.AddWithValue("@pass", password).SqlDbType = SqlDbType.VarChar;

            try
            {
                return ExecuteDataTableCommand(command);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        int IBase<worker>.Update(worker t)
        {
            throw new NotImplementedException();
        }

        public bool CompareUserName(string userName)
        {
            string query = @"SELECT userName FROM worker WHERE userName = @userName";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@userName", userName);
            try
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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

        //method to compare the password and personId of the user
        public bool ComparePassword(string password)
        {
            string query = @"SELECT W.personId, W.userName, W.roleId 
                                FROM worker W INNER JOIN person P ON P.id = W.personId
                                WHERE P.status = 1 AND W.personId = @personId AND W.password = HASHBYTES('MD5', '@pass')";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@personId", SessionClass.ID);
            command.Parameters.AddWithValue("@pass", password).SqlDbType = SqlDbType.VarChar;
            try
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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

        //select the actual password of the user
        public string SelectPassword()
        {
            string query = @"SELECT CAST(password AS VARCHAR(50)) AS password FROM worker WHERE personId = " + SessionClass.ID;
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return reader["password"].ToString();
                }
                else
                {
                    return null;
                }
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

        //update worker password
        public int UpdatePassword(string password)
        {
            string query = @"UPDATE worker SET password = HASHBYTES('MD5', '@pass') WHERE personId = " + SessionClass.ID;
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@pass", password).SqlDbType = SqlDbType.VarChar;
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

        //update worker username

        public int UpdateUserName(string userName)
        {
            string query = @"UPDATE worker SET userName = @userName WHERE personId = " + SessionClass.ID;
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@userName", userName);
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

    }
}
