using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapi.Services.Models;
using Webapi.Services.Services.Customerservice;


namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        public CustomerController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> GetAllCustomers(bool? isActive = null)
        {
            var customers = _customerService.GetAllCustomers(isActive);
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerDto> GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult<CustomerDto> AddCustomer([FromBody] CustomerDto CustomerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCustomer = _customerService.AddCustomer(CustomerDto);
            return CreatedAtAction(nameof(GetCustomerById), new { id = newCustomer.Id }, newCustomer);
        }
        //private readonly IMapper _mapper;
        [HttpPut("{id}")]
        public ActionResult<CustomerDto> UpdateCustomer(int id, [FromBody] CustomerDto CustomerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedCustomer = _customerService.UpdateCustomer(id, CustomerDto);
            if (updatedCustomer == null)
            {
                return NotFound();
            }

            return Ok(updatedCustomer);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var deleted = _customerService.DeleteCustomerById(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
