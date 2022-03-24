using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

            if (LatestCurrent == 0)
            {
                _display.PrintString("No phone connected");
            }
            else if(LatestCurrent >0 && LatestCurrent<=5)
            {
                StopCharge();
                _display.PrintString("Phone fully charged");
            }
            else if (LatestCurrent > 5 && LatestCurrent <= 500)
            {
                
                _display.PrintString("Chargeing ongoing");
            }
            else if (LatestCurrent > 500)
            {
                StopCharge();
                _display.PrintString("Error in chargeing");
            }
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
