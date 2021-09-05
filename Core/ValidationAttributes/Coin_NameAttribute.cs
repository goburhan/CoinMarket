using CoinMarketApp.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ValidationAttributes
{
     class Coin_NameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var coin = validationContext.ObjectInstance as Coin;
            if (coin.SymbolChecking()) 
                return new ValidationResult("Symbols cannot be longer than 4 characters");
            return ValidationResult.Success;
        }
    }
}
