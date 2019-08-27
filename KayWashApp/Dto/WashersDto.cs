using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.Dto
{
    public class WasherDto : UserDto
    {
        public int NumberOfWash { get; set; }

        public WasherDto() : base()
        {

        }
    }
}
