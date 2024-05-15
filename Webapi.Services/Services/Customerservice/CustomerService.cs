using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webapi.Data.Entities;
using Webapi.Data.Migrations;
using Webapi.Services.Models;
using AppContext = Webapi.Data.Migrations.AppContext;

namespace Webapi.Services.Services.Customerservice
{
    public class CustomerService : ICustomerService
    {

        private readonly AppContext _context;
        private readonly IMapper _mapper;

        public CustomerService(AppContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public CustomerDto AddCustomer(CustomerDto CustomerDTO)
        {
            var customer = _mapper.Map<Customer>(CustomerDTO);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return _mapper.Map<CustomerDto>(customer);
        }


        public bool DeleteCustomerById(int id)
        {
            var customerToDelete = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customerToDelete == null)
            {
                return false;
            }

            _context.Customers.Remove(customerToDelete);
            _context.SaveChanges();
            return true;
        }

        public List<CustomerDto> GetAllCustomers(bool? IsActive)
        {
            var customers = _context.Customers.ToList();
            return _mapper.Map<List<CustomerDto>>(customers);
        }

        public CustomerDto GetCustomerById(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            return _mapper.Map<CustomerDto>(customer);
        }

        public CustomerDto UpdateCustomer(int id, CustomerDto CustomerDTO)
        {
            var customerToUpdate = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customerToUpdate == null)
            {
                return null;
            }

            _mapper.Map(CustomerDTO, customerToUpdate);
            _context.SaveChanges();

            return _mapper.Map<CustomerDto>(customerToUpdate);
        }

        

    } 


}
