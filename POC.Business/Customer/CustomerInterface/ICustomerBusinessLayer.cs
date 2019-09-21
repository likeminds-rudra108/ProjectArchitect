using POC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Business.Customer.CustomerInterface
{
    public interface ICustomerBusinessLayer
    {

        List<CustomerEntity> GetCustomerByName(string name);
        List<CustomerEntity> GetAllCustomers();
    }
}
