using Lecture.Farming;
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
            //
            // OLD MACDONALD
            //
            Chicken chicken = new Chicken();
            Cow cow = new Cow();
            Duck duck = new Duck();
            Velociraptor cicero = new Velociraptor();
            Platypus occam = new Platypus();

            // Show implicit casting (Chicken to Farm Animal)
            FarmAnimal console = duck;
            Console.WriteLine(console.NameOfAnimal);
            Console.WriteLine(console.MakeSoundOnce());
            Console.WriteLine(console.MakeSoundTwice());
            Console.WriteLine();

            // Show explicit casting (FarmAnimal to Chicken)
            Duck myDuck = (Duck) console;
            Console.WriteLine(myDuck.NameOfAnimal);
            Console.WriteLine(myDuck.MakeSoundOnce());
            Console.WriteLine(myDuck.MakeSoundTwice());
            Console.WriteLine();

            //Applying Polymorphism, we're allowed to work in terms of 
            // generic types and not concrete classes. In this case
            // the list holds a collection of IFarmAnimal, meaning
            // any class that implements the IFarmAnimal interface is allowed 
            // to be in the list.
            //Console.WriteLine("Old MacDonald had a farm ee ay ee ay oh");

            //Console.WriteLine("And on his farm there was a " + chicken.NameOfAnimal + " ee ay ee ay oh");
            //Console.WriteLine("With a " + chicken.MakeSoundTwice() + " here and a " + chicken.MakeSoundTwice() + " there");
            //Console.WriteLine("Here a " + chicken.MakeSoundOnce() + ", there a " + chicken.MakeSoundOnce() + " everywhere a " + chicken.MakeSoundTwice());
            //Console.WriteLine("Old Macdonald had a farm, ee ay ee ay oh");
            //Console.WriteLine();

            //Console.WriteLine("And on his farm there was a " + cow.NameOfAnimal + " ee ay ee ay oh");
            //Console.WriteLine("With a " + cow.MakeSoundTwice() + " here and a " + cow.MakeSoundTwice() + " there");
            //Console.WriteLine("Here a " + cow.MakeSoundOnce() + ", there a " + cow.MakeSoundOnce() + " everywhere a " + cow.MakeSoundTwice());
            //Console.WriteLine("Old Macdonald had a farm, ee ay ee ay oh");
            //Console.WriteLine();

            //Console.WriteLine("And on his farm there was a " + duck.NameOfAnimal + " ee ay ee ay oh");
            //Console.WriteLine("With a " + duck.MakeSoundTwice() + " here and a " + duck.MakeSoundTwice() + " there");
            //Console.WriteLine("Here a " + duck.MakeSoundOnce() + ", there a " + duck.MakeSoundOnce() + " everywhere a " + duck.MakeSoundTwice());
            //Console.WriteLine("Old Macdonald had a farm, ee ay ee ay oh");
            //Console.WriteLine();

            // ----- THIS IS GETTING REPETITIVE! 
            // We can do better
            // How can we use what we've learned about inheritance
            // to help us remove code duplication
            // 
            // What if we create some sort of base class that all our animals have in common?

            List<FarmAnimal> animals = new List<FarmAnimal>();
            animals.Add(chicken);
            animals.Add(cow);
            animals.Add(duck);

            Console.WriteLine("Old MacDonald had a farm ee ay ee ay oh");
            foreach (FarmAnimal animal in animals)
            {
                Console.WriteLine("And on his farm there was a " + animal.NameOfAnimal + " ee ay ee ay oh");
                Console.WriteLine("With a " + animal.MakeSoundTwice() + " here and a " + animal.MakeSoundTwice() + " there");
                Console.WriteLine("Here a " + animal.MakeSoundOnce() + ", there a " + animal.MakeSoundOnce() + " everywhere a " + animal.MakeSoundTwice());
                Console.WriteLine("Old Macdonald had a farm, ee ay ee ay oh");
                Console.WriteLine();
            }

            // Interface
            List<IFarmAnimal> interfaceAnimals = new List<IFarmAnimal>();
            interfaceAnimals.Add(cicero);
            interfaceAnimals.Add(occam);

            Console.WriteLine();
            Console.WriteLine("Old MacDonald had a farm ee ay ee ay oh");
            foreach (IFarmAnimal animal in interfaceAnimals)
            {
                Console.WriteLine("And on his farm there was a " + animal.NameOfAnimal + " ee ay ee ay oh");
                Console.WriteLine("With a " + animal.MakeSoundTwice() + " here and a " + animal.MakeSoundTwice() + " there");
                Console.WriteLine("Here a " + animal.MakeSoundOnce() + ", there a " + animal.MakeSoundOnce() + " everywhere a " + animal.MakeSoundTwice());
                Console.WriteLine("Old Macdonald had a farm, ee ay ee ay oh");
                Console.WriteLine();
            }
                       

            George friend = new George();
            friend.Fly();
            Console.WriteLine(friend.NameOfAnimal);
            Console.WriteLine(friend.MakeSoundOnce());
            Console.WriteLine(friend.MakeSoundTwice());
            Console.WriteLine();

            friend.

            Console.ReadKey();
        }
    }
}
