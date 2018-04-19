using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Hashing
{
    class Program
    {


        static void Main()
        {
            string saltString = "abcdefgh";
            byte[] salt = ASCIIEncoding.ASCII.GetBytes(saltString);

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            // MD5
            Console.WriteLine("MD5 Hash");
            Console.WriteLine("Hash Attempt 1".PadRight(20) + HashPasswordWithMD5(password));
            Console.WriteLine("Hash Attempt 2".PadRight(20) + HashPasswordWithMD5(password));

            Console.WriteLine();
            Console.WriteLine("...press a key");
            Console.ReadLine();

            // PBKDF2 w/SALT
            Console.WriteLine("PBKDF2 Hash - Same Salt");
            Console.WriteLine(" The # of iterations (work factor) provides a different hash");
            Console.WriteLine("".PadRight(25) + "SALT".PadRight(15) + "HASH");
            Console.WriteLine("Same Salt (10)".PadRight(25) + HashPasswordWithPBKDF2(password, salt, 10));
            Console.WriteLine("Same Salt (10)".PadRight(25) + HashPasswordWithPBKDF2(password, salt, 10));
            Console.WriteLine("Same Salt (100)".PadRight(25) + HashPasswordWithPBKDF2(password, salt, 100));
            Console.WriteLine("Same Salt (100)".PadRight(25) + HashPasswordWithPBKDF2(password, salt, 100));
            for (var i = 0; i < 50; i++)
            {
                Console.WriteLine("Same Salt (10,000)".PadRight(25) + HashPasswordWithPBKDF2(password, salt, 10000));
                Console.WriteLine("Same Salt (10,000)".PadRight(25) + HashPasswordWithPBKDF2(password, salt, 10000));
            }
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("Same Salt (100,000)".PadRight(25) + HashPasswordWithPBKDF2(password, salt, 100000));
                Console.WriteLine("Same Salt (100,000)".PadRight(25) + HashPasswordWithPBKDF2(password, salt, 100000));
            }
            Console.WriteLine();
            Console.WriteLine("...press a key");
            Console.ReadLine();

            // PBKDF2 w/Random SALT
            Console.WriteLine("PBKDF2 Hash - Random Salt");
            Console.WriteLine(" Notice that a different salt provides a completely different hash.");
            Console.WriteLine(" This allows two different users to use the same password.");
            Console.WriteLine("".PadRight(25) + "SALT".PadRight(15) + "HASH");
            Console.WriteLine("Random Salt (10)".PadRight(25) + HashPasswordWithPBKDF2(password, 8, 10));
            Console.WriteLine("Random Salt (10)".PadRight(25) + HashPasswordWithPBKDF2(password, 8, 10));
            Console.WriteLine("Random Salt (100)".PadRight(25) + HashPasswordWithPBKDF2(password, 8, 100));
            Console.WriteLine("Random Salt (100)".PadRight(25) + HashPasswordWithPBKDF2(password, 8, 100));
            Console.WriteLine("Random Salt (10,000)".PadRight(25) + HashPasswordWithPBKDF2(password, 8, 10000));
            Console.WriteLine("Random Salt (10,000)".PadRight(25) + HashPasswordWithPBKDF2(password, 8, 10000));
            Console.WriteLine("Random Salt (100,000)".PadRight(25) + HashPasswordWithPBKDF2(password, 8, 100000));
            Console.WriteLine("Random Salt (100,000)".PadRight(25) + HashPasswordWithPBKDF2(password, 8, 100000));

            Console.WriteLine();
            Console.WriteLine("...press a key");
            Console.ReadLine();

        }

        static string HashPasswordWithMD5(string password)
        {
            MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();

            byte[] source = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hash = md5Provider.ComputeHash(source);

            return Convert.ToBase64String(hash);
        }

        static string HashPasswordWithPBKDF2(string password, byte[] salt, int workFactor)
        {
            // Creates the crypto service provider and provides the salt - usually used to check for a password match
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, workFactor);

            byte[] hash = rfc2898DeriveBytes.GetBytes(20);      //gets the hased password

            return Convert.ToBase64String(salt) + " | " + Convert.ToBase64String(hash);
        }

        static string HashPasswordWithPBKDF2(string password, int saltSize, int workFactor)
        {
            //Creates the crypto service provider and says to use a random salt of size "saltSize"
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltSize, workFactor);

            byte[] hash = rfc2898DeriveBytes.GetBytes(20);      //gets the hashed password
            byte[] salt = rfc2898DeriveBytes.Salt;              //gets the random salt

            return Convert.ToBase64String(salt) + " | " + Convert.ToBase64String(hash);
        }
    }
}
