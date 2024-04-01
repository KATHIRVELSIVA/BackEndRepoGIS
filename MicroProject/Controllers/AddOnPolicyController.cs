using CrudMicroProject.Data;
using CrudMicroProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudMicroProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddOnPolicyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AddOnPolicyController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AddOnPolicy
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddOnPolicyModel>>> GetAddOnPolicy()
        {
            return await _context.AddOnPolicy.ToListAsync();
        }

        // GET: api/AddOnPolicy/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddOnPolicyModel>> GetAddOnPolicyModel(int id)
        {
            var addOnPolicyModel = await _context.AddOnPolicy.FindAsync(id);

            if (addOnPolicyModel == null)
            {
                return NotFound();
            }

            return addOnPolicyModel;
        }

        // PUT: api/AddOnPolicy/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddOnPolicyModel(int id, AddOnPolicyModel addOnPolicyModel)
        {
            if (id != addOnPolicyModel.AddOnPolicyID)
            {
                return BadRequest();
            }

            _context.Entry(addOnPolicyModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddOnPolicyModelExists(id))
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

        // POST: api/AddOnPolicy
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddOnPolicyModel>> PostAddOnPolicyModel(AddOnPolicyModel addOnPolicyModel)
        {
            _context.AddOnPolicy.Add(addOnPolicyModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddOnPolicyModel", new { id = addOnPolicyModel.AddOnPolicyID }, addOnPolicyModel);
        }

        // DELETE: api/AddOnPolicy/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddOnPolicyModel(int id)
        {
            var addOnPolicyModel = await _context.AddOnPolicy.FindAsync(id);
            if (addOnPolicyModel == null)
            {
                return NotFound();
            }

            _context.AddOnPolicy.Remove(addOnPolicyModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddOnPolicyModelExists(int id)
        {
            return _context.AddOnPolicy.Any(e => e.AddOnPolicyID == id);
        }
    }
}
