using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mechanicDAO.Model
{
    public class product : BaseTable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int ProductBrandID { get; set; }
        public int ProductCategoryID { get; set; }
        public int Stock { get; set; }

        public product()
        {
        }

        public product(int iD, string name, double price, int productBrandID, int productCategoryID, int stock)
        {
            ID = iD;
            Name = name;
            Price = price;
            ProductBrandID = productBrandID;
            ProductCategoryID = productCategoryID;
            Stock = stock;
        }

        public product(int iD, string name, double price, int productBrandID, int productCategoryID, int stock, byte status, DateTime creationDate, DateTime modificationDate, int userID)
            : base(status, creationDate, modificationDate, userID)
        {
            ID = iD;
            Name = name;
            Price = price;
            ProductBrandID = productBrandID;
            ProductCategoryID = productCategoryID;
            Stock = stock;
            
        }

        public product(int iD, string name, double price, int productBrandID, int productCategoryID, int stock, DateTime modificationDate, int userID)
            : base(modificationDate, userID)
        {
            ID = iD;
            Name = name;
            Price = price;
            ProductBrandID = productBrandID;
            ProductCategoryID = productCategoryID;
            Stock = stock;
            
        }

        public product(int id, byte status, DateTime modificationDate, int userID)
            : base(status, modificationDate, userID)
        {
            ID = id;
        }

        public product(int id)
        {
            ID = id;
        }


    }
}
