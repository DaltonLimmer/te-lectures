using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTime
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Chess gameSession = new Chess(2);
                Console.WriteLine(gameSession.Instructions);

                string winner = gameSession.PlayGame();
                Console.WriteLine($"The winner is {winner}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
