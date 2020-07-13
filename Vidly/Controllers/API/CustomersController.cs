using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        //private VidlyContext Context;

        private ApplicationDbContext Context;

        public CustomersController()
        {
            Context = new ApplicationDbContext();
        }
        // GET /api/customers
        public IHttpActionResult GetCustomers()
        {
            return Ok(Context.Customers.
                Include(c => c.MembershipType).
                ToList().
                Select(Mapper.Map<Customer, CustomerDto>));
        }

        // GET /api/customers/ID
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = Context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.ID == id);

            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            Context.Customers.Add(customer);
            Context.SaveChanges();

            customerDto.ID = customer.ID;
            return Created(new Uri(Request.RequestUri + "/" + customer.ID), customerDto);
            //return Created(new Uri("/customers/index"), GetCustomers());
        }

        // PUT api/customers/ID 
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customerInDb = Context.Customers.SingleOrDefault(c => c.ID == id);

            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDb);
            
            Context.SaveChanges();
            return Ok();
        }

        // DELETE api/customer/ID
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customerInDb = Context.Customers.SingleOrDefault(c => c.ID == id);
            if (customerInDb == null)
                return NotFound();
            Context.Customers.Remove(customerInDb);
            Context.SaveChanges();
            return Ok();
        }
    }
}
