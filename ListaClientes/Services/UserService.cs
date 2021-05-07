using ListaClente;
using MongoDB.Driver;
using System.Collections.Generic;

namespace ListaClientes.Services
{
    public class UserService : IUserServices
    {
        private readonly IMongoCollection<User> _user;

        public UserService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _user = database.GetCollection<User>(settings.CollectionName);
        }

        public List<User> Get()
        {
            return _user.Find(user => true).ToList();
        }
        public User Get(string name)
        {
            return _user.Find<User>(user => user.Name == name).FirstOrDefault();
        }

        public User Create(User user)
        {
            _user.InsertOne(user);
            return user;
        }
        public long Update(string id, User userIn)
        {
            return _user.ReplaceOne(user => user.Id == id, userIn).ModifiedCount;
        }

        public void Remove(User userIn)
        {
            _user.DeleteOne(user => user.Id == userIn.Id);
        }
        public long Remove(string id)
        {
            var user = _user.DeleteOne(user => user.Id == id);
            return user.DeletedCount;
        }
    }
}