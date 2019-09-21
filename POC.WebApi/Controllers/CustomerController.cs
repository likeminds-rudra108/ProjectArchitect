using Autofac.Integration.WebApi;
using POC.Business.Customer.CustomerInterface;
using POC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POC.WebApi.Controllers
{
    [AutofacControllerConfiguration]
    public class CustomerController : ApiController
    {
        readonly ICustomerBusinessLayer _customerBusinessLayer;// { get; set; }
        public CustomerController(ICustomerBusinessLayer customerBusinessLayer)
        {
            _customerBusinessLayer = customerBusinessLayer;
        }
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_customerBusinessLayer.GetAllCustomers());

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
