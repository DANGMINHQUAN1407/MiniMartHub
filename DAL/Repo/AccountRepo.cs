using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class AccountRepo
    {
        private Prn212block3WContext _context;
        public AccountRepo()
        {
            _context = new Prn212block3WContext();
        }
        public Account? GetAccount(string email, string password)
        {
          return _context.Accounts.FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        public void CreateAccount(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
        
    }
}
