using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mechanicDAO.Model
{
    public class role:BaseTable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //make the same as product category but with this variables
        public role(int iD, string name, string description, byte status, DateTime creationDate, DateTime modificationDate, int userID) 
            : base(status, creationDate, modificationDate, userID)
        {
            ID = iD;
            Name = name;
            Description = description;
        }

        public role(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public role(string name, string description, int iD)
        {
            Name = name;
            Description = description;
            ID = iD;
        }

        public role(int iD)
        {
            ID = iD;
        }

        public role()
        {
        }
    }
}
