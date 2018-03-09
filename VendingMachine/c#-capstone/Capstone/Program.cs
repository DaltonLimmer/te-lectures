using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Capstone.Classes;
using VendingService;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                VendingMachine vm = new VendingMachine();
                vm.TurnOn();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.ReadKey();
            }
     
        }
    }
}
