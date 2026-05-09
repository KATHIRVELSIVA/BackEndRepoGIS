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
    public class InsuranceApplyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InsuranceApplyController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/InsuranceApply
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsuranceApplyModel>>> GetInsuranceApply()
        {
            //return await _context.InsuranceApply.Include(a => a.user).Include(b => b.addOnPolicy).Include(c => c.policy).ToListAsync();
            return await _context.InsuranceApply.ToListAsync();
        }

        // GET: api/InsuranceApply/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InsuranceApplyModel>> GetInsuranceApplyModel(int id)
        {
            var insuranceApplyModel = await _context.InsuranceApply.FindAsync(id);

            if (insuranceApplyModel == null)
            {
                return NotFound();
            }

            return insuranceApplyModel;
        }

        // PUT: api/InsuranceApply/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsuranceApplyModel(int id, InsuranceApplyModel insuranceApplyModel)
        {
            if (id != insuranceApplyModel.ApplyId)
            {
                return BadRequest();
            }

            _context.Entry(insuranceApplyModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceApplyModelExists(id))
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

        // POST: api/InsuranceApply
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InsuranceApplyModel>> PostInsuranceApplyModel(InsuranceApplyModel insuranceApplyModel)
        {
            _context.InsuranceApply.Add(insuranceApplyModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsuranceApplyModel", new { id = insuranceApplyModel.ApplyId }, insuranceApplyModel);
        }

        // DELETE: api/InsuranceApply/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsuranceApplyModel(int id)
        {
            var insuranceApplyModel = await _context.InsuranceApply.FindAsync(id);
            if (insuranceApplyModel == null)
            {
                return NotFound();
            }

            _context.InsuranceApply.Remove(insuranceApplyModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InsuranceApplyModelExists(int id)
        {
            return _context.InsuranceApply.Any(e => e.ApplyId == id);
        }
    }
}
