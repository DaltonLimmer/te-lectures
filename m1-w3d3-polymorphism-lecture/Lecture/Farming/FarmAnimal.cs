using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public abstract class FarmAnimal
    {
        public abstract string NameOfAnimal { get; }

        public abstract string MakeSoundOnce();

        public abstract string MakeSoundTwice();
    }
}
