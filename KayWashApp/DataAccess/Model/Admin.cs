using KayWashApp.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.DataAccess.Model
{
    public class Admin : Account
    {
        [Key]
        public long Id { get; set; }
    }
}
