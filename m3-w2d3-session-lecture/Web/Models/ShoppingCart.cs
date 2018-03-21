using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    /* Step 11 - Create Shopping Cart */
    public class ShoppingCart
    {
        public IList<ShoppingCartItem> Items { get; } = new List<ShoppingCartItem>();

        public void AddToCart(Product p)
        {
            //Add new item, if it doesn't exist; otherwise increase quantity by 1
            bool itemFound = false;
            foreach(ShoppingCartItem item in Items)
            {
                if(item.Product.Id == p.Id)
                {
                    item.Quantity++;
                    itemFound = true;
                }
            }

            if(!itemFound)
            {
                Items.Add(new ShoppingCartItem() { Product = p, Quantity = 1 });
            }


        }

        public void RemoveOneFromCart(Product p)
        {
            //Decrease quantity by one; if quantity == 0, remove the item
            ShoppingCartItem itemToRemove = null;
            foreach(ShoppingCartItem item in Items)
            {
                if(item.Product.Id == p.Id)
                {
                    item.Quantity--;
                    if(item.Quantity <= 0)
                    {
                        itemToRemove = item; 
                    }
                }
            }

            Items.Remove(itemToRemove);
            
        }


        public decimal GetTotalCost()
        {

            decimal totalCost = 0m;

            foreach(ShoppingCartItem item in Items)
            {
                totalCost += item.Quantity * item.Product.Cost;
            }

            return totalCost;
        }



    }
}