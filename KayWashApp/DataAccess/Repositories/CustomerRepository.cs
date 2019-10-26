using AutoMapper;
using KayWashApp.DataAccess.Model;
using KayWashApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.DataAccess.Repositories
{
    public class CustomerRepository : GenericRepository<KayWashAppContext, Customer, CustomerDto>, ICustomerRepository
    {
        public CustomerRepository(KayWashAppContext context) : base(context)
        {
        }
        protected override void ConfigureMapper()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Customer, CustomerDto>()
                .ForMember(src => src.CarsDto, dest => dest.Ignore())
                .ReverseMap()
            //.ForMember(dest => dest.CarsDto,
            //            opt => opt.MapFrom(t => t.Cars.Select(dpc => dpc.CustomerId)))
            //.ReverseMap()
            //.ForMember(dest => dest.Cars,
            //            opt => opt.MapFrom(t => t.CarsDto.Select(dpc =>
            //                new CarDto()
            //                {
            //                   CustomerId = t.Id,

            //                })))

            );

            config.AssertConfigurationIsValid();

            this.Mapper = config.CreateMapper();
        }
    }
}
