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

        public worker(int roleID, int branchID, int personID, string userName, string password, int profilePic ,int iD, string name, string secondName, string lastName, string secondLastName, string cI, byte status, DateTime creationDate, DateTime modificationDate, int userID) 
            : base(iD, name, secondName, lastName, secondLastName, cI, status, creationDate, modificationDate, userID)
        {
            RoleID = roleID;
            BranchID = branchID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            ProfilePic = profilePic;
        }


        public worker(int iD, string name, string secondName, string lastName, string secondLastName, string cI, int roleID, int branchID, DateTime modificationDate, int userID)
            : base(iD, name, secondName, lastName, secondLastName, cI, modificationDate, userID)
        {
            RoleID = roleID;
            BranchID = branchID;
            
           
            
        }


        public worker(int roleID, int branchID, int personID, string userName, string password, int profilePic ,string name, string secondName, string lastName, string secondLastName, string cI) 
            : base(name, secondName, lastName, secondLastName, cI)
        {
            RoleID = roleID;
            BranchID = branchID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            ProfilePic = profilePic;
        }

        public worker(int roleID, int branchID, int personID, string userName, string password, int profilePic ,string name, string secondName, string lastName, string secondLastName, string cI, int iD) 
            : base(name, secondName, lastName, secondLastName, cI, iD)
        {
            RoleID = roleID;
            BranchID = branchID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            ProfilePic = profilePic;
        }

        public worker(int roleID, int branchID, int personID, string userName, string password, int profilePic, int iD) 
            : base(iD)
        {
            RoleID = roleID;
            BranchID = branchID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            ProfilePic = profilePic;
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


        public worker(int iD, string name, string secondName, string lastName, string secondLastName, string cI, byte status, DateTime creationDate, DateTime modificationDate, int userID) 
            : base(iD, name, secondName, lastName, secondLastName, cI, status, creationDate, modificationDate, userID)
        {
            ID = iD;
            Name = name;
            SecondName = secondName;
            LastName = lastName;
            SecondLastName = secondLastName;
            CI = cI;
            Status= status;
            CreationDate= creationDate;
            ModificationDate= modificationDate;
            UserID= userID;


        }





    }
}
