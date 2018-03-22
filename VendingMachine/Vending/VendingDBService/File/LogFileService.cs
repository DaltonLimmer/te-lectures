using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingService.Interfaces;
using VendingService.Models;

namespace VendingService.File
{
    public class LogFileService : ILogService
    {
        private string _folderPath = @"C:\VendingData";
        private string _fileName = @"VendingLog.txt";

        public LogFileService()
        {

        }

        public LogFileService(string folderPath)
        {
            _folderPath = folderPath;
        }

        public LogFileService(string folderPath, string fileName)
        {
            _folderPath = folderPath;
            _fileName = fileName;
        }

        public void LogOperation(VendingOperation operation)
        {
            string filePath = Path.Combine(_folderPath, _fileName);

            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }

            System.IO.File.AppendAllText(filePath, operation.ToString());
        }

        public string GetLogData()
        {
            string filePath = Path.Combine(_folderPath, _fileName);
            return System.IO.File.ReadAllText(filePath);
        }
    }
}
