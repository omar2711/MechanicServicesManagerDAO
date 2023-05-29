using mechanicDAO.Interfaces;
using mechanicDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace mechanicDAO.Implementation
{
    public class productBrandImpl : BaseImpl, IProductBrand
    {
        public int Delete(productBrand t)
        {
            throw new NotImplementedException();
        }

        public int Insert(productBrand t)
        {
            throw new NotImplementedException();
        }

        public DataTable Select()
        {
            throw new NotImplementedException();
            
        }

        public DataTable SelectComboBrand()
        {
            string query = @"SELECT id, name FROM productBrand WHERE status = 1";
            SqlCommand command = CreateBasicCommand(query);
            
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }

        }

        public int Update(productBrand t)
        {
            throw new NotImplementedException();
        }
    }
}
