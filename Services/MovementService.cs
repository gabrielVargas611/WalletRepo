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
    public class MovementService : IMovement
    {
        private const string CollectionName = "Movements";
        private readonly IMongoCollection<Movement> _movement;

        public MovementService(IMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _movement= database.GetCollection<Movement>(CollectionName);
        }

        public bool Create(Movement movement)
        {
            bool result = false;
            try
            {
                _movement.InsertOne(movement);
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

    }
}
