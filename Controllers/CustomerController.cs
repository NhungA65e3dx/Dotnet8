using Dotnet8.Model;
using Dotnet8.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] bool? isActive = null)
        {
            var customer = await _customerService.GetAllCustomers(isActive);
            return Ok(customer);
        }
        [HttpGet("{id}")]
        //[Route("{id}")] // /api/OurHero/:id
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _customerService.GetCustomersByID(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUpdateCustomer CustomerObject)
        {
            var customer = await _customerService.AddCustomer(CustomerObject);

            if (customer == null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                message = "Customer Created Successfully!!!",
                id = customer!.Id
            });
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] AddUpdateCustomer CustomerObject)
        {
            var customer = await _customerService.UpdateCustomer(id, CustomerObject);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Customer Updated Successfully!!!",
                id = customer!.Id
            });
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!await _customerService.DeleteCustomersByID(id))
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Super Hero Deleted Successfully!!!",
                id = id
            });
        }
    }
}
