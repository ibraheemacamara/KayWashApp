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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository repo)
        {
            _customerRepository = repo;
        }

        public CustomerDto Authenticate(string phone, string password)
        {
            if(string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var customer = _customerRepository.GetAll().SingleOrDefault(x => x.Phone == phone);

            if(customer == null)
            {
                return null;
            }

            if(!Helper.VerifyPasswordHash(password, customer.Password))
            {
                return null;
            }

            return customer;
        }

        public void Delete(long id)
        {
            _customerRepository.Delete(id);
        }

        public IEnumerable<CustomerDto> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public CustomerDto GetById(long id)
        {
            return _customerRepository.GetById(id);
        }

        public CustomerDto Insert(CustomerDto item)
        {
            if(string.IsNullOrEmpty(item.Password))
            {
                throw new AppException("Un mot de pass est obligatoire");
            }

            if(_customerRepository.GetAll().Any(x => x.Phone == item.Phone))
            {
                throw new AppException("Le numéro téléphone " + item.Phone + " existe déjà!");
            }

            item.Password = Helper.CreatePasswordHash(item.Password);
            return _customerRepository.Insert(item);
        }

        public CustomerDto Update(long id, CustomerDto item)
        {
            if (_customerRepository.GetAll().Any(x => x.Phone == item.Phone))
            {
                throw new AppException("Le numéro téléphone " + item.Phone + " existe déjà!");
            }

            return _customerRepository.Update(id, item);
        }
    }
}
