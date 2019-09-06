
using System.ComponentModel.DataAnnotations;

namespace KayWashApp.Common
{
    public class Account
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }
        [Required]
        [StringLength(12)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        
    }
}
