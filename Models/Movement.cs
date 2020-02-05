using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalletAPI.Models
{
    public class Movement
    {
       private int Id { get; set; }

       private string Name { get; set; }

        private string Category { get; set; }

        private decimal Ammount { get; set; }

        private DateTime DateTime { get; set; }

        private Boolean Type { get; set; }
    }
}
