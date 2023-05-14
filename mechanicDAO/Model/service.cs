using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mechanicDAO.Model
{
    public class service : BaseTable
    {
        public int ID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDetail { get; set; }
        public double ServicePrice { get; set; }

        //make the same as productCategory

        public service(int iD, string serviceName, string serviceDetail, double servicePrice, byte status, DateTime creationDate, DateTime modificationDate, int userID) 
            : base(status, creationDate, modificationDate, userID)
        {
            ID = iD;
            ServiceName = serviceName;
            ServiceDetail = serviceDetail;
            ServicePrice = servicePrice;

        }

        public service(string serviceName, string serviceDetail, double servicePrice)
        {
            ServiceName = serviceName;
            ServiceDetail = serviceDetail;
            ServicePrice = servicePrice;
        }

        public service(string serviceName, string serviceDetail, double servicePrice, int iD)
        {
            ServiceName = serviceName;
            ServiceDetail = serviceDetail;
            ServicePrice = servicePrice;
            ID = iD;
        }

        public service(int iD)
        {
            ID = iD;
        }

        public service()
        {
        }
    }
}
