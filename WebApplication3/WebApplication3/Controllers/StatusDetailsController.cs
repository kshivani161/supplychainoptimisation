using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusDetailsController : ControllerBase
    {
        private readonly SupplyDbContext _context;

        public StatusDetailsController(SupplyDbContext context)
        {
            _context = context;
        }

        // GET: api/StatusDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusDetail>>> GetStatusDetails()
        {
            return await _context.StatusDetails.ToListAsync();
        }

        // GET: api/StatusDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusDetail>> GetStatusDetail(int id)
        {
            var statusDetail = await _context.StatusDetails.FindAsync(id);

            if (statusDetail == null)
            {
                return NotFound();
            }

            return statusDetail;
        }

        // PUT: api/StatusDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusDetail(int id, StatusDetail statusDetail)
        {
            if (id != statusDetail.StatusId)
            {
                return BadRequest();
            }

            _context.Entry(statusDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusDetailExists(id))
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

        // POST: api/StatusDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatusDetail>> PostStatusDetail(StatusDetail statusDetail)
        {
            _context.StatusDetails.Add(statusDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StatusDetailExists(statusDetail.StatusId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStatusDetail", new { id = statusDetail.StatusId }, statusDetail);
        }

        // DELETE: api/StatusDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusDetail(int id)
        {
            var statusDetail = await _context.StatusDetails.FindAsync(id);
            if (statusDetail == null)
            {
                return NotFound();
            }

            _context.StatusDetails.Remove(statusDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusDetailExists(int id)
        {
            return _context.StatusDetails.Any(e => e.StatusId == id);
        }
    }
}
