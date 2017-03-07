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
        private Context _context;
        public CustomersController()
        {
            _context = new Context();
        }
        

        public ActionResult Index()
        {
            var customers = _context.Customers;
            return View(customers.ToList());
        }

        public ActionResult Details(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}