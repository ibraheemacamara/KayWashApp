
using KayWashApp.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.DataAccess.Model
{
    public class Customer : Account
    {
        [Key]
        public long Id { get; set; }
        public double Rate { get; set; }
        public int RatesCount { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public byte[] Avatar { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
