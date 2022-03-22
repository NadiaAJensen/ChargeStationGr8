using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeStationClassLibrary
{
    public interface IChargeControl
    {
        event EventHandler<CurrentChangedEventArgs> CurrentChangeEventArgs;
        bool Connected { get; set; }
        void StartCharge();
        void StopCharge();


    }
}
