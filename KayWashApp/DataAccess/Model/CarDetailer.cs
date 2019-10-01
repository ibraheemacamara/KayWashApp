
using KayWashApp.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.DataAccess.Model
{
    public class CarDetailer : Account
    {
        [Key]
        public long Id { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Active { get; set; }
        public double Rate { get; set; }
        public int RatesCount { get; set; }
        public int WashCount { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public byte[] Avatar { get; set; }
    }
}
