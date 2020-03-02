using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletAPI.Models;

namespace WalletAPI.Contract
{
    public interface ICategoryService
    {
        bool Create(Category category);

        List<Category> Get();

        Category Get(int id);

        void Remove(int id);

        void Remove(int id, Category categoryIn);

        void Update(int id, Category categoryIn);
    }
}
