using KayWashApp.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.DataBase.Entities
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        [Required]
        public UserStatus Status { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        public byte[] Profile_Pic { get; set; }

        public int Note { get; set; } //number of stars ( from 1 to 5)

        public User()
        {
                
        }

    }
}
