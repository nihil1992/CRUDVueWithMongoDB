using MongoDB.Driver;
using CRUDMongoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDMongoApp.Repository
{
    public class DatabaseRepository 
    {
        private readonly IMongoCollection<User> _users;

        public DatabaseRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _users = database.GetCollection<User>("user");

        }

        public List<User> Get() => _users.Find(user => true).ToList();

        public User Get(string id) => _users.Find<User>(x => x.Id == id).FirstOrDefault();

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id,User user) => _users.ReplaceOne(x => x.Id == id, user);

        public void Remove(User user) => _users.DeleteOne(x => x.Id == user.Id);

        public void Remove(string id) => _users.DeleteOne(x => x.Id == id);
    }
}
