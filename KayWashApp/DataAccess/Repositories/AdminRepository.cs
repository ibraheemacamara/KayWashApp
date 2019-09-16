using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.DataAccess.Repositories
{
    public class AdminRepository : GenericRepository<KayWashAppContext, Model.Admin, Dto.AdminDto>,
        IAdminRepository
    {
        public AdminRepository(KayWashAppContext context) : base(context)
        {
        }
        protected override void ConfigureMapper()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Model.Admin, Dto.AdminDto>().ReverseMap()
            );

            config.AssertConfigurationIsValid();

            this.Mapper = config.CreateMapper();
        }
    }
}
