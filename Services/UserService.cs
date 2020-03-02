using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletAPI.Contract;
using WalletAPI.Models;
using WalletAPI.Settings;

namespace WalletAPI.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private const string CollectionName = "Users";
        
        public UserService(IMongoDbSettings settings)
            : base(settings,CollectionName)
        {
            
        }

        public List<User> Get() => MongoCollection.Find(_user => true).ToList();

        public User Get(int id) => MongoCollection.Find(user => user.id == id).FirstOrDefault();

        public bool Create(User user)
        {
            bool result = false;
            try
            {
                MongoCollection.InsertOne(user);
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public void Remove(int id) =>
            MongoCollection.DeleteOne(user => user.id == id);

        public void Remove(int id, User userIn) =>
           MongoCollection.DeleteOne(user => user.id == userIn.id);

        public void Update(int id, User userIn)
        {
            MongoCollection.ReplaceOne(user => user.id == id, userIn);
        }
    }
}
