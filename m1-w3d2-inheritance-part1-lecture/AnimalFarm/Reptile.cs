using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFarm
{
    public class Reptile : Animal
    {
        public override bool IsWarmBlooded()
        {
            bool isWarmBlooded = base.IsWarmBlooded();
            return false;
        }

        public Reptile()
        {
            
        }
    }
}
