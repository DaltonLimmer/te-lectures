
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldMacDonald.Farming
{
    public class Chicken : FarmAnimal
    {
        public Chicken()
        {

        }

        public Chicken(bool amIHungry, string name) : base(amIHungry, "chicken")
        {
            
        }

        public override string MakeSoundOnce()
        {
            return "Cluck";
        }

        public override string MakeSoundTwice()
        {
            return "Cluck Cluck";
        }

        public void LayEgg()
        {
            Console.WriteLine("Bakaw");
        }

    }
}
