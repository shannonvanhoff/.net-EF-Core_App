using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webapi.Data.Entities;
using Webapi.Services.Models;

namespace Webapi.Services.Services.Customerservice
{
    public interface ICustomerService
    {
        List<CustomerDto> GetAllCustomers(bool? IsActive);
        CustomerDto GetCustomerById(int id);
        CustomerDto AddCustomer(CustomerDto CustomerDto);
        CustomerDto UpdateCustomer(int id, CustomerDto CustomerDto);
        bool DeleteCustomerById(int id);
    }
}
