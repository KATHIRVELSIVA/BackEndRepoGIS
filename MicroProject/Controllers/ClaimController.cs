using CrudMicroProject.Data;
using CrudMicroProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudMicroProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClaimController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Claim
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClaimModel>>> GetClaim()
        {
            return await _context.Claim.ToListAsync();
        }

        // GET: api/Claim/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClaimModel>> GetClaimModel(int id)
        {
            var claimModel = await _context.Claim.FindAsync(id);

            if (claimModel == null)
            {
                return NotFound();
            }

            return claimModel;
        }

        // PUT: api/Claim/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClaimModel(int id, ClaimModel claimModel)
        {
            if (id != claimModel.ClaimID)
            {
                return BadRequest();
            }

            _context.Entry(claimModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClaimModelExists(id))
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

        // POST: api/Claim
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClaimModel>> PostClaimModel(ClaimModel claimModel)
        {
            _context.Claim.Add(claimModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClaimModel", new { id = claimModel.ClaimID }, claimModel);
        }

        // DELETE: api/Claim/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClaimModel(int id)
        {
            var claimModel = await _context.Claim.FindAsync(id);
            if (claimModel == null)
            {
                return NotFound();
            }

            _context.Claim.Remove(claimModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClaimModelExists(int id)
        {
            return _context.Claim.Any(e => e.ClaimID == id);
        }
    }
}
