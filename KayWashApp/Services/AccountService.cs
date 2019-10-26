using KayWashApp.Common;
using KayWashApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.Services
{
    public interface IAccountService 
    {
        //Account GetById(long id);
        //IEnumerable<Account> GetAll();
        Account GetUser(string name);
    }

    public class AccountService : IAccountService
    {
        private ICarDetailerService _carDetailerService;
        private ICustomerService _customerService;

        public AccountService(ICarDetailerService carDetailerService, ICustomerService customerService)
        {
            _carDetailerService = carDetailerService;
            _customerService = customerService;
        }

        public Account GetUser(string name)
        {
           var array = name.Split(',');

            if(array.Length != 2)
            {
                return null;
            }

            if(array[1] == "carDetailer")
            {
                var userId = int.Parse(array[0]);
                return _carDetailerService.GetById(userId);
            }
            if (array[1] == "customer")
            {
                var userId = int.Parse(array[0]);
                return _customerService.GetById(userId);
            }

            return null;
        }
    }
}
