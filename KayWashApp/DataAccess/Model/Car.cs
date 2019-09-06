using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KayWashApp.DataAccess.Model
{
    public class Car
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [ForeignKey("CustomerId")]
        public long CustomerId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public byte[] Image { get; set; }
    }
}