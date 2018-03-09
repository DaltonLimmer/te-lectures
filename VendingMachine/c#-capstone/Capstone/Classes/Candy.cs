using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingService;

namespace Capstone.Classes
{
    class Candy : Product
    {
        
        // Constructor
        public Candy(string[] list) : base(list)
        {

        }

        public Candy(InventoryItem item) : base(item)
        {

        }

        // Methods
        public override string EatSound()
        {
            return "Munch Munch, Yum!";
        }
    }
}
