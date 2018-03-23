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
    public class HomeController : ControllerBase
    {

        private IVendingService _db;
        public HomeController(IVendingService db)
        {
            _db = db;
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
                Session["InsertedAmount"] = (double)Session["InsertedAmount"] - vi.Product.Price;
                inv.Qty--;
                _db.UpdateInventoryItem(inv);

                SetFlashMessage($"Purchased {vi.Product.Name}.", FlashMessageType.Warning);

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
            int dollars = 0;
            int quarters = 0;
            int dimes = 0;
            int nickles = 0;
            int pennies = 0;

            int remainingAmount = (int)(changeAmount * 100.0);

            while(remainingAmount > 0)
            {
                if(remainingAmount >= 100)
                {
                    dollars++;
                    remainingAmount -= 100;
                } else if(remainingAmount >= 25)
                {
                    quarters++;
                    remainingAmount -= 25;
                } else if(remainingAmount >= 10)
                {
                    dimes++;
                    remainingAmount -= 10;
                } else if(remainingAmount >= 5)
                {
                    nickles++;
                    remainingAmount -= 5;
                } else if(remainingAmount >= 1)
                {
                    pennies++;
                    remainingAmount -= 1;
                }                
            }

            return $"{dollars}b/{quarters}q/{dimes}d/{nickles}n/{pennies}p";
        }


        private InventoryManager GetInventoryManager()
        {
            var vendingItems = _db.GetVendingItems();
            return new InventoryManager(vendingItems);
        }


    }
}