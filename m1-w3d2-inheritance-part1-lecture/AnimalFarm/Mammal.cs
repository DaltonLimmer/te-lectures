using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFarm
{
    public class Mammal : Animal
    {
        Random _random = new Random();

        public Mammal()
        {
            
        }

        public int LiveBirth(int maxChildren)
        {
            int children = _random.Next(maxChildren);
            return children;
        }
    }
}
