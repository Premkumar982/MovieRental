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
        public ActionResult New()
        {
            var MembershipTypes = _context.MembershipTypes.ToList();
            var NewCustomerVM = new NewCustomerViewModel()
            {
                MembershipTypes = MembershipTypes
            };
            return View(NewCustomerVM);
        }
        [HttpPost]
        public ActionResult CreateCustomer(NewCustomerViewModel NewCustomerDetails)
        {
            Customer CustDetails = new Customer()
            {
                CustomerName = NewCustomerDetails.Customer.CustomerName,
                DateOfBirth = NewCustomerDetails.Customer.DateOfBirth,
                IsSubscribedtoNewsLetter = NewCustomerDetails.Customer.IsSubscribedtoNewsLetter,
                MembershipTypeId = NewCustomerDetails.Customer.MembershipTypeId
            };
            _context.Customers.Add(CustDetails);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
            
        }

        public ActionResult Edit(int CustId)
        {
            var Customer = _context.Customers.Include(m=>m.CustomerMembershipType).Where(c => c.Id == CustId).ToList();
            return View(Customer);
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