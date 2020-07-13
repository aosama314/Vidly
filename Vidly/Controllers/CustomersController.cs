using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Controllers.API;
using AutoMapper;
using Vidly.Dtos;

namespace Vidly.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        //private VidlyContext Context;

        private ApplicationDbContext Context;

        public CustomersController()
        {

            Context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            Context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = Context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel()
                {
                    Customer = customer,
                    MembershipTypes = Context.MembershipTypes.ToList()
                };
                return View("New", viewModel);
            }
            if (customer.ID == 0)
            {
                Context.Customers.Add(customer);

                //API.CustomersController api = new API.CustomersController();
                //api.CreateCustomer(Mapper.Map<Customer, CustomerDto>(customer));
            }
            else
            {
                var customerInDb = Context.Customers.Single(c => c.ID == customer.ID);

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }
            Context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
        public ActionResult Edit(int id)
        {
            var customer = Context.Customers.SingleOrDefault(c => c.ID == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel()
            {
                Customer = customer,
                MembershipTypes = Context.MembershipTypes.ToList()
            };
            return View("New", viewModel);
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = Context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int? id)
        {
            var customer = Context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.ID == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
        
    }
}