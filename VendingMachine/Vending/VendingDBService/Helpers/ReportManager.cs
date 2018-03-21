using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingService.Database;
using VendingService.Interfaces;

namespace VendingService.Helpers
{
    public class ReportManager
    {
        private IVendingService _db = new VendingDBService();

        public string GetReport(int year)
        {
            string report = "";

            


            return report;
        }
    }
}
