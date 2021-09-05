using Core.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinMarketApp.Core.Models
{
    public class Coin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Coin_Name]
        public string Symbol { get; set; }
        [Coin_ValidatePrice]
        public double? Price { get; set; }
        
        public bool ValidatePrice()
        {
            if (!Price.HasValue) return true;

            return Price < 0;
        }
        public bool SymbolChecking()
        {
            return Symbol.Length > 4;
        }
    }
}
