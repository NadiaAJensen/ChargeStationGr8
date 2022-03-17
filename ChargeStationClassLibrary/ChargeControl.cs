using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargeStationClassLibrary.Display;

namespace ChargeStationClassLibrary
{
    public class ChargeControl : IChargeControl
    {
        private IDisplay _display;
        private IUSBCharger _usbCharger;

        public ChargeControl(IDisplay display, IUSBCharger usbCharger)
        {
            _display = display;
            _usbCharger = usbCharger;
        }
    }
}
