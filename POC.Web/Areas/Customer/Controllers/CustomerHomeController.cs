
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

using System.Threading.Tasks;
using POC.Entity;

namespace POC.Web.Areas.Customer.Controllers
{
    public class CustomerHomeController : AsyncController
    {
        private string Base_URL = "http://localhost:51035/api/";

        //public ICustomerBusinessLayer customerBusinessLayer { get;  set; }
        public async Task<ActionResult> Index()
        {
            
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Base_URL);
                
                HttpResponseMessage response = await client.GetAsync("Customer");
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsAsync<IEnumerable<CustomerEntity>>();
                    return View(res);
                }
                else {
                    return View();
                }
            }
            
               
        }
    }
}