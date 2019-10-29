using AutoMapper;
using KayWashApp.DataAccess.Model;
using KayWashApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.DataAccess.Repositories
{
    public class WashRequestRepository : GenericRepository<KayWashAppContext, WashRequest, WashRequestDto>, IWashRequestRepository
    {
        public WashRequestRepository(KayWashAppContext context) : base(context)
        {
        }
        protected override void ConfigureMapper()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<WashRequest, WashRequestDto>().ReverseMap()
            );

            config.AssertConfigurationIsValid();

            this.Mapper = config.CreateMapper();
        }
    }
}
