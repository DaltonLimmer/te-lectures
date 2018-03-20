using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingService;
using VendingService.Database;
using VendingService.Models;

namespace VendingRefiller
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Refill refiller = new Refill();
            //refiller.Start();

            //Playground playground = new Playground();

            VendingDBService db = new VendingDBService();

            CategoryItem category = new CategoryItem()
            {
                Name = "Test",
                Noise = "Test Munch"
            };
            category.Id = db.AddCategoryItem(category);
            category = db.GetCategoryItem(category.Id);

            category.Name = "A";
            category.Noise = "A,A,A";
            db.UpdateCategoryItem(category);
            category = db.GetCategoryItem(category.Id);

            db.DeleteCategoryItem(category.Id);
            var categories = db.GetCategoryItems();


        }
    }
}
