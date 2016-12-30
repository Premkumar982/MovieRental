using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MovieRental.Models;
using MovieRental.ViewModel;

namespace MovieRental.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        // GET: Customer

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            /*var CustomerViewModel = new CustomerViewModel()
            {
                CustomerList = _context.Customers.ToList()
            };
            return View(CustomerViewModel);*/

            var CustomerDetails = _context.Customers.Include(c=>c.CustomerMembershipType).ToList();
            return View(CustomerDetails);
        }
        [Route("Customer/Details/{CustId}")]
        public ActionResult Details(int CustId)
        {
            //var CustomerDetails = CustomerList.Where(c => c.Id == CustId).ToList();
            var CustomerDetails = _context.Customers.Include(m=>m.CustomerMembershipType)
                                                    .Where(c => c.Id == CustId).ToList();
            //var CustomerVM = new CustomerViewModel()
            //{
            //    CustomerList = CustomerDetails
            //};
            return View(CustomerDetails);
        }

        //public List<Customer> GetCustomerList()
        //{
        //    List<Customer> CustomerList = new List<Customer>
        //    {
        //        new Customer {Id=1, CustomerName = "Prem" },
        //        new Customer {Id=2, CustomerName = "kumar" }
        //    };
        //    return CustomerList;
        //}
    }
}