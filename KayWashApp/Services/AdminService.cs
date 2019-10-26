using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto;
using KayWashApp.DataAccess.Repositories;

namespace KayWashApp.Services
{
    public class AdminService 
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository repo)
        {
            _adminRepository = repo;
        }

        public void Delete(long id)
        {
            _adminRepository.Delete(id);
        }

        public IEnumerable<AdminDto> GetAll()
        {
            return _adminRepository.GetAll();
        }

        public AdminDto GetById(long id)
        {
            return _adminRepository.GetById(id);
        }

        public AdminDto Insert(AdminDto item)
        {
            return _adminRepository.Insert(item);
        }

        public AdminDto Update(long id, AdminDto item)
        {
            return _adminRepository.Update(id, item);
        }
    }
}
