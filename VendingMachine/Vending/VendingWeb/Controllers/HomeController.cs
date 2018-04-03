using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VendingService.Helpers;
using VendingService.Interfaces;
using VendingService.Models;
using VendingWeb.Models;

namespace VendingWeb.Controllers
{
    public class HomeController : ControllerBase
    {

        private IVendingService _db;
        private ILogService _log;

        public HomeController(IVendingService db, ILogService log)
        {
            _db = db;
            _log = log;

            //ReportManager reportMgr = new ReportManager(db);
            //Report report = reportMgr.GetReport(2018, _db.GetProductItems());
            //var items = report.ReportItems;
        }

        // GET: Home
        public ActionResult Index()
        {
            var vendingItems = _db.GetVendingItems();
            InventoryManager im = GetInventoryManager();

            var trans = GetTransactionManager();
            HelperViewModel model = GetHelperViewModel(trans, im);

            return View(model);
        }


        [HttpPost]
        public ActionResult AddMoney(string amount, int[] hiddenSample)
        {
            double dAmount = Convert.ToDouble(amount.Replace("$", ""));

            var trans = GetTransactionManager();
            trans.AddFeedMoneyOperation(dAmount);

            SetFlashMessage($"{dAmount.ToString("C")} inserted.");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult BuyItem(int row, int col)
        {
            InventoryManager im = GetInventoryManager();
            var trans = GetTransactionManager();

            var vi = im.GetVendingItem(row, col);
            var inv = vi.Inventory;

            if (vi.Product.Price < trans.RunningTotal && vi.Inventory.Qty > 0)
            {
                trans.AddPurchaseTransaction(vi.Product.Id);

                inv.Qty--;
                _db.UpdateInventoryItem(inv);

                SetFlashMessage($"Purchased {vi.Product.Name}.", FlashMessageType.Warning);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult GetChange()
        {
            var trans = GetTransactionManager();
            trans.AddGiveChangeOperation();            
            
            return RedirectToAction("Index");
        }

        private TransactionManager GetTransactionManager()
        {
            TransactionManager trans = null;

            if (Session["TransactionManager"] == null)
            {
                trans = new TransactionManager(_db, _log);
                Session["TransactionManager"] = trans;
            }
            else
            {
                trans = Session["TransactionManager"] as TransactionManager;
            }

            return trans;
        }

        private HelperViewModel GetHelperViewModel(TransactionManager trans, InventoryManager inv = null, ReportManager report = null)
        {
            HelperViewModel helper = new HelperViewModel();
            helper.Inv = inv;
            helper.Trans = trans;
            helper.Report = report;

            return helper;
        }

        private InventoryManager GetInventoryManager()
        {
            var vendingItems = _db.GetVendingItems();
            return new InventoryManager(vendingItems);
        }


    }
}