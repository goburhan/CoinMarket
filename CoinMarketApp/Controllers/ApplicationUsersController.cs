using Core.Models;
using DataStore.EF.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controls
{
    
        [ApiVersion("1.0")]
        [ApiController]
        [Route("api/[controller]")]
        public class ApplicationUsersController : ControllerBase
        {
            private readonly CoinMarketDbContext _db;
            public ApplicationUsersController(CoinMarketDbContext db)
            {
                _db = db;
            }

            [HttpGet]
            public async Task<IActionResult> Get()
            {
                return Ok(await _db.ApplicationUsers.ToListAsync());
            }


            [HttpPost]
            public async Task<IActionResult> Create([FromBody] ApplicationUser applicationUser)
            {
                await _db.ApplicationUsers.AddAsync(applicationUser);
                await _db.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById),
                    new { id = applicationUser.Id },
                    applicationUser
                    );
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById([FromRoute] int id)
            {
                var applicationUser = await _db.ApplicationUsers.FindAsync(id);
                if (applicationUser == null) return NotFound();
                return Ok(applicationUser);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Put(int id, ApplicationUser applicationUser)
            {
                if (id != applicationUser.Id) return BadRequest();

                _db.Entry(applicationUser).State = EntityState.Modified;

                try
                {
                    await _db.SaveChangesAsync();
                }
                catch (Exception)
                {
                    if (await _db.ApplicationUsers.FindAsync(id) == null)
                        return NotFound();
                    throw;
                }
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var applicationUser = await _db.ApplicationUsers.FindAsync(id);
                if (applicationUser == null) return NotFound();

                _db.ApplicationUsers.Remove(applicationUser);
                await _db.SaveChangesAsync();
                return Ok(applicationUser);
            }
        }
    }
