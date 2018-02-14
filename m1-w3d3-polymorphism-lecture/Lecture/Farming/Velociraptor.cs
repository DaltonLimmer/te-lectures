using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public class Velociraptor : IFarmAnimal
    {
        public string NameOfAnimal
        {
            get
            {
                return "Velociraptor";
            }
        }

        public string MakeSoundOnce()
        {
            return "Screeawww....";
        }

        public string MakeSoundTwice()
        {
            return MakeSoundOnce() + " " + MakeSoundOnce();
        }
    }
}
