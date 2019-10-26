using AutoMapper;
using KayWashApp.DataAccess.Model;
using KayWashApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.DataAccess.Repositories
{
    public class CarRepository : GenericRepository<KayWashAppContext, Car, CarDto>, ICarRepository
    {
        public CarRepository(KayWashAppContext context) : base(context)
        {
        }
        protected override void ConfigureMapper()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Car, CarDto>().ReverseMap()
            );

            config.AssertConfigurationIsValid();

            this.Mapper = config.CreateMapper();
        }
    }
}
