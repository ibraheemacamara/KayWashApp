using KayWashApp.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.Dto
{
    public class WashRequestDto
    {
        public long Id { get; set; }
        public string WashRequestRef { get; set; }
        public long CustomerId { get; set; }
        public long CarId { get; set; }

        public long WashPackageId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double Price { get; set; }

        public WashRequestStatus Status { get; set; }
    }
}
