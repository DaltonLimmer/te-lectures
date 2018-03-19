/* Step 6 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forms.Web.Models
{
    public class FilmSearchViewModel
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public int? ReleaseYear { get; set; }
        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }
        public string Rating { get; set; }

    }
}

