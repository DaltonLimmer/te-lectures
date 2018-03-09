using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingService;

namespace Capstone.Classes
{
    class Chips : Product
    {
  
        // Constructor
        public Chips(string[] list):base(list)
        {

        }

        public Chips(InventoryItem item) : base(item)
        {

        }

        // Methods
        public override string EatSound()
        {
            return "Crunch Crunch, Yum!";
        }

    }
}
