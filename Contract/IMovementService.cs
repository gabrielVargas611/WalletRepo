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

        // Pregunatr por este, el por q existe, creo q es para borrar un seleionado
        void Remove(int id, Movement moventIn);

        // Preguntar por q 2 aqui
        void Upgrade(int id, Movement movementIn);
    }
}
