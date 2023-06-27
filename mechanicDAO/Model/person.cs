using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mechanicDAO.Model
{
    public class person : BaseTable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string CI { get; set; }



        public person(int iD, string name, string lastName, string secondLastName, string cI, byte status, DateTime creationDate, DateTime modificationDate, int userID) 
            : base(status, creationDate, modificationDate, userID)
        {
            ID = iD;
            Name = name;
            LastName = lastName;
            SecondLastName = secondLastName;
            CI = cI;
        }

        public person(string name, string lastName, string secondLastName, string cI)
        {
            Name = name;
            LastName = lastName;
            SecondLastName = secondLastName;
            CI = cI;
        }

        public person(string name, string lastName, string secondLastName, string cI, int iD)
        {
            Name = name;
            LastName = lastName;
            SecondLastName = secondLastName;
            CI = cI;
            ID = iD;
        }

        public person(int iD, string name, string lastName, string secondLastName, string cI, DateTime modificationDate ,int userID)
            : base(modificationDate,userID)
        {
            ID = iD;
            Name = name;
            LastName = lastName;
            SecondLastName = secondLastName;
            CI = cI;
        }

        public person(int iD)
        {
            ID = iD;
        }

        public person()
        {
        }

        public person(int iD, string name, string secondName, string lastName, string cI, byte status, DateTime modificationDate, int userID) : this(iD)
        {
        }
    }

    

    

    

}
