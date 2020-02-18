using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalletAPI.Models
{
    public class Movement
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Ammount { get; set; }

        public DateTime DateTime { get; set; }

        public bool movementType { get; set; }
    }
}
