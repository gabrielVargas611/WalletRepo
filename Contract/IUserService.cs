using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletAPI.Models;

namespace WalletAPI.Contract
{
    public interface IUserService
    {
        bool Create(User user);

        List<User> Get();

        User Get(int id);

        void Remove(int id);

        void Remove(int id, User userIn);

        void Update(int id, User userIn);
    }
}
