using POC.DataAccess.POCEntityModel;
using POC.DataAccess.RepositoryInterface;
using POC.DataAccess.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POC.Entity;
using POC.Common.ExceptionHandling;

namespace POC.DataAccess.Repository
{
    public class CustomerRepository : Repository<ProjectArchitectureEntities1, Customer>, ICustomerRepository
    {
        public List<CustomerEntity> GetCustomerByName(string name)
        {
            try
            {
                var data = Context.Customers.Where(x => x.FirstName == name);

                return data.Select(x => new CustomerEntity()
                {
                    FirstName = x.FirstName,
                    City = x.City,
                    Country = x.Country,
                    Id = x.Id,
                    LastName = x.LastName,
                    Phone = x.Phone
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new POCException(ex.Message);
            }

        }
        public List<CustomerEntity> GetAllCustomers()
        {
            try
            {
                var data = GetAll();
                return data.Select(x => new CustomerEntity()
                {
                    FirstName = x.FirstName,
                    City = x.City,
                    Country = x.Country,
                    Id = x.Id,
                    LastName = x.LastName,
                    Phone = x.Phone
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new POCException(ex.Message);
            }
        }
    }
}
