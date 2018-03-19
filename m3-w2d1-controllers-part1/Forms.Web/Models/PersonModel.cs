using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forms.Web.Models
{
    /* STEP 6 */
    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FavoriteColor { get; set; }
        public string State { get; set; }
        public int? KidCount { get; set; }

    }
}