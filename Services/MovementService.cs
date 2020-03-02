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
    public class MovementService : ServiceBase<Movement>, IMovementService
    {
        private const string CollectionName = "Movements";

        public MovementService(IMongoDbSettings settings)
            : base(settings, CollectionName)
        {
        }

        public List<Movement> Get() => MongoCollection.Find(movement => true).ToList();

        public Movement Get(int id) => MongoCollection.Find(movement => movement.Id == id).FirstOrDefault();

        public bool Create(Movement movement)
        {
            bool result = false;
            try
            {
                MongoCollection.InsertOne(movement);
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public void Update(int id, Movement movementIn)
        {
            MongoCollection.ReplaceOne(movement => movement.Id == id, movementIn);
        }

        public void Remove(int id,Movement moventIn) =>
           MongoCollection.DeleteOne(movement => movement.Id == moventIn.Id);

        public void Remove(int id) =>
            MongoCollection.DeleteOne(movement => movement.Id == id);

    }
}
