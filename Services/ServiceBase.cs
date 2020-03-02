using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletAPI.Settings;

namespace WalletAPI.Services
{
    public abstract class ServiceBase<T>
    {
        private readonly IMongoCollection<T> _collection;

        public IMongoCollection<T> MongoCollection
        {
            get { return _collection; }
        }

        public ServiceBase(IMongoDbSettings settings, string collectionName)
        {
           _collection = SetupMongo<T>(settings, collectionName);
        }

        private IMongoCollection<T> SetupMongo<T>(IMongoDbSettings settings, string collectionName)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            return database.GetCollection<T>(collectionName);
        }
    }
}
