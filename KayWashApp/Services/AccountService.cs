using KayWashApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.Services
{
    public interface IAccountService : IGenericService<Account>
    {
        Account Authenticate(string phone, string password);
    }

    public class AccountService : IAccountService
    {
        public Account Authenticate(string phone, string password)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetAll()
        {
            throw new NotImplementedException();
        }

        public Account GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Account Insert(Account item)
        {
            throw new NotImplementedException();
        }

        public Account Update(long id, Account item)
        {
            throw new NotImplementedException();
        }
    }
}
