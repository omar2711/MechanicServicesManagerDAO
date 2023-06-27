using mechanicDAO.Interfaces;
using mechanicDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace mechanicDAO.Implementation
{
    public class ClientImpl : BaseImpl, IClient
    {
        public int Delete(client t)
        {
            throw new NotImplementedException();
        }

        public int Insert(client t)
        {
            throw new NotImplementedException();
        }

        public void sendMail(string body, string to, string subject)
        {
            using (MailMessage mail = new MailMessage("minecraft3598@gmail.com", to, subject, body))
            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("minecraft3598@gmail.com", "rnkkljofwsaalwrb");
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }

        }

        public DataTable Login(client t, string pass)
        {
            string query = @"SELECT personId, userName, role FROM client WHERE status = 1 AND username = @username AND password = HASHBYTES('MD5','"+pass+"' )";
            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@username", t.Username);


            try
            {
                return ExecuteDataTableCommand(command);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsertQ(client t, string pass, string username)
        {
            int id = int.Parse(GetGenerateIDTable("person"));

            string query1 = @"INSERT INTO person (name, lastName, secondLastName, CI, userId) VALUES (@name, @lastName, @secondLastName, @CI, 1)";
            string query2 = @"INSERT INTO client (email, personId, password, username) VALUES (@email, @id ,HASHBYTES('MD5', '" + pass + "'), '" + username + "')";
            

            List<SqlCommand> commands = CreateNBasicCommand(2);


            commands[0].CommandText = query1;
            commands[1].CommandText = query2;

            commands[1].Parameters.AddWithValue("@email", t.Email);
            commands[1].Parameters.AddWithValue("@id", id);

            commands[0].Parameters.AddWithValue("@name", t.Name);
            commands[0].Parameters.AddWithValue("@lastName", t.LastName);
            commands[0].Parameters.AddWithValue("@secondLastName", t.SecondLastName);
            commands[0].Parameters.AddWithValue("@CI", t.CI);

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
            

            string query = @"SELECT C.id, C.name AS Nombre, C.lastName AS 'Apellido Paterno', C.secondLastName AS 'Apellido Materno', C.CI AS CI, P.email AS Email, P.username AS 'Nombre de Usuario' FROM person C
                                INNER JOIN client P ON P.personId = C.id
                                WHERE C.status = 1
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

        public void ChangePass(client t, string pass)
        {
            string query = @"UPDATE client SET password = HASHBYTES('MD5','"+pass+"') WHERE personId = @personId";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@personId", t.ID);
            try
            {
                ExecuteBasicCommand(command);
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

        public int Update(client t)
        {
            throw new NotImplementedException();
        }
    }
}
