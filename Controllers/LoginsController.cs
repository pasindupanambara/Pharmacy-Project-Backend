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
    public class LoginsController : ControllerBase
    {
        private readonly PharmacyDataContext _context;

        public LoginsController(PharmacyDataContext context)
        {
            _context = context;
        }

        // GET: api/Logins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Login>>> GetLogin()
        {
            return await _context.Login.ToListAsync();
        }

        // GET: api/Logins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Login>> GetLogin(int id)
        {
            var login = await _context.Login.FindAsync(id);

            if (login == null)
            {
                return NotFound();
            }

            return login;
        }

        // PUT: api/Logins/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogin(int id, Login login)
        {
            if (id != login.Id)
            {
                return BadRequest();
            }

            _context.Entry(login).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginExists(id))
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

        // POST: api/Logins
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]

        public async Task<ActionResult<Login>> PostLogin(Login login)
        {

            var CheckEmailcustomer = _context.Customer.FirstOrDefault(m => m.Email.ToLower() == login.Email.ToLower()); //check email already exit or not
            var CheckPasswordcustomer = _context.Customer.FirstOrDefault(m => m.Password == login.Password);

            var CheckEmailpharmacy = _context.Pharmacy.FirstOrDefault(m => m.Email.ToLower() == login.Email.ToLower()); //check email already exit or not
            var CheckPasswordpharmacy = _context.Pharmacy.FirstOrDefault(m => m.Password == login.Password);

            if ((CheckEmailcustomer == null || CheckPasswordcustomer == null) && (CheckEmailpharmacy == null || CheckPasswordpharmacy == null))
            {
                return BadRequest(); //New page
            }

            else
            {
                _context.Login.Add(login);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetLogin", new { id = login.Id }, login);
            }
        }




        /*// POST: api/Logins/2
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        public async Task<ActionResult<Login>> Post2Login(Login login)
        {
            _context.Login.Add(login);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogin", new { id = login.Id }, login);
        } */

        // DELETE: api/Logins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Login>> DeleteLogin(int id)
        {
            var login = await _context.Login.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            _context.Login.Remove(login);
            await _context.SaveChangesAsync();

            return login;
        }

        private bool LoginExists(int id)
        {
            return _context.Login.Any(e => e.Id == id);
        }
    }
}