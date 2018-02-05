using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Discussion();
            //DemoClassroom();
            DemoStrings();
        }

        // How would we represent a monitor?
        // How would we represent a classroom full of monitors?
        private static void Discussion()
        {
            
        }

        private static void DemoStrings()
        {
            string name = "Ada Lovelace";

            // Strings are actually arrays of characters (char). 
            // Those characters can be accessed using [] notation.

            // 1. Write code that prints out the first and last characters
            //      of name.
            // Output: A
            // Output: e

            Console.WriteLine("First and Last Character. ");
            Console.WriteLine(name[0]);
            Console.WriteLine(name[name.Length - 1]);

            // 2. How do we write code that prints out the first three characters
            // Output: Ada

            // Console.WriteLine("First 3 characters: ");
            string firstThree = name.Substring(0, 3);
            Console.WriteLine(firstThree);

            // 3. Now print out the first three and the last three characters
            // Output: Adaace
            // Use SubString

            // Console.WriteLine("Last 3 characters: ");

            // 4. What about the last word?
            // Output: Lovelace
            // Use Split

            // Console.WriteLine("Last Word: ");


            // 5. Does the string contain inside of it "Love"?
            // Output: true
            // Use Contains

            // Console.WriteLine("Contains \"Love\"");

            // 6. Where does the string "lace" show up in name?
            // Output: 8
            // Use IndexOf

            // Console.WriteLine("Index of \"lace\": ");

            // 7. How many 'a's OR 'A's are in name?
            // Output: 3
            // Use split

            //Console.WriteLine("Number of \"a's\": ");

            // 8. Replace "Ada Lovelace" with "Ada, Countess of Lovelace"
            string result = name.Replace("Ada Lovelace", "Ada, Countess of Lovelace");

            // Console.WriteLine(name);

            // 9. Set name equal to null.

            // 10. If name is equal to null or "", print out "All Done".

            Console.ReadKey();
        }

        private static void DemoClassroom()
        {
            Monitor monitor1 = null;
            Monitor monitor2 = new Monitor("chris");
            //Look at the values of monitor1 and monitor2

            monitor1 = new Monitor("david");
            //Look at monitor names

            monitor1.TurnMonitorOn();
            //Look at the monitor on/off states

            Classroom dotNetClass = new Classroom();
            dotNetClass.AddMonitor(monitor1);
            dotNetClass.AddMonitor(monitor2);
            //Look at the items in the dotNetClass

            dotNetClass.TurnMonitorOff("david");
            dotNetClass.TurnMonitorOn("chris");
            //Look at the monitor on/off states
        }
    }
}
