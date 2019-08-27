using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.Dto
{
    public class CustomerDto : UserDto
    {
        public ICollection<CarDto> Cars { get; set; }

        public CustomerDto() : base()
        {

        }
    }
}
