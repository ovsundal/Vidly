﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //model binding, data from form is automatically added to customer class
        public ActionResult Save(Customer customer)
        {
            //if model is not valid, return current form
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            //if new customer
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            //if existing customer
            else
            {
                //get customer from database, do changes, and save
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //update automatically. Should not use, because a malicious user can add parameters and update
                //key data (this method will update all properties). If restrictions are set, magic strings are 
                //introduced
                //TryUpdateModel(customerInDb, "", new string[] {"Name", "Email")};

                //correct approach for updating
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter= customer.IsSubscribedToNewsLetter;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            //SingleOrDefault makes the query execute immediately
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            //Override view returned, if not "CustomerForm" it will return View of Edit
            return View("CustomerForm", viewModel);
        }
    }
}