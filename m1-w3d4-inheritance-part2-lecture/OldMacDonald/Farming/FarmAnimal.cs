using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldMacDonald.Farming
{
    public class FarmAnimal : ISingable
    {
        private bool AmIHungry { get; set; }

        public FarmAnimal()
        {
            AmIHungry = false;
        }
        
        public FarmAnimal(bool amIHungry)
        {
            AmIHungry = amIHungry;
        }

        public FarmAnimal(bool a, string b)
        {
            AmIHungry = a;
        }

        public virtual string MakeSoundOnce() //<-- mark this virtual so that subclasses override it
        {
            return "";
        }
        public virtual string MakeSoundTwice() //<-- the challenge though is what if subclasses dont override it
        {
            return "";
        }        
    }
}
