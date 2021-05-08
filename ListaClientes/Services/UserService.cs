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

        public List<User> Get(FilterUser filterUser)
        {
            if (string.IsNullOrEmpty(filterUser.Name) && filterUser.Limit == 0 && filterUser.Offset == 0)
            {
                return _user.Find(user => true).SortBy(user => user.Name).ToList();
            }
            if (string.IsNullOrEmpty(filterUser.Name) && filterUser.Limit > 0 && filterUser.Offset > 0)
            {
                return _user.Find(user => true).SortBy(user => user.Name).Skip(filterUser.Offset).Limit(filterUser.Limit).ToList();
            }
            return _user.Find(user => user.Name.Contains(filterUser.Name)).SortBy(user => user.Name).Skip(filterUser.Offset).Limit(filterUser.Limit).ToList();
        }

        public User Get(string id)
        {
            return _user.Find<User>(user => user.Id == id).FirstOrDefault();
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

        public long Remove(string id)
        {
            var user = _user.DeleteOne(user => user.Id == id);
            return user.DeletedCount;
        }
    }
}