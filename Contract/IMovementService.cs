using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletAPI.Models;

namespace WalletAPI.Contract
{
    public interface IMovementService
    {
        bool Create(Movement movement);

        List<Movement> Get();

        Movement Get(int id);

        void Remove(int id);

        void Remove(int id, Movement moventIn);

        void Update(int id, Movement movementIn);
    }
}
