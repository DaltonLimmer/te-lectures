using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingRefiller
{
    public class Program
    {
        static void Main(string[] args)
        {
            Refill refiller = new Refill();
            refiller.Start();
        }
    }
}
