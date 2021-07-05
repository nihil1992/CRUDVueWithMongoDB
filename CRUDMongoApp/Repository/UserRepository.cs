using MongoDB.Driver;
using CRUDMongoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDMongoApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseRepository _databaseRepository;
        public UserRepository(DatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }
        public List<User> GetAll() => _databaseRepository.Get();

        public User Add(User user)
        {
            if(user != null)
            {
                return _databaseRepository.Create(user);
            }
            return user;
        }

        public bool Update(string id, User user)
        {
            if (!string.IsNullOrEmpty(id) && user != null)
            {
                _databaseRepository.Update(id, user);
                return true;
            }
            return false;
        }

        public bool Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                _databaseRepository.Remove(id);
                return true;
            }
            return false;
        }
    }
}
