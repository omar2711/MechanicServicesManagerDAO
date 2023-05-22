using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mechanicDAO.Model;

namespace mechanicDAO.Interfaces
{
    public interface IWorker : IBase<worker>
    {
        int Update(worker t);

        void Update2(worker t, person p);

        DataTable Login(string userName, string password);

    }
}
