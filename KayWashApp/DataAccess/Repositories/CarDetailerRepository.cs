using AutoMapper;
using KayWashApp.DataAccess.Model;
using KayWashApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.DataAccess.Repositories
{
    public class CarDetailerRepository : GenericRepository<KayWashAppContext, CarDetailer, CarDetailerDto>, ICarDetailerRepository
    {
        public CarDetailerRepository(KayWashAppContext context) : base(context)
        {
        }
        protected override void ConfigureMapper()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<CarDetailer, CarDetailerDto>().ReverseMap()
            );

            config.AssertConfigurationIsValid();

            this.Mapper = config.CreateMapper();
        }
    }
}
