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
        public bool Connected { get; set; }

        public ChargeControl(IDisplay display, IUSBCharger usbCharger)
        {
            _display = display;
            _usbCharger = usbCharger;
        }

        public bool IsConnected()
        {
            return Connected;
        }
        public void StartCharge()
        {

        }
        public void StopCharge()
        {

        }
    }
}
