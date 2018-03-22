using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingService.Interfaces;

namespace VendingService.File
{
    public class LogFileService : ILogService
    {
        private void LoadData()
        {
            string filePath = @"..\..\..\etc\vendingmachine.csv";

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    
                }
            }
        }
    }
}
