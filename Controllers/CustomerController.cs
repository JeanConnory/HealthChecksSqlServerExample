using HealthCheckSample.Data;
using HealthCheckSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCheckSample.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDbContext _context;

        public CustomerController(CustomerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var customer = await _context.Customers.Where(c => c.Id == id).FirstOrDefaultAsync();
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Customer customer)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Add(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Customer customer)
        {
            var customerDb = await _context.Customers.FindAsync(id);
            if(customerDb == null)
                return NotFound();

            _context.Update(customer);
            await _context.SaveChangesAsync();

            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var customerDb = await _context.Customers.FindAsync(id);
            if (customerDb == null)
                return NotFound();

            _context.Remove(customerDb);
            await _context.SaveChangesAsync();
            return Ok(customerDb);
        }
    }
}
