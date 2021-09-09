using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ApplicationUser
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Firstname should be between 6-12 characters")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Username should be between 6-12 characters")]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}
