using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsDemo
{
    public class Classroom
    {
        // This is a member variable that holds a list of Monitor objects
        private List<Monitor> _monitors = new List<Monitor>();

        // This is a read only property returns the number of items in the Monitors list
        public int NumberOfMonitors
        {
            get
            {
                return _monitors.Count;
            }
        }

        // This is a method that adds a monitor to the Monitors collection
        public void AddMonitor(Monitor item)
        {
            _monitors.Add(item);
        }

        // This is a method that turns on a specific monitor based on the index passed in
        public void TurnMonitorOn(string name)
        {
            foreach (Monitor item in _monitors)
            {
                if (item.Name == name)
                {
                    item.TurnMonitorOn();
                }
            }
        }

        // This is a method that turns off a specific monitor based on the index passed in
        public void TurnMonitorOff(string name)
        {
            foreach (Monitor item in _monitors)
            {
                if (item.Name == name)
                {
                    item.TurnMonitorOff();
                }
            }
        }

    }
}
