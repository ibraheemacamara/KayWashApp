using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.Services
{
    public interface IAdminService
    {
        AdminDto GetById(long id);

        IEnumerable<AdminDto> GetAll();

        AdminDto Insert(AdminDto item);

        AdminDto Update(long id, AdminDto item);

        void Delete(long id);
    }
}
