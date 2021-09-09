using CoinMarketApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.EF.Data
{
    public class CoinMarketDbContext : DbContext
    {
        public CoinMarketDbContext(DbContextOptions<CoinMarketDbContext> options) : base(options)
        {
        }
        public DbSet<Coin> Coins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            //Dataseeding
            modelbuilder.Entity<Coin>().HasData(
                new Coin { Id = 1, Name = "Bitcoin", Symbol = "BTC", Price = 50.000 },
                new Coin { Id = 2, Name = "Ethereum", Symbol = "ETH", Price = 4000.0 }
            );
        }
    }
           
}
