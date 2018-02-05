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
            // Static Method
            Console.WriteLine("Hi");

            // Instance Method
            Classroom class1 = new Classroom();
            class1.AddMonitor(new Monitor("chris"));

            int i = 0, x = 0;
            if (i == x)
            {

            }

            Classroom class2 = new Classroom();
            if (class1.Equals(class2))
            {

            }
        }

        private static void DemoStrings()
        {
            string name = "Ada Lovelace";

            Console.WriteLine(name);
            Console.WriteLine();


            // Strings are actually arrays of characters (char). 
            // Those characters can be accessed using [] notation.

            // 1. Write code that prints out the first and last characters
            //      of name.
            // Output: A
            // Output: e
            // Use brackets

            Console.WriteLine("First and Last Character. ");
            Console.WriteLine(name[0]);
            Console.WriteLine(name[name.Length - 1]);

            // 2. How do we write code that prints out the first three characters
            // Output: Ada
            // Use substring

            Console.WriteLine("First 3 characters: ");
            Console.WriteLine(name[0].ToString() + name[1].ToString() + name[2].ToString());
            Console.WriteLine(name.Substring(0,3));

            // 3. Now print out the first three and the last three characters
            // Output: Adaace
            // Use SubString

            Console.WriteLine("Last 3 characters: ");
            Console.WriteLine(name.Substring(0, 3) + name.Substring(name.Length - 3));

            // 4. What about the last word?
            // Output: Lovelace
            // Use Split

            Console.WriteLine("Last Word: ");
            string[] names = name.Split(' ');
            if (names != null && names.Length >= 2)
            {
                Console.WriteLine(names[1]);
            }

            // 5. Does the string contain inside of it "Love"?
            // Output: true
            // Use Contains
            
            Console.WriteLine("Contains \"Love\"");
            if (name.Contains("Love"))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

            // 6. Where does the string "lace" show up in name?
            // Output: 8
            // Use IndexOf
            int index = name.IndexOf("lace");

            Console.WriteLine("Index of \"lace\": " + index);
            string myStr = string.Format("Index of \"lace\": {0} {1} {2} {3}", 
                                            index, 
                                            index, 
                                            index, 
                                            index);
            Console.WriteLine(myStr);

            string myStr2 = $"Index of \"lace\": {index} {index} {index} {index}";
            Console.WriteLine(myStr2);

            // 7. How many 'a's OR 'A's are in name?
            // Output: 3
            // Use split
            names = name.Split('a');            
            Console.WriteLine("Number of \"a's\": " + $"{names.Length - 1}");

            names = name.Split('A');
            Console.WriteLine("Number of \"A's\": " + $"{names.Length - 1}");

            // 8. Replace "Lovelace" with ", Countess of Lovelace"
            // use replace
            string temp = name.Replace("Lovelace", ", Countess of Lovelace");
            Console.WriteLine(name);
            Console.WriteLine(temp);

            // 9. Set name equal to null.
            name = "";

            // 10. If name is equal to null or "", print out "All Done".
            if ((name == null) || (name == ""))
            {
                Console.WriteLine("All Done");
            }

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
