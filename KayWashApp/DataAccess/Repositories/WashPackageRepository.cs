using AutoMapper;
using KayWashApp.DataAccess.Model;
using KayWashApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.DataAccess.Repositories
{
    public class WashPackageRepository : GenericRepository<KayWashAppContext, WashPackage, WashPackageDto>, IWashPackageRepository
    {
        public WashPackageRepository(KayWashAppContext context) : base(context)
        {
        }
        protected override void ConfigureMapper()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<WashPackage, WashPackageDto>().ReverseMap()
            );

            config.AssertConfigurationIsValid();

            this.Mapper = config.CreateMapper();
        }
    }
}
