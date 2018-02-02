using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Enter 'about'");
                Console.WriteLine("");
                Console.WriteLine("Enter 'help'");
                Console.WriteLine("");
                Console.WriteLine("Enter 'q' to Quit");
                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "about":
                        Console.WriteLine("Selected Option About");
                        break;

                    case "help":
                        Console.WriteLine("Selected Option Help");
                        break;

                    case "q":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("I'm Default :(");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
