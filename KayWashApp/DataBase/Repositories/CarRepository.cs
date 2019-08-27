using AutoMapper;
using KayWashApp.DataBase.Entities;
using KayWashApp.Dto;

namespace KayWashApp.DataBase.Repositories
{
    public class CarRepository : GenericRepository<KayWashDbContext, Car, CarDto>
    {
        public CarRepository(KayWashDbContext context) : base(context)
        {

        }
        protected override void ConfigureMapper()
        {

           // var config = new MapperConfiguration(cfg =>
           // {
           //     cfg.CreateMap<Reservation, ReservationDto>()
           //     .ForMember(dest => dest.RoomDto, src => src.MapFrom(t => t.Room))
           //     .ForMember(dest => dest.GuestDto, src => src.MapFrom(t => t.Guest))
           //     .ForMember(dest => dest.RoomDtoId, src => src.Ignore())
           //     .ForMember(dest => dest.GuestDtoId, src => src.Ignore());
           //     cfg.CreateMap<RoomDto, Room>().ReverseMap();
           //     cfg.CreateMap<GuestDto, Guest>().ReverseMap();

           // }
           //);

           // config.AssertConfigurationIsValid();

           // Mapper = config.CreateMapper();


            var config = new MapperConfiguration(cfg =>
               cfg.CreateMap<Car, CarDto>().ReverseMap()
           );
            this.Mapper = config.CreateMapper();
            config.AssertConfigurationIsValid();
        }
    }
}
