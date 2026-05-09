using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudMicroProject.Data;
using CrudMicroProject.Models;

namespace CrudMicroProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimAmountController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClaimAmountController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ClaimAmount
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClaimAmountModel>>> GetClaimAmounts()
        {
            return await _context.ClaimAmounts.ToListAsync();
        }

        // GET: api/ClaimAmount/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClaimAmountModel>> GetClaimAmountModel(int id)
        {
            var claimAmountModel = await _context.ClaimAmounts.FindAsync(id);

            if (claimAmountModel == null)
            {
                return NotFound();
            }

            return claimAmountModel;
        }

        // PUT: api/ClaimAmount/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClaimAmountModel(int id, ClaimAmountModel claimAmountModel)
        {
            if (id != claimAmountModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(claimAmountModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClaimAmountModelExists(id))
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

        // POST: api/ClaimAmount
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClaimAmountModel>> PostClaimAmountModel(ClaimAmountModel claimAmountModel)
        {
            _context.ClaimAmounts.Add(claimAmountModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClaimAmountModel", new { id = claimAmountModel.Id }, claimAmountModel);
        }

        // DELETE: api/ClaimAmount/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClaimAmountModel(int id)
        {
            var claimAmountModel = await _context.ClaimAmounts.FindAsync(id);
            if (claimAmountModel == null)
            {
                return NotFound();
            }

            _context.ClaimAmounts.Remove(claimAmountModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClaimAmountModelExists(int id)
        {
            return _context.ClaimAmounts.Any(e => e.Id == id);
        }
    }
}
