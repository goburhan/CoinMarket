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
        public class RolesController : ControllerBase
        {
            private readonly CoinMarketDbContext _db;
            public RolesController(CoinMarketDbContext db)
            {
                _db = db;
            }

            [HttpGet]
            public async Task<IActionResult> Get()
            {
                return Ok(await _db.Roles.ToListAsync());
            }


            [HttpPost]
            public async Task<IActionResult> Create([FromBody] Role role)
            {
                await _db.Roles.AddAsync(role);
                await _db.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById),
                    new { id = role.Id },
                    role
                    );
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById([FromRoute] int id)
            {
                var role = await _db.Roles.FindAsync(id);
                if (role == null) return NotFound();
                return Ok(role);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Put(int id, Role role)
            {
                if (id != role.Id) return BadRequest();

                _db.Entry(role).State = EntityState.Modified;

                try
                {
                    await _db.SaveChangesAsync();
                }
                catch (Exception)
                {
                    if (await _db.Roles.FindAsync(id) == null)
                        return NotFound();
                    throw;
                }
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var role = await _db.Roles.FindAsync(id);
                if (role == null) return NotFound();

                _db.Roles.Remove(role);
                await _db.SaveChangesAsync();
                return Ok(role);
            }
        }
    }

