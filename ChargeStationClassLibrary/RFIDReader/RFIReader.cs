using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeStationClassLibrary.RFIDReader
{
   public class RFIReader:IRFIDReader
   {
      public event EventHandler<RFIDChangedEventArgs> IdChangedEvent;

      public void ReadRFIDTag(int id)
      {
         IdChangedEvent?.Invoke(this,new RFIDChangedEventArgs {Id = id});

      }


   }
}
