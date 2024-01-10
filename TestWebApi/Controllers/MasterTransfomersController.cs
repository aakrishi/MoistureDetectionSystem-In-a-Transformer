using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebApi.Data;
using TestWebApi.Models;
using TestWebApi.Utility;

namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterTransfomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MasterTransfomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MasterTransfomers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MasterTransfomer>>> GetMasterTransfomers()
        {
            if (_context.MasterTransfomers == null)
            {
                return NotFound();
            }
            return await _context.MasterTransfomers.ToListAsync();
        }

        // GET: api/MasterTransfomers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MasterTransfomer>> GetMasterTransfomer(int id)
        {
            if (_context.MasterTransfomers == null)
            {
                return NotFound();
            }
            var masterTransfomer = await _context.MasterTransfomers.FindAsync(id);

            if (masterTransfomer == null)
            {
                return NotFound();
            }

            return masterTransfomer;
        }

        // PUT: api/MasterTransfomers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMasterTransfomer(int id, MasterTransfomer masterTransfomer)
        {
            if (id != masterTransfomer.ID)
            {
                return BadRequest();
            }

            _context.Entry(masterTransfomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasterTransfomerExists(id))
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

        // POST: api/MasterTransfomers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MasterTransfomer>> PostMasterTransfomer([FromBody] MasterTransformerDto dto)
        {
            if (dto.ApiKey == Consts.ApiKey)
            {
                if (_context.MasterTransfomers == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.MasterTransfomers'  is null.");
                }

                MasterTransfomer mt = new MasterTransfomer();
                mt.Region = dto.Region;
                mt.SubStation = dto.Substation;
                mt.SubStationName = dto.SubStationName;
                mt.Details = dto.Details;
                mt.Status = true;

                _context.MasterTransfomers.Add(mt);
                await _context.SaveChangesAsync();

                return Ok("Transfomer Details Added");
            }
            else
            {
                return BadRequest("Not Authorised!");
            }
                
        }

        // DELETE: api/MasterTransfomers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMasterTransfomer(int id)
        {
            if (_context.MasterTransfomers == null)
            {
                return NotFound();
            }
            var masterTransfomer = await _context.MasterTransfomers.FindAsync(id);
            if (masterTransfomer == null)
            {
                return NotFound();
            }

            _context.MasterTransfomers.Remove(masterTransfomer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MasterTransfomerExists(int id)
        {
            return (_context.MasterTransfomers?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
