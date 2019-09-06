using KayWashApp.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.DataAccess.Model
{
    public class Wash
    {
        [Key]
        public long Id { get; set; }

        [Required]
        //[ForeignKey("WashRequestId")]
        public WashRequest WashRequest { get; set; }
        //public long WashRequestId { get; set; }

        [Required]
        //[ForeignKey("CarDetailerId")]
        public CarDetailer CarDetailer { get; set; }
        //public long CarDetailerId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public WashStatus Status { get; set; }
    }
}
