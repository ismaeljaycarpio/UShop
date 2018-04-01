using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UShop.Entities;
using UShop.Models;
using UShop.Dto;
using AutoMapper;
using System.Data.Entity;

namespace UShop.Controllers.Api
{
    public class CustomersController : ApiController //derived from api controller
    {
        private ApplicationDbContext context;

        public CustomersController()
        {
            context = new ApplicationDbContext();
        }

        // GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomers(int id)
        {
            var customer = context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();
                //throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
                //throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            context.Customers.Add(customer);
            context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto); //201 Created
        }

        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
                //throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();
                //throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);

            //ustomerInDb.Name = customer.Name;
            //customerInDb.BirthDate = customer.BirthDate;
            //customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            //customerInDb.MembershipTypeId = customer.MembershipTypeId;

            context.SaveChanges();

            return Ok(Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb));
            //return Ok();
        }


        // DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();
                //throw new HttpResponseException(HttpStatusCode.NotFound);

            context.Customers.Remove(customerInDb); //remove in-memory
            context.SaveChanges();

            return Ok();
        }


    }
}
