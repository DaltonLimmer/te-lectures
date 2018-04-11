using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetExercises.Web.Models
{
    public class CustomerSearch
    {
        public string Name { get; set; }
        public string SortByColumn { get; set; }

        public IList<SelectListItem> SortOptions { get; set; } = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Last Name", Value = "last_name" },
            new SelectListItem() { Text = "Email", Value = "email" },
            new SelectListItem() { Text = "Active", Value = "active"}
        };


        public IList<Customer> Results { get; set; } = new List<Customer>();
    }
}