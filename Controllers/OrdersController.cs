using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Pharmacy.Data;
using E_Pharmacy.Models;

namespace E_Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly PharmacyDataContext _context;

        public OrdersController(PharmacyDataContext context)
        {
            _context = context;
        }

        /*// GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
         return await _context.Order.ToListAsync();
         }*/

        //GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder(string field, int value1, string value2, DateTime date)
        {
            if (field == "pharmacy" & value2 == "date")
            {
                return await _context.Order.Where(ord => ord.Pharmacy_id == value1 && ord.Date_time.Date == date).ToListAsync();
            }

            else if (field == "pharmacy" & value2 == null)
            {
                return await _context.Order.Where(ord => ord.Pharmacy_id == value1).ToListAsync();
            }

            else if (field == "customer" & value2 == "date")
            {
                return await _context.Order.Where(ord => ord.Customer_id == value1 && ord.Date_time.Date == date).ToListAsync();
            }

            else if (field == "customer" & value2 == null)
            {
                return await _context.Order.Where(ord => ord.Customer_id == value1).ToListAsync();
            }

            else if (field == "pharmacy" & value2 == "uncompleted")
            {
                return await _context.Order.Where(ord => ord.Pharmacy_id == value1 && ord.Status == "uncompleted").ToListAsync();
            }

            else if (field == "pharmacy" & value2 == "completed")
            {
                return await _context.Order.Where(ord => ord.Pharmacy_id == value1 && ord.Status2 == "completed").ToListAsync();
            }

            else if (field == "pharmacy" & value2 == "unseen")
            {
                return await _context.Order.Where(ord => ord.Pharmacy_id == value1 && ord.Status2 == "unseen").ToListAsync();
            }

            else if (field == "all")
            {
                return await _context.Order.ToListAsync();
            }




            return NotFound();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Order.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderID)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderID }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderID == id);
        }
    }
}
