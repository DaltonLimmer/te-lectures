using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetExercises.Web.Models
{
    public class ActorSearch
    {
        public string LastName { get; set; }

        public IList<Actor> Results { get; set; } = new List<Actor>();
    }
}