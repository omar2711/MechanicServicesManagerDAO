using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mechanicDAO.Model
{
    public class branch : BaseTable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public int provinceId { get; set; }
        public int countryId { get; set; }

        //make constructors

        public branch()
        {
        }

        public branch(int iD, string name, string lat, string lng, int provinceId, int countryId, byte status, DateTime creationDate, DateTime modificationDate, int userID)
            : base(status, creationDate, modificationDate, userID)
        {
            ID = iD;
            Name = name;
            Lat = lat;
            Lng = lng;
            this.provinceId = provinceId;
            this.countryId = countryId;
        }

        public branch(string name, string lat, string lng, int provinceId, int countryId)
        {
            Name = name;
            Lat = lat;
            Lng = lng;
            this.provinceId = provinceId;
            this.countryId = countryId;
        }

        //just the id

        public branch(int iD)
        {
            ID = iD;
        }

    }

    


}
