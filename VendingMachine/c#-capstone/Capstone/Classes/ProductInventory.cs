using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class ProductInventory
    {
        // The inventory defaults to 5
        private int _qty = 5;

         // Sales numbers default to 0.
        private int _salesnumber = 0;


        public Product Product { get; private set; }

        public string SaleQty
        {
            get
            {
                return _salesnumber.ToString();
            }
        }

        public string Qty
        {
            get
            {
                if (_qty <= 0)
                {
                    return "Sold Out";
                }
                else
                {
                    return _qty.ToString();
                }
            }
            set
            {

            }
        }

        public ProductInventory(Product product, int qty)
        {
            Product = product;
            _qty = qty;
        }

        public ProductInventory(Product product)
        {
            Product = product;
        }

        // Methods
        public int DeductItem()
        {
            return --_qty;
        }

        public int AddToSalesReport()
        {
            return ++_salesnumber;
        }


    }
}
