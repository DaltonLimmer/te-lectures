using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingService;

namespace Capstone.Classes
{
    class Beverage : Product
    {

        // Constructor
        public Beverage(string[] list) : base(list)
        {

        }

        public Beverage(InventoryItem item) : base(item)
        {

        }

        //Methods
        public override string EatSound()
        {
            return "Glug Glug, Yum!";
        }
    }
}
