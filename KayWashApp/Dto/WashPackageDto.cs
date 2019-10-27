using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.Dto
{
    public class WashPackageDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public double Amount { get; set; }

        public string Description { get; set; }
    }
}
