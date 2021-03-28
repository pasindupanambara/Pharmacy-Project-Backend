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
    public class PharmaciesController : ControllerBase
    {
        private readonly PharmacyDataContext _context;

        public PharmaciesController(PharmacyDataContext context)
        {
            _context = context;
        }

        // GET: api/Pharmacies
        [HttpGet("{field}/{value}")]
        public async Task<ActionResult<IEnumerable<Pharmacy>>> GetPharmacy(string field, string value)
        {
            if (field == "district")
            {
                return await _context.Pharmacy.Where(p => p.District == value).ToListAsync();
            }

            else if (field == "name")
            {
                return await _context.Pharmacy.Where(p => p.Pharmacyname == value).ToListAsync();
            }

            else if (field == "all")
            {
                return await _context.Pharmacy.ToListAsync();
            }

            return NotFound();
        }


        // GET: api/Pharmacies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pharmacy>> GetPharmacy(int id)
        {
            var pharmacy = await _context.Pharmacy.FindAsync(id);

            if (pharmacy == null)
            {
                return NotFound();
            }

            return pharmacy;
        }

        // PUT: api/Pharmacies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPharmacy(int id, Pharmacy pharmacy)
        {
            if (id != pharmacy.Id)
            {
                return BadRequest();
            }

            _context.Entry(pharmacy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PharmacyExists(id))
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

        // POST: api/Pharmacies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pharmacy>> PostPharmacy(Pharmacy pharmacy)
        {

            var pharmacyWithSameEmail = _context.Pharmacy.FirstOrDefault(m => m.Email.ToLower() == pharmacy.Email.ToLower()); //check email already exit or not


            if (pharmacyWithSameEmail == null)
            {
                _context.Pharmacy.Add(pharmacy);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPharmacy", new { id = pharmacy.Id }, pharmacy);

            }

            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Pharmacies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pharmacy>> DeletePharmacy(int id)
        {
            var pharmacy = await _context.Pharmacy.FindAsync(id);
            if (pharmacy == null)
            {
                return NotFound();
            }

            _context.Pharmacy.Remove(pharmacy);
            await _context.SaveChangesAsync();

            return pharmacy;
        }

        private bool PharmacyExists(int id)
        {
            return _context.Pharmacy.Any(e => e.Id == id);
        }
    }
}
