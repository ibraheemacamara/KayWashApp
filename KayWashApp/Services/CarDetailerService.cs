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
    public class CarDetailerService : ICarDetailerService
    {
        private readonly ICarDetailerRepository _carDetailerRepository;

        public CarDetailerService(ICarDetailerRepository repo)
        {
            _carDetailerRepository = repo;
        }

        public CarDetailerDto Authenticate(string phone, string password)
        {
            if(string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var carDetailer = _carDetailerRepository.GetAll().SingleOrDefault(x => x.Phone == phone);

            if(carDetailer == null)
            {
                return null;
            }

            if(!Helper.VerifyPasswordHash(password, carDetailer.Password))
            {
                return null;
            }

            return carDetailer;
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
            if(string.IsNullOrEmpty(item.Password))
            {
                throw new AppException("Un mot de pass est obligatoire");
            }

            if(_carDetailerRepository.GetAll().Any(x => x.Phone == item.Phone))
            {
                throw new AppException("Le numéro téléphone " + item.Phone + " existe déjà!");
            }

            item.Password = Helper.CreatePasswordHash(item.Password);
            return _carDetailerRepository.Insert(item);
        }

        public CarDetailerDto Update(long id, CarDetailerDto item)
        {
            if (_carDetailerRepository.GetAll().Any(x => x.Phone == item.Phone))
            {
                throw new AppException("Le numéro téléphone " + item.Phone + " existe déjà!");
            }

            return _carDetailerRepository.Update(id, item);
        }
    }
}
