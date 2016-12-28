using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRental.Models;
using MovieRental.ViewModel;

namespace MovieRental.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var CustomerList = new List<Customer>
            {
                new Customer {CustomerName = "Prem" },
                new Customer {CustomerName = "kumar" }
            };

            var CustomerViewModel = new CustomerViewModel()
            {
                CustomerList = CustomerList
            };
            return View(CustomerViewModel);
        }
    }
}