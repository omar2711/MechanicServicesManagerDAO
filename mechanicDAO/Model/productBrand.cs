using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mechanicDAO.Model
{
    public class productBrand : BaseTable
    {

        public int ID { get; set; }
        public string Name { get; set; }

        public productBrand(int id, string name, byte status, DateTime creationDate, DateTime modificationDate, int userID)
            : base(status, creationDate, modificationDate, userID)
        {
            ID = id;
            Name = name;
        }

        public productBrand(string name, DateTime modificationDate, int userID)
            : base(modificationDate, userID)
        {
            Name = name;
        }

        public productBrand(int id, byte status, DateTime modificationDate, int userID)
            : base(status, modificationDate, userID)
        {
            ID = id;
        }   

        



        


    }
}
