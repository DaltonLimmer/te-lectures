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
        }

        // GET: Home
        public ActionResult Index()
        {
            var vendingItems = _db.GetVendingItems();
            InventoryManager im = GetInventoryManager();

            var trans = GetTransactionManager();
            ViewBag.changeAmount = trans.RunningTotal;                
            ViewBag.coins = GetCoinsForChange(trans);

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

            var vi = im.GetVendingItem(row, col);
            var inv = vi.Inventory;

            if (vi.Product.Price < (double)Session["InsertedAmount"] && vi.Inventory.Qty > 0)
            {
                var trans = GetTransactionManager();
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
            double changeAmt = trans.RunningTotal;
            return RedirectToAction("Index", new { changeAmount = changeAmt } );
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

        private string GetCoinsForChange(TransactionManager trans)
        {
            Change change = trans.AddGiveChangeOperation();
            return $"{change.Dollars}b/{change.Quarters}q/{change.Dimes}d/{change.Nickels}n/{change.Pennies}p";
        }


        private InventoryManager GetInventoryManager()
        {
            var vendingItems = _db.GetVendingItems();
            return new InventoryManager(vendingItems);
        }


    }
}