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
    public class VehicleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VehicleController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Vehicle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleModel>>> GetVehicleModel()
        {
            return await _context.VehicleModel.ToListAsync();
        }

        // GET: api/Vehicle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleModel>> GetVehicleModel(int id)
        {
            var vehicleModel = await _context.VehicleModel.FindAsync(id);

            if (vehicleModel == null)
            {
                return NotFound();
            }

            return vehicleModel;
        }

        // PUT: api/Vehicle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleModel(int id, VehicleModel vehicleModel)
        {
            if (id != vehicleModel.VehicleId)
            {
                return BadRequest();
            }

            _context.Entry(vehicleModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleModelExists(id))
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

        // POST: api/Vehicle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VehicleModel>> PostVehicleModel(VehicleModel vehicleModel)
        {
            _context.VehicleModel.Add(vehicleModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicleModel", new { id = vehicleModel.VehicleId }, vehicleModel);
        }

        // DELETE: api/Vehicle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleModel(int id)
        {
            var vehicleModel = await _context.VehicleModel.FindAsync(id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            _context.VehicleModel.Remove(vehicleModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehicleModelExists(int id)
        {
            return _context.VehicleModel.Any(e => e.VehicleId == id);
        }
    }
}
