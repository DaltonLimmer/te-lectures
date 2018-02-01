using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variables_And_DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            /* VARIABLES & DATA TYPES */
            //1. Create a variable to hold an int and call it numberOfExercises.
            //Then set it to 26.

            int numberOfExercises;
            numberOfExercises = 26;

            Console.WriteLine(numberOfExercises);

            /*
            2. Create a variable to hold a double and call it half.
                Set it to 0.5.
            */

            double half = 0.5;

            Console.WriteLine(half);

            /*
            3. Create a variable to hold a string and call it name.
                Set it to "TechElevator".
            */
            string name = "TechElevator";            

            Console.WriteLine(name);

            /*
            4. Create a variable called seasonsOfFirefly and set it to 1.
            */
            byte seasonsOfFirefly = 1;

            Console.WriteLine(seasonsOfFirefly);

            /*
            5. Create a variable called myFavoriteLanguage and set it to "C#".
            */
            string myFavoriteLanguage = "C#";

            Console.WriteLine(myFavoriteLanguage);

            /*
            6. Create a variable called pi and set it to 3.1416.
            */

            double pi = 3.1416;

            Console.WriteLine(pi);

            /*
            7. Create and set a variable that holds your name.
            */

            name = "Chris";

            Console.WriteLine(name);

            /*
            8. Create and set a variable that holds the number of buttons on your mouse.
            */

            byte numOfButtons = 6;

            Console.WriteLine(numOfButtons);

            /*
            9. Create and set a variable that holds the percentage of battery left on
            your phone.
            */

            float percentBatteryLife = 0.94F;

            Console.WriteLine(percentBatteryLife);

            /* EXPRESSIONS */

            /*
            10. Create an int variable that holds the difference between 121 and 27.
            */
            int answer = 121 - 27;

            Console.WriteLine(answer);
            /*
            11. Create a double that holds the addition of 12.3 and 32.1.
            */
            double value = 12.3 + 32.1;

            Console.WriteLine(value);

            /*
            12. Create a string that holds your full name.
            */
            string firstName = "Christopher";
            string lastName = "Rupp";

            Console.WriteLine(firstName + " " + lastName);

            /*
            13. Create a string that holds the word "Hello, " concatenated onto your
            name from above.
            */
            string greeting = String.Format("{0} {1} Hello", 
                                            firstName, 
                                            lastName);

            Console.WriteLine(greeting);

            /*
            14. Add a " Esquire" onto the end of your full name and save it back to
            the same variable.
            */
            string esquire = firstName;
            esquire = esquire + " ";
            esquire = esquire + lastName;
            esquire = esquire + " Esquire";

            Console.WriteLine(esquire);

            /*
            15. Now do the same as exercise 14, but use the += operator.
            */
            esquire = firstName;
            esquire += " ";
            esquire += lastName;
            esquire += " Esquire";

            Console.WriteLine(esquire);

            /*
            16. Create a variable to hold "Saw" and add a 2 onto the end of it.
            */
            string saw = "Saw" + 2;

            Console.WriteLine(saw);

            /*
            17. Add a 0 onto the end of the variable from exercise 16.
            */
            saw += 0;

            Console.WriteLine(saw);

            /*
            18. What is 4.4 divided by 2.2?
            */
            float result = 4.4F / 2.2F;

            Console.WriteLine(result);

            /*
            19. What is 5.4 divided by 2?
            */
            result = 5.4F / 2;

            Console.WriteLine(result);

            /* CASTING */

            /*
            20. What is 5 divided by 2?
            */
            value = 5 / 2;

            Console.WriteLine(value);

            /*
            21. What is 5.0 divided by 2?
            */
            value = 5.0 / 2;

            Console.WriteLine(value);

            /*
            22. Create a variable that holds a bank balance with the value of 1234.56.
            */
            decimal myBankStatement = (decimal) 1234.56;

            Console.WriteLine(myBankStatement);

            /*
            23. What is the String "2" added to the number 10?
            */
            string strDouble = "2" + 10;

            Console.WriteLine(strDouble);

            /*
            24. What two variables: 3 and 1,000,000,000 and multiple them together. 
                What is the result?
            */
            long bigNumber = (long)3 * 1000000000;

            Console.WriteLine(bigNumber);

            /*
            25. Create a variable that holds a boolean called doneWithExercises and
            set it to false.
            */
            bool doneWithExercises = false;

            Console.WriteLine(doneWithExercises);

            /*
            26. Now set doneWithExercise to true.
            */
            doneWithExercises = true;

            Console.WriteLine(doneWithExercises);

            // Will is fit
            byte makeItFit = (byte)(4.4 / 2.2);

            Console.WriteLine(makeItFit);

            Console.ReadKey();
        }
    }
}
