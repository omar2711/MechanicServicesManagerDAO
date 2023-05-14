using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mechanicDAO.Model;

namespace mechanicDAO.Model
{
    public class productCategory:BaseTable
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public productCategory(int iD, string name, byte status, DateTime creationDate, DateTime modificationDate, int userID) 
            : base(status, creationDate, modificationDate, userID)
        {
            ID = iD;
            Name = name;
        }

        public productCategory(string name)
        {
            Name = name;
        }

        public productCategory(string name, int iD)
        {
            Name = name;
            ID = iD;
        }

        public productCategory(int iD)
        {
            ID = iD;
        }

        public productCategory()
        {
        }
        

    }
}
