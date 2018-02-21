using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lecture.Aids
{
    [Serializable]
    public class Preference
    {
        public string Name { get; set; }
        public List<string> Options { get; set; } = new List<string>();
    }
}
