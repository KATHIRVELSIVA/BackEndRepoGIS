using CrudMicroProject.Data;
using CrudMicroProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudMicroProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PolicyController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Policy
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PolicyModel>>> GetPolicy()
        {
            return await _context.Policy.ToListAsync();
        }

        // GET: api/Policy/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PolicyModel>> GetPolicyModel(int id)
        {
            var policyModel = await _context.Policy.FindAsync(id);

            if (policyModel == null)
            {
                return NotFound();
            }

            return policyModel;
        }

        // PUT: api/Policy/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolicyModel(int id, PolicyModel policyModel)
        {
            if (id != policyModel.PolicyID)
            {
                return BadRequest();
            }

            _context.Entry(policyModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicyModelExists(id))
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

        // POST: api/Policy
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PolicyModel>> PostPolicyModel(PolicyModel policyModel)
        {
            _context.Policy.Add(policyModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPolicyModel", new { id = policyModel.PolicyID }, policyModel);
        }

        // DELETE: api/Policy/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicyModel(int id)
        {
            var policyModel = await _context.Policy.FindAsync(id);
            if (policyModel == null)
            {
                return NotFound();
            }

            _context.Policy.Remove(policyModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PolicyModelExists(int id)
        {
            return _context.Policy.Any(e => e.PolicyID == id);
        }
    }
}
