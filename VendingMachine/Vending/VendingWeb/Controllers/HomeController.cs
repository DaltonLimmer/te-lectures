using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VendingService.Helpers;
using VendingService.Interfaces;
using VendingService.Models;

namespace VendingWeb.Controllers
{
    public class HomeController : Controller
    {

        private IVendingService _db;
        private ITransactionManager _trans;
        public HomeController(IVendingService db, ITransactionManager trans)
        {
            _db = db;
            _trans = trans;
        }

        // GET: Home
        public ActionResult Index(double? changeAmount)
        {
            if (Session["InsertedAmount"] == null) Session["InsertedAmount"] = 0.0;

            var vendingItems = _db.GetVendingItems();
            InventoryManager im = GetInventoryManager();

            if (changeAmount.HasValue)
            {
                ViewBag.changeAmount = changeAmount;                
                ViewBag.coins = getCoinsForChange(changeAmount.Value);
            }

            return View(im);
        }


        [HttpPost]
        public ActionResult AddMoney(string amount, int[] hiddenSample)
        {

            double dAmount = Convert.ToDouble(amount.Replace("$", ""));

            Session["InsertedAmount"] = (double)Session["InsertedAmount"] + dAmount;

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
                Session["InsertedAmount"] = (double)Session["InsertedAmount"] - vi.Product.Price;
                inv.Qty--;
                _db.UpdateInventoryItem(inv);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult GetChange()
        {
            double changeAmt = (double)Session["InsertedAmount"];
            Session["InsertedAmount"] = 0.0;
            return RedirectToAction("Index", new { changeAmount = changeAmt } );
        }


        private string getCoinsForChange(double changeAmount)
        {
            Change change = TransactionManager.GetChange(changeAmount);
            return $"{change.Dollars}b/{change.Quarters}q/{change.Dimes}d/{change.Nickels}n/{change.Pennies}p";
        }


        private InventoryManager GetInventoryManager()
        {
            var vendingItems = _db.GetVendingItems();
            return new InventoryManager(vendingItems);
        }
    }
}