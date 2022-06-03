using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreApiDemo.Repository;
using CoreApiDemo.Repository.Models;

namespace CoreApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceLinesController : ControllerBase
    {
        private readonly ChinookDBContext _context;

        public InvoiceLinesController(ChinookDBContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceLine>>> GetInvoiceLines()
        {
            return await _context.InvoiceLines.ToListAsync();
        }

        // GET: api/InvoiceLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceLine>> GetInvoiceLine(int id)
        {
            var invoiceLine = await _context.InvoiceLines.FindAsync(id);

            if (invoiceLine == null)
            {
                return NotFound();
            }

            return invoiceLine;
        }

        // PUT: api/InvoiceLines/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceLine(int id, InvoiceLine invoiceLine)
        {
            if (id != invoiceLine.InvoiceLineId)
            {
                return BadRequest();
            }

            _context.Entry(invoiceLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceLineExists(id))
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

        // POST: api/InvoiceLines
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InvoiceLine>> PostInvoiceLine(InvoiceLine invoiceLine)
        {
            _context.InvoiceLines.Add(invoiceLine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoiceLine", new { id = invoiceLine.InvoiceLineId }, invoiceLine);
        }

        // DELETE: api/InvoiceLines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InvoiceLine>> DeleteInvoiceLine(int id)
        {
            var invoiceLine = await _context.InvoiceLines.FindAsync(id);
            if (invoiceLine == null)
            {
                return NotFound();
            }

            _context.InvoiceLines.Remove(invoiceLine);
            await _context.SaveChangesAsync();

            return invoiceLine;
        }

        private bool InvoiceLineExists(int id)
        {
            return _context.InvoiceLines.Any(e => e.InvoiceLineId == id);
        }
    }
}
