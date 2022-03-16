using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeStationClassLibrary
{
    public class DoorChangedEventArgs: EventArgs
    {
        public bool DoorStatus { get; set; }
    }
}
