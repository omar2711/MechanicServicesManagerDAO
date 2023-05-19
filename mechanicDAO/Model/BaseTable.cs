using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mechanicDAO.Model
{
    public class BaseTable
    {
        public byte Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public int UserID { get; set; }

        public BaseTable(byte status, DateTime creationDate, DateTime modificationDate, int userID)
        {
            Status = status;
            CreationDate = creationDate;
            ModificationDate = modificationDate;
            UserID = userID;
        }

        public BaseTable(DateTime modificationDate, int userID)
        {
            ModificationDate = modificationDate;
            UserID = userID;
        }

        public BaseTable( int userID)
        {
            
            UserID = userID;
        }
        public BaseTable()
        {

        }
    }
}

