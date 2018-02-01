using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    public partial class LectureExample
    {
        /*
          8.This method checks a parameter passed to the method to see if it's
            greater than 5 and returns true if it is.
            TOPIC: Comparison Operators & Conditional Logic
        */
        public bool ReturnTrueWhenGreaterThanFive(int number)
        {
            bool result = true;

            if (number <= 5)
            {
                result = false;
            }

            return result;
        }
    }
}
