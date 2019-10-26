using KayWashApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.Dto
{
    public class CustomerDto : Account
    {
        public long Id { get; set; }
        public double Rate { get; set; }
        public int RatesCount { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public byte[] Avatar { get; set; }
        public ICollection<CarDto> CarsDto { get; set; }
    }
}
