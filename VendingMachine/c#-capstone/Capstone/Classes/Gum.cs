using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingService;

namespace Capstone.Classes
{
    class Gum : Product
    {

        // Constructor
        public Gum(string[] list) : base(list)
        {

        }

        public Gum(InventoryItem item) : base(item)
        {

        }

        //Methods
        public override string EatSound()
        {
            return "Chew Chew, Yum!";
        }
    }
}
