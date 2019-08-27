using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.DataBase.Entities
{
    public class Washer : User
    {
        public int NumberOfWash { get; set; }

        public Washer() : base()
        {

        }
    }
}
