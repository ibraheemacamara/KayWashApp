using AutoMapper;
using KayWashApp.DataBase.Entities;
using KayWashApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.DataBase.Repositories
{
    public class WasherRepository : GenericRepository<KayWashDbContext, Washer, WasherDto>
    {
        public WasherRepository(KayWashDbContext context) : base(context)
        {

        }
        protected override void ConfigureMapper()
        {
            var config = new MapperConfiguration(cfg =>
              cfg.CreateMap<Washer, WasherDto>().ReverseMap()
          );
            this.Mapper = config.CreateMapper();
            config.AssertConfigurationIsValid();
        }
    }
}
