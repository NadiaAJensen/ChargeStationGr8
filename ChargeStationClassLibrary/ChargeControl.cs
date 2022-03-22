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
        public double LatestCurrent { get; set; }

        public event EventHandler<CurrentChangedEventArgs> CurrentChangeEvent;

        public ChargeControl(IDisplay display, IUSBCharger usbCharger)
        {
            _display = display;
            _usbCharger = usbCharger;
            _usbCharger.CurrentChangedEvent += HandleCurrentChangedEvent;
        }

        private void HandleCurrentChangedEvent(object sender, CurrentChangedEventArgs e)
        {
            LatestCurrent = e.Current;
        }

        public bool IsConnected()
        {
           Connected = _usbCharger.Connected;
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
