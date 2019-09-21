using POC.Business.Customer.CustomerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POC.Entity;
using POC.DataAccess.RepositoryInterface;
using POC.DataAccess.Repository;
using POC.Common.ExceptionHandling;

namespace POC.Business.Customer
{
    public class CustomerBusinessLayer : ICustomerBusinessLayer
    {
        public ICustomerRepository customerRepository { get; set; }

        public List<CustomerEntity> GetAllCustomers()
        {
            //customerRepository = new CustomerRepository();
            try
            {
                return customerRepository.GetAllCustomers();
            }
            catch (POCException ex)
            {
                throw new POCException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new POCException(ex.Message);
            }
        }

        public List<CustomerEntity> GetCustomerByName(string name)
        {
            //customerRepository = new CustomerRepository();
            try
            {
                return customerRepository.GetCustomerByName(name);
            }
            catch (POCException ex)
            {
                throw new POCException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new POCException(ex.Message);
            }

        }
    }
}
