using AutoMapper;
using DataAccessLayer.Repository;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Services.Data;
using Implementation.Implementation;

namespace CustomerManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()
        {
            var customers = await _customerService.GetAllAsync();
            return Ok(customers);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<CustomerDto>> GetById(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddAsync(CustomerDto customer)
        {
            await _customerService.AddAsync(customer);
            return Ok("Customer is created");
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, CustomerDto customer)
        {
            await _customerService.UpdateAsync(id, customer);

            return Ok("Customer is updated");
        }


        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _customerService.DeleteAsync(id);
            return Ok("Customer is deleted");
        }
    }
}