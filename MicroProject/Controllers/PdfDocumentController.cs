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
    public class PdfDocumentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PdfDocumentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PdfDocument
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PdfDocumentModel>>> GetPdfDocument()
        {
            return await _context.PdfDocument.ToListAsync();
        }

        // GET: api/PdfDocument/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPdfDocumentModel(int id)
        {
            var pdfDocumentModel = await _context.PdfDocument.FindAsync(id);

            if (pdfDocumentModel == null)
            {
                return NotFound();
            }

            return File(pdfDocumentModel.FIelData, "application/pdf", pdfDocumentModel.FileName);
        }

        // PUT: api/PdfDocument/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPdfDocumentModel(int id, PdfDocumentModel pdfDocumentModel)
        {
            if (id != pdfDocumentModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(pdfDocumentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PdfDocumentModelExists(id))
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

        // POST: api/PdfDocument
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostPdfDocumentModel(IFormFile file, int id)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Invalid file");
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var pdfDocument = new PdfDocumentModel
                {
                    FileName = file.FileName,
                    FIelData = memoryStream.ToArray(),
                    UploadDate = DateTime.Now,
                    UserID = id
                };
                _context.PdfDocument.Add(pdfDocument);
                await _context.SaveChangesAsync();
            }
            return Ok("PDF file Uploaded successfully...");
        }

        // DELETE: api/PdfDocument/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePdfDocumentModel(int id)
        {
            var pdfDocumentModel = await _context.PdfDocument.FindAsync(id);
            if (pdfDocumentModel == null)
            {
                return NotFound();
            }

            _context.PdfDocument.Remove(pdfDocumentModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PdfDocumentModelExists(int id)
        {
            return _context.PdfDocument.Any(e => e.Id == id);
        }
    }
}
