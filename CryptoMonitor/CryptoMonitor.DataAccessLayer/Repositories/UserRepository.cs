using CryptoMonitor.DAL.DTO;
using CryptoMonitor.DAL.Entities;
using CryptoMonitor.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoMonitor.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CryptoMonitorDbContext _db;
        public UserRepository(CryptoMonitorDbContext db)
        {
            _db = db;
        }
        public void AddUser(UserDataModel userDataModel)
        {
            User newUser = new User
            {
                FirstName = userDataModel.FirstName,
                LastName = userDataModel.LastName,
                AccountId = userDataModel.AccountId
            };
            _db.User.Add(newUser);
        }

        public int GetUserId(string login)
        {
            var userId = _db.User.Where(u => u.Account.AccountLogin == login).Select(u => u.Id).FirstOrDefault();
            return userId;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
