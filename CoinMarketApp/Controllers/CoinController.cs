using CoinMarketApp.Core.Models;
using CoinMarketApp.Filters;
using DataStore.EF.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinMarketApp.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/[controller]")] //api/coin olarak coincontrollerı çağırıyoruz
    [APIKeyAuthFilter]

    public class CoinController : ControllerBase
    {
        private readonly CoinMarketDbContext _db;

        public CoinController(CoinMarketDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task <IActionResult> Get()
        {
            return Ok(await _db.Coins.ToListAsync());
        }

        [HttpPost]
        public async Task <IActionResult> Create([FromBody]Coin coin)
        {
            _db.Coins.Add(coin);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof (GetById),
                new {id=coin.Id } ,
                coin) ;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var coin = await _db.Coins.FindAsync(id);
            if (coin == null) return NotFound();

            return Ok(coin);
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteById(int id)
        {
            var coin = await _db.Coins.FindAsync(id);
            if (coin == null) return NotFound();
            _db.Coins.Remove(coin);
            await _db.SaveChangesAsync();

            return Ok("Coin deleted. ");
        }
        [HttpPut("{id}")]
        public async Task <IActionResult> Put(int id,[FromBody] Coin coin)
        {
            if (id != coin.Id) return NotFound();
            _db.Entry(coin).State = EntityState.Modified;

            await _db.SaveChangesAsync();
            return Ok("Coin updated.");
        }

    }
}
