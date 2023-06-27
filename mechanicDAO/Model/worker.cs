using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mechanicDAO.Model
{
    public class worker : person
    {
        public int RoleID { get; set; }
        public int BranchID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int ProfilePic { get; set; }
        public string Mail { get; set; }

        public worker(int roleID, int branchID, int personID, string userName, string password, int profilePic ,int iD, string name,  string lastName, string secondLastName, string cI, byte status, DateTime creationDate, DateTime modificationDate, int userID, string mail) 
            : base(iD, name, lastName, secondLastName, cI, status, creationDate, modificationDate, userID)
        {
            RoleID = roleID;
            BranchID = branchID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            ProfilePic = profilePic;
            Mail = mail;
        }


        public worker(int iD, string name, string lastName, string secondLastName, string cI, int roleID, int branchID, DateTime modificationDate, int userID, string mail)
            : base(iD, name,  lastName, secondLastName, cI, modificationDate, userID)
        {
            RoleID = roleID;
            BranchID = branchID;
            Mail = mail;
            
           
            
        }

        


        public worker(int roleID, int branchID, int personID, string userName, string password, int profilePic ,string name, string lastName, string secondLastName, string cI, string mail) 
            : base(name, lastName, secondLastName, cI)
        {
            RoleID = roleID;
            BranchID = branchID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            ProfilePic = profilePic;
            Mail = mail;
        }

        public worker(int roleID, int branchID, int personID, string userName, string password, int profilePic ,string name,  string lastName, string secondLastName, string cI, int iD, string mail) 
            : base(name,  lastName, secondLastName, cI, iD)
        {
            RoleID = roleID;
            BranchID = branchID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            ProfilePic = profilePic;
            Mail = mail;
        }

        public worker(int roleID, int branchID, int personID, string userName, string password, int profilePic, int iD, string mail) 
            : base(iD)
        {
            RoleID = roleID;
            BranchID = branchID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            ProfilePic = profilePic;
            Mail = mail;

        }

        public worker()
        {
        }

        public worker(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public worker(int iD)
            : base(iD)
        {
        }

        


        public worker(int iD, string name, string lastName, string secondLastName, string cI, byte status, DateTime modificationDate, int userID, string mail) 
            : base(iD, name,  lastName, secondLastName, cI, status,modificationDate, userID)
        {
            ID = iD;
            Name = name;
            LastName = lastName;
            SecondLastName = secondLastName;
            CI = cI;
            Status= status;
           
            ModificationDate= modificationDate;
            UserID= userID;
            Mail = mail;


        }





    }
}
