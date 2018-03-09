using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingService;

namespace Capstone.Classes
{
    class Nuts : Product
    {

        // Constructor
        public Nuts(string[] list) : base(list)
        {

        }

        public Nuts(InventoryItem item) : base(item)
        {

        }

        //Methods
        public override string EatSound()
        {
            return "Nibble Nibble, Yum!";
        }
    }
}

