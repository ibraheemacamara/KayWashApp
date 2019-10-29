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
    public class WashRequestService : IWashRequestService
    {
        private readonly IWashRequestRepository _washRequestRepository;

        public WashRequestService(IWashRequestRepository repo)
        {
            _washRequestRepository = repo;
        }


        public void Delete(long id)
        {
            _washRequestRepository.Delete(id);
        }

        public IEnumerable<WashRequestDto> GetAll()
        {
            return _washRequestRepository.GetAll();
        }

        public WashRequestDto GetById(long id)
        {
            return _washRequestRepository.GetById(id);
        }

        public WashRequestDto GetByRef(string reference)
        {
            return _washRequestRepository.GetAll().FirstOrDefault(x => x.WashRequestRef == reference);
        }

        public WashRequestDto Insert(WashRequestDto item)
        {
            return _washRequestRepository.Insert(item);
        }

        public WashRequestDto Update(long id, WashRequestDto item)
        {
            if (string.IsNullOrEmpty(item.WashRequestRef))
            {
                throw new AppException("La référence est obligatoire");
            }

            return _washRequestRepository.Update(id, item);
        }
    }
}
