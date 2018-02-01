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
        15. Now, do it again with a different bool operation.
        TOPIC: Logical Not
        */
        public string ReturnAdultOrMinorAgain(int number)
        {
            string result = "Minor";

            // if not an minor
            if (!(number < 18))
            {
                result = "Adult";
            }

            return result;
        }
    }
}
