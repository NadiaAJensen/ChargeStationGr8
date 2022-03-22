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

        public event EventHandler<CurrentChangedEventArgs> CurrentChangeEventArgs;

        public ChargeControl(IDisplay display, IUSBCharger usbCharger)
        {
            _display = display;
            _usbCharger = usbCharger;
            _usbCharger.CurrentChangedEventArgs += HandleCurrentChangedEvent;
            Connected = _usbCharger.Connected;
      }

        private void HandleCurrentChangedEvent(object sender, CurrentChangedEventArgs e)
        {
            LatestCurrent = e.Current;
        }

        public void StartCharge()
        {
            _usbCharger.StartCharge();
        }
        public void StopCharge()
        {
            _usbCharger.StopCharge();
        }
    }
}
