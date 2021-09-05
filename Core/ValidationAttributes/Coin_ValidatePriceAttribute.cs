using CoinMarketApp.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ValidationAttributes
{
    class Coin_ValidatePriceAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var coin = validationContext.ObjectInstance as Coin;
            if (coin.ValidatePrice())
                return new ValidationResult("Coin price cannot be lower than 0 ! ");
            
            return ValidationResult.Success;
        }
        
    }
}
