using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            Mammal mammal = new Mammal();
            Reptile reptar = new Reptile();

            bool isWarmBlooded1 = mammal.IsWarmBlooded();
            bool isWarmBlooded2 = reptar.IsWarmBlooded();

            

            int children = mammal.LiveBirth(10);
            Console.WriteLine($"Number of children is {children}");

            children = mammal.LiveBirth(10);
            Console.WriteLine($"Number of children is {children}");

            children = mammal.LiveBirth(10);
            Console.WriteLine($"Number of children is {children}");

            Console.WriteLine($"Mammal warm blooded is {mammal.IsWarmBlooded()} and my Reptile warm blooded is {reptar.IsWarmBlooded()}");
            Console.ReadKey();
        }
    }
}
