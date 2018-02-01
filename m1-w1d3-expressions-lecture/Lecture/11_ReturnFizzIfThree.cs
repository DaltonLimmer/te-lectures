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
        11. Write an if statement that returns "Fizz" 
            if the parameter is 3  returns an empty string for anything else.
            TOPIC: Conditional Logic
        */
        public string ReturnFizzIfThree(int number)
        {
            string result = "";

            //if the parameter is 3 return fizz
            if (number == 3)
            {
                result = "Fizz";
            }

            return result;
        }
    }
}
