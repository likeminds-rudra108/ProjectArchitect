using Autofac;
using POC.Business.Customer;
using POC.Business.Customer.CustomerInterface;
using POC.DataAccess.Repository;
using POC.DataAccess.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.DIModule
{
    public class RegisterDependancyInjectionModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerRequest().PropertiesAutowired();
            builder.RegisterType<CustomerBusinessLayer>().As<ICustomerBusinessLayer>().InstancePerRequest().PropertiesAutowired();
            base.Load(builder);
        }
    }
}
