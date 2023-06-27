using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mechanicDAO.Model
{
    public class client : person
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        //constructors

        public client(int iD, string name, string lastName, string secondLastName, string cI, string email, string username, string password, string role, byte status, DateTime creationDate, DateTime modificationDate, int userID)
            : base(iD, name, lastName, secondLastName, cI, status, creationDate, modificationDate, userID)
        {
            Email = email;
            Username = username;
            Password = password;
            Role = role;
        }

        public client(string name, string lastName, string secondLastName, string cI, string email, string username, string password, string role)
            : base(name, lastName, secondLastName, cI)
        {
            Email = email;
            Username = username;
            Password = password;
            Role = role;
        }

        public client(string name, string lastName, string secondLastName, string cI, string email, string username, string password, string role, int iD)
            : base(name, lastName, secondLastName, cI, iD)
        {
            Email = email;
            Username = username;
            Password = password;
            Role = role;
        }

        public client(int iD, string name, string lastName, string secondLastName, string cI, string email, string username, string password, string role, DateTime modificationDate, int userID)
            : base(iD, name, lastName, secondLastName, cI, modificationDate, userID)
        {
            Email = email;
            Username = username;
            Password = password;
            Role = role;
        }

        public client(int iD)
            : base(iD)
        {
        }

        public client()
        {

        }

        public client(string password)
        {
            Password = password;
        }


    }
}
