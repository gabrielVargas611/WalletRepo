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
    public class CategoryService :ServiceBase<Category>, ICategoryService
    {
        private const string CollectionName = "Categories";

        public CategoryService(IMongoDbSettings settings)
                : base(settings, CollectionName)
        {
        }

        public bool Create(Category category)
        {
            bool result = false;
            try
            {
                MongoCollection.InsertOne(category);
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public List<Category> Get() => MongoCollection.Find(category => true).ToList();

        public Category Get(int id) => MongoCollection.Find(category => category.id == id).FirstOrDefault();


        public void Remove(int id, Category categoryIn) =>
           MongoCollection.DeleteOne(category => category.id == categoryIn.id);

        public void Remove(int id) =>
            MongoCollection.DeleteOne(category => category.id == id);

        public void Update(int id, Category categoryIn)
        {
            MongoCollection.ReplaceOne(category => category.id == id, categoryIn);
        }
    }
}
