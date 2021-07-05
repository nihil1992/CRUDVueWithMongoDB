using CRUDMongoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDMongoApp.Repository
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User Add(User user);
        bool Update(string id, User user);
        bool Delete(string id);
    }
}
