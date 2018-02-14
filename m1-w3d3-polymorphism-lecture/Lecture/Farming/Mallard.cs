using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public class Mallard : Duck, ISuperHero
    {
        public override string NameOfAnimal
        {
            get
            {
                return "Mallard";
            }
        }

        public virtual void Fly()
        {
            Console.Beep();
            Console.Beep();
            Console.Beep();
        }

        public override string MakeSoundOnce()
        {
            return "Honk";
        }

        public override string MakeSoundTwice()
        {
            return "Honk Honk";
        }
    }
}
