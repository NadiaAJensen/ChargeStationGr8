using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeStationClassLibrary
{
    public interface IUSBCharger
    {
        // Event triggered on new current value
        event EventHandler<CurrentChangedEventArgs> CurrentChangedEvent;

        // Direct access to the current current value
        double CurrentValue { get; }

        // Require connection status of the phone
        public bool Connected { get; }

        // Start charging
        void StartCharge();
        // Stop charging
        void StopCharge();

    }
}
