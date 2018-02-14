using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public class Platypus : IFarmAnimal
    {
        public string NameOfAnimal
        {
            get
            {
                return "Platypus";
            }
        }

        public string MakeSoundOnce()
        {
            return "Fwap";
        }

        public string MakeSoundTwice()
        {
            return MakeSoundOnce() + " " + MakeSoundOnce();
        }

        public void SlapWater()
        {

        }
    }
}
