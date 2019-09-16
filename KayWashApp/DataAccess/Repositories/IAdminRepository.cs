using Dto;
using KayWashApp.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.DataAccess.Repositories
{
    public interface IAdminRepository : IGenericRepository<AdminDto>
    {
    }
}
