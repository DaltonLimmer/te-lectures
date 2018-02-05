using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsDemo
{
    public class Monitor
    {
        // This is a member variable that holds the on/off state of the monitor
        private bool _isMonitorOn = false;

        public string Name { get; set; }

        public Monitor(string name)
        {
            Name = name;
        }

        // This will return the on/off state of the monitor
        public bool IsMonitorOn()
        {
            return _isMonitorOn;
        }

        // This is a method that changes the on/off state of the monitor to ON
        public void TurnMonitorOn()
        {
            _isMonitorOn = true;
        }

        // This is a method that changes the on/off state of the monitor to OFF
        public void TurnMonitorOff()
        {
            _isMonitorOn = false;
        }
    }
}
