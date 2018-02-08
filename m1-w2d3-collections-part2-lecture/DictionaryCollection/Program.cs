using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Person / Height Database");
            Console.WriteLine();

            Console.Write("Would you like to enter another person (yes/no)? ");
            string input = Console.ReadLine().ToLower();

            // 1. Let's create a new Dictionary that could hold string, ints
            //      | "Josh"    | 70 |
            //      | "Bob"     | 72 |
            //      | "John"    | 75 |
            //      | "Jack"    | 73 |

            var dictionaryVariable = new Dictionary<string, int>();            

            while (input == "yes" || input == "y")
            {
                Console.Write("What is the person's name?: ");
                string name = Console.ReadLine();

                Console.Write("What is the person's height (in inches)?: ");
                int height = int.Parse(Console.ReadLine());
                
                // 2. Check to see if that name is in the dictionary
                bool exists = dictionaryVariable.ContainsKey(name);

                if (!exists)
                {
                    Console.WriteLine($"Adding {name} with new value.");
                    // 3. Put the name and height into the dictionary
                    dictionaryVariable.Add(name, height);
                }
                else
                {
                    Console.WriteLine($"Overwriting {name} with new value.");
                    // 4. Overwrite the current key with a new value
                    dictionaryVariable[name] = height;
                }

                Console.WriteLine();
                Console.Write("Would you like to enter another person (yes/no)? ");
                input = Console.ReadLine().ToLower();
            }

            Console.Write("Type \"all\" to print all names OR \"search\" to print out single name: ");
            input = Console.ReadLine().ToLower();

            if (input == "search")
            {
                Console.Write("Which name are you looking for? ");
                input = Console.ReadLine();

                //5. Let's get a specific name from the dictionary
                if (dictionaryVariable.ContainsKey(input))
                {
                    int height = dictionaryVariable[input];
                    Console.Write($"{input} is {height} inches tall.");
                }
                else
                {
                    Console.Write("Dude, it aint here!");
                }
            }
            else if (input == "all")
            {
                Console.WriteLine();
                Console.WriteLine(".... printing ...");

                //6. Let's print each item in the dictionary
                PrintDictionary(dictionaryVariable);
            }

            Console.WriteLine();            

            //7. Let's get the average height of the people in the dictionary
            var heights = dictionaryVariable.Values;
            //long sum = 0;
            int avg = 0;

            if (heights.Count > 0)
            {
                avg = (int) heights.Average();

                //foreach (var tempHeight in heights)
                //{
                //    sum += tempHeight;
                //}
                //avg = (int)(sum / heights.Count);
            }

            //dictionaryVariable.Remove("chris");

            Console.WriteLine($"The average height is: {avg}");
            Console.WriteLine("Done...");

            Console.ReadKey();

            //LinkedList<string> linkedList = new LinkedList<string>();
            //LinkedListNode<string> nextNode = linkedList.First;
            //var node2 = nextNode.Previous;

            //linkedList.AddAfter(nextNode, "chris");

            // Dictionary<T,T>
            // Create -> var dictionaryVariable = new Dictionary<string, int>(); 
            // Add -> dictionaryVariable.Add(name, height);
            // Update -> dictionaryVariable[name] = height;
            // Remove -> dictionaryVariable.Remove("chris");
            // Loop through KeyValuePairs<T,T> -> foreach (KeyValuePairs<string,int> item in dictionaryVariable)
            // Get List of Values -> var heights = dictionaryVariable.Values;
            // Check if key exists -> dictionaryVariable.ContainsKey(name);
        }

        static void PrintDictionary(Dictionary<string, int> database)
        {
            // Looping through a dictionary involves using a foreach loop
            // to look at each item, which is a key-value pair
            foreach (var item in database)
            {
                Console.WriteLine($"{item.Key} is {item.Value} inches tall.");
            }
        }
    }
}
