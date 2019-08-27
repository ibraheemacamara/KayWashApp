using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.DataBase.Entities
{
    public class Customer : User
    {
        public ICollection<Car> Cars { get; set; }

        public Customer() : base()
        {

        }
    }
}
