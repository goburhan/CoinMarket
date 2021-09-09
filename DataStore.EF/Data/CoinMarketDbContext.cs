using CoinMarketApp.Core.Models;
using Core.Models;
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
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUserRole>()
                .HasKey(bc => new { bc.ApplicationUserId, bc.RoleId });
            modelBuilder.Entity<ApplicationUserRole>()
                .HasOne(bc => bc.ApplicationUser)
                .WithMany(b => b.ApplicationUserRoles)
                .HasForeignKey(bc => bc.ApplicationUserId);
            modelBuilder.Entity<ApplicationUserRole>()
                .HasOne(bc => bc.Role)
                .WithMany(c => c.ApplicationUserRoles)
                .HasForeignKey(bc => bc.RoleId);
        }


            //////Dataseeding
            ////modelbuilder.Entity<Coin>().HasData(
            ////    new Coin { Id = 1, Name = "Bitcoin", Symbol = "BTC", Price = 50.000 },
            ////    new Coin { Id = 2, Name = "Ethereum", Symbol = "ETH", Price = 4000.0 }
            //);
        }
    }
           

