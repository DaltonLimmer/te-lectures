using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public class FarmAnimal
    {
        public virtual string NameOfAnimal
        {
            get
            {
                return "Console";
            }
        }

        public virtual string MakeSoundOnce()
        {
            Console.Beep();
            return "Beep";
        }

        public virtual string MakeSoundTwice()
        {
            Console.Beep();
            Console.Beep();
            return "Beep Beep";
        }
    }
}
