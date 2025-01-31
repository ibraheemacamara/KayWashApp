﻿using KayWashApp.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.DataAccess.Model
{
    public class WashRequest
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(25)]
        public string WashRequestRef { get; set; }

        [Required]
        [ForeignKey("CustomerId")]
        public long CustomerId { get; set; }
       //public long CustomerId { get; set; }

        [Required]
        [ForeignKey("CarId")]
        public long CarId { get; set; }
        //public long CarId { get; set; }

        [Required]
        [ForeignKey("WashPackageId")]
        public long WashPackageId { get; set; }
        //public long WashPackageId { get; set; }

        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public WashRequestStatus Status { get; set; }
    }
}
