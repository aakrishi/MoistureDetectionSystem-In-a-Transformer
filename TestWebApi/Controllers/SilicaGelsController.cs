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
    public class SilicaGelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SilicaGelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SilicaGels
        [HttpGet]
        public async Task<ActionResult<SilicaGel>> GetSilicaGelDetails()
        {
          if (_context.SilicaGelDetails == null)
          {
              return NotFound();
          }
            return await _context.SilicaGelDetails.FirstOrDefaultAsync();
        }

        // GET: api/SilicaGels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SilicaGel>> GetSilicaGel(int id)
        {
          if (_context.SilicaGelDetails == null)
          {
              return NotFound();
          }
            var silicaGel = await _context.SilicaGelDetails.FindAsync(id);

            if (silicaGel == null)
            {
                return NotFound();
            }

            return silicaGel;
        }

        // PUT: api/SilicaGels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSilicaGel(int id, SilicaGel silicaGel)
        {
            if (id != silicaGel.Id)
            {
                return BadRequest();
            }

            _context.Entry(silicaGel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SilicaGelExists(id))
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

        // POST: api/SilicaGels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SilicaGel>> PostSilicaGel([FromBody] SilicaGetDto silicaGelDto)
        {
            if(silicaGelDto.ApiKey == Consts.ApiKey)
            {
                if (_context.SilicaGelDetails == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.SilicaGelDetails'  is null.");
                }
                SilicaGel sg = new SilicaGel();
                sg.TransformerId = silicaGelDto.TransformerId;
                sg.RValue = silicaGelDto.RValue;
                sg.GValue = silicaGelDto.GValue;
                sg.BValue = silicaGelDto.BValue;
                sg.Status = true;
                sg.IsCritical = false;
                sg.CreatedOn = DateTime.Now;

                _context.SilicaGelDetails.Add(sg);
                await _context.SaveChangesAsync();

                return Ok("Added");
            }
            else
            {
                return BadRequest("Not Authorised");
            }
          
        }

        // DELETE: api/SilicaGels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSilicaGel(int id)
        {
            if (_context.SilicaGelDetails == null)
            {
                return NotFound();
            }
            var silicaGel = await _context.SilicaGelDetails.FindAsync(id);
            if (silicaGel == null)
            {
                return NotFound();
            }

            _context.SilicaGelDetails.Remove(silicaGel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SilicaGelExists(int id)
        {
            return (_context.SilicaGelDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
