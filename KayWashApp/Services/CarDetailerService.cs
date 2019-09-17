using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KayWashApp.DataAccess.Repositories;
using KayWashApp.Dto;

namespace KayWashApp.Services
{
    public class CarDetailerService : ICarDetailerService
    {
        private readonly ICarDetailerRepository _carDetailerRepository;

        public CarDetailerService(ICarDetailerRepository repo)
        {
            _carDetailerRepository = repo;
        }

        public void Delete(long id)
        {
            _carDetailerRepository.Delete(id);
        }

        public IEnumerable<CarDetailerDto> GetAll()
        {
            return _carDetailerRepository.GetAll();
        }

        public CarDetailerDto GetById(long id)
        {
            return _carDetailerRepository.GetById(id);
        }

        public CarDetailerDto Insert(CarDetailerDto item)
        {
            return _carDetailerRepository.Insert(item);
        }

        public CarDetailerDto Update(long id, CarDetailerDto item)
        {
            return _carDetailerRepository.Update(id, item);
        }
    }
}
