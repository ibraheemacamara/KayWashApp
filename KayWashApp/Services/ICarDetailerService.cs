using KayWashApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.Services
{
    public interface ICarDetailerService : IGenericService<CarDetailerDto>
    {
        CarDetailerDto Authenticate(string phone, string password);
    }
}
