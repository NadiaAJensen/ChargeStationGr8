using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeStationClassLibrary
{
    public class CurrentChangedEventArgs : EventArgs
    {
        public double Current { get; set; }
    }
}
