using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    public partial class LectureProblem
    {
        /*
         10. What code do we need to write so that we can find the highest
             number in the array randomNumbers?
             TOPIC: Looping Through Arrays
        */
        public int FindTheHighestNumber(int[] randomNumbers)
        {
            int result = randomNumbers[0];

            for(int i = 1; i < randomNumbers.Length; i++)
            {
                if (randomNumbers[i] > result)
                {
                    result = randomNumbers[i];
                }
            }

            return result;
        }
    }
}
