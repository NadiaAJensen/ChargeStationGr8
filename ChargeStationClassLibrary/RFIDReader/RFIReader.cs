using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeStationClassLibrary.RFIDReader
{
   class RFIReader:IRFIDReader
   {
      public event EventHandler<RFIDChangedEventArgs> IdChangedEvent;
      private Random rdr = new Random();

      public void ReadRFIDTag(int id)
      {
         IdChangedEvent?.Invoke(this,new RFIDChangedEventArgs {Id = id});

      }


   }
}
