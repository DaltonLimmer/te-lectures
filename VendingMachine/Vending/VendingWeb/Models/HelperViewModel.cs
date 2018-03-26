using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendingService.Helpers;

namespace VendingWeb.Models
{
    public class HelperViewModel
    {
        public InventoryManager Inv { get; set; } = null;
        public TransactionManager Trans { get; set; } = null;
        public ReportManager Report { get; set; } = null;
    }
}