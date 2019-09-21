using POC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.DataAccess.RepositoryInterface
{
    public interface ICustomerRepository 
    {
        List<CustomerEntity> GetCustomerByName(string name);
        List<CustomerEntity> GetAllCustomers();
    }
}
