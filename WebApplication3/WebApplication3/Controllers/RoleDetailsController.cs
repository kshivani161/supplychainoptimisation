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
    public class RoleDetailsController : ControllerBase
    {
        private readonly SupplyDbContext _context;

        public RoleDetailsController(SupplyDbContext context)
        {
            _context = context;
        }

        // GET: api/RoleDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDetail>>> GetRoleDetails()
        {
            return await _context.RoleDetails.ToListAsync();
        }

        // GET: api/RoleDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDetail>> GetRoleDetail(int id)
        {
            var roleDetail = await _context.RoleDetails.FindAsync(id);

            if (roleDetail == null)
            {
                return NotFound();
            }

            return roleDetail;
        }

        // PUT: api/RoleDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoleDetail(int id, RoleDetail roleDetail)
        {
            if (id != roleDetail.RoleId)
            {
                return BadRequest();
            }

            _context.Entry(roleDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleDetailExists(id))
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

        // POST: api/RoleDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoleDetail>> PostRoleDetail(RoleDetail roleDetail)
        {
            _context.RoleDetails.Add(roleDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoleDetailExists(roleDetail.RoleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRoleDetail", new { id = roleDetail.RoleId }, roleDetail);
        }

        // DELETE: api/RoleDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoleDetail(int id)
        {
            var roleDetail = await _context.RoleDetails.FindAsync(id);
            if (roleDetail == null)
            {
                return NotFound();
            }

            _context.RoleDetails.Remove(roleDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoleDetailExists(int id)
        {
            return _context.RoleDetails.Any(e => e.RoleId == id);
        }
    }
}
