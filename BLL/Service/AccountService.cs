using DAL.Entities;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class AccountService
    {
        private AccountRepo _repo;
        public AccountService()
        {
            _repo = new AccountRepo();
        }
        public Account? GetAccount(string email, string password)
        {
            return _repo.GetAccount(email, password);
        }

        public void CreateAccount(Account account)
        {
            _repo.CreateAccount(account);
        }

    }
}
