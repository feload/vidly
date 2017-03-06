using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly List<Customer> _customers;
        public CustomersController()
        {
            _customers = new List<Customer>()
            {
                new Customer() { Id = 1, Name = "Juan" },
                new Customer() { Id = 2, Name = "Petra" },
            };
        }
        // GET: Customers
        public ActionResult Index()
        {
            return View(_customers);
        }

        public ActionResult Details(int Id)
        {
            return View(_customers.Find(c => c.Id == Id));
        }
    }
}