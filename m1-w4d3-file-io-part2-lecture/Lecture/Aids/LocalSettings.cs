using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lecture.Aids
{
    [Serializable]
    public class LocalSettings
    {
        public bool IsThisCool = true;
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastSaveDate { get; set; }
        public List<Preference> Preferences { get; set; } = new List<Preference>();
    }
}
