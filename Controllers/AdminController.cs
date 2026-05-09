using CrudMicroProject.Data;
using CrudMicroProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudMicroProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Admin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminModel>>> GetAdmin()
        {
            return await _context.Admin.ToListAsync();
        }

        // GET: api/Admin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminModel>> GetAdminModel(int id)
        {
            var adminModel = await _context.Admin.FindAsync(id);

            if (adminModel == null)
            {
                return NotFound();
            }

            return adminModel;
        }

        // PUT: api/Admin/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminModel(int id, AdminModel adminModel)
        {
            if (id != adminModel.AdminID)
            {
                return BadRequest();
            }

            _context.Entry(adminModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminModelExists(id))
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

        // POST: api/Admin
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdminModel>> PostAdminModel(AdminModel adminModel)
        {
            _context.Admin.Add(adminModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdminModel", new { id = adminModel.AdminID }, adminModel);
        }

        // DELETE: api/Admin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminModel(int id)
        {
            var adminModel = await _context.Admin.FindAsync(id);
            if (adminModel == null)
            {
                return NotFound();
            }

            _context.Admin.Remove(adminModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminModelExists(int id)
        {
            return _context.Admin.Any(e => e.AdminID == id);
        }
    }
}
