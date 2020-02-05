using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletAPI.Models;

namespace WalletAPI.Contract
{
    interface IMovement
    {
        Movement Create(Movement movement);

        List<Movement> Get();

        Movement Get(int id);

        void Remove(int id);

        //Pregunatr por este, el por q existe, creo q es para borrar un seleionado
        //void remove(int id, Movement moventIn);

        //Preguntar por q 2 aqui
        void Upgrade(string id, Movement movementIn);
    }
}
