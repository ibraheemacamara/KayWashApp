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
    public class WashPackageService : IWashPackageService
    {
        private readonly IWashPackageRepository _washPackageRepository;

        public WashPackageService(IWashPackageRepository repo)
        {
            _washPackageRepository = repo;
        }


        public void Delete(long id)
        {
            _washPackageRepository.Delete(id);
        }

        public IEnumerable<WashPackageDto> GetAll()
        {
            return _washPackageRepository.GetAll();
        }

        public WashPackageDto GetById(long id)
        {
            return _washPackageRepository.GetById(id);
        }

        public WashPackageDto Insert(WashPackageDto item)
        {
            if(string.IsNullOrEmpty(item.Name))
            {
                throw new AppException("Le nom du package est obligatoire");
            }

            if(_washPackageRepository.GetAll().Any(x => x.Name == item.Name))
            {
                throw new AppException("Le nom du package " + item.Name + " existe déjà!");
            }

            return _washPackageRepository.Insert(item);
        }

        public WashPackageDto Update(long id, WashPackageDto item)
        {
            if (_washPackageRepository.GetAll().Any(x => x.Name == item.Name))
            {
                throw new AppException("Le nom du package  " + item.Name + " existe déjà!");
            }

            return _washPackageRepository.Update(id, item);
        }
    }
}
