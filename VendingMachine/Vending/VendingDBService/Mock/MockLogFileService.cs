using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingService.Interfaces;
using VendingService.Models;

namespace VendingService.Mock
{
    public class MockLogFileService : ILogService
    {
        private List<VendingOperation> _operations = new List<VendingOperation>();

        public void LogOperation(VendingOperation operation)
        {
            _operations.Add(operation.Clone());
        }

        public string GetLogData()
        {
            string result = "";

            foreach (var item in _operations)
            {
                result += item.ToString() + "\n\r";
            }

            return result;
        }
    }
}
