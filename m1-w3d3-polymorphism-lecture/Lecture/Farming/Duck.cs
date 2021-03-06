﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public class Duck : FarmAnimal
    {
        public override string NameOfAnimal
        {
            get
            {
                return "Duck";
            }
        }

        public override string MakeSoundOnce()
        {
            return "Honk";
        }

        public override string MakeSoundTwice()
        {
            return MakeSoundOnce() + " " + MakeSoundOnce();
        }
    }
}
