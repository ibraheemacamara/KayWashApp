using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KayWashApp.Common;
using KayWashApp.DataAccess.Repositories;
using KayWashApp.Dto;
using Microsoft.Extensions.Options;

namespace KayWashApp.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carpository;

        public CarService(ICarRepository repo)
        {
            _carpository = repo;
        }


        public void Delete(long id)
        {
            _carpository.Delete(id);
        }

        public IEnumerable<CarDto> GetAll()
        {
            return _carpository.GetAll();
        }

        public CarDto GetById(long id)
        {
            return _carpository.GetById(id);
        }

        public CarDto Insert(CarDto item)
        {
            if(string.IsNullOrEmpty(item.ImmatriculationNumber))
            {
                throw new AppException("Le numéro d'immatriculation est obligatoire");
            }

            if(_carpository.GetAll().Any(x => x.ImmatriculationNumber == item.ImmatriculationNumber))
            {
                throw new AppException("Le numéro d'immatriculation " + item.ImmatriculationNumber + " existe déjà!");
            }

            return _carpository.Insert(item);
        }

        public CarDto Update(long id, CarDto item)
        {
            if (_carpository.GetAll().Any(x => x.ImmatriculationNumber == item.ImmatriculationNumber))
            {
                throw new AppException("Le numéro d'immatriculation " + item.ImmatriculationNumber + " existe déjà!");
            }

            return _carpository.Update(id, item);
        }
    }
}
