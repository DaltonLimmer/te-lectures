
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public class Chicken : FarmAnimal
    {
        public override string NameOfAnimal
        {
            get
            {
                return "Chicken";
            }
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
