using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] test = { 1, 2, 3, 4 };

            int i = 0;
            for(; i++ < 3;)
            {
                Console.WriteLine(test[i]);
            }
            Console.ReadKey();
        }
    }
}
