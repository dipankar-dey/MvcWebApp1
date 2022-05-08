using AutoMapper;
using MyFirstMVCWebApp.Dtos;
using MyFirstMVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFirstMVCWebApp.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }

        public CustomerDto GetCustomer(int id)
        {
            var customer= _context.Customers.SingleOrDefault(c=>c.Id==id);

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Customer,CustomerDto>(customer);
        }

        [HttpPost]
        public CustomerDto SaveCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return customerDto;
        }

        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            }


            var customerInDb = _context.Customers.Single(c=>c.Id==id);

            if (customerInDb==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map(customerDto, customerInDb);

            

            _context.SaveChanges();

            

        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.Single(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

        }


    }
}
