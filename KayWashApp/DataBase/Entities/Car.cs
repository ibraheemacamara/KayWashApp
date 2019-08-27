using System.ComponentModel.DataAnnotations;

namespace KayWashApp.DataBase.Entities
{
    public class Car
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }
    }
}