using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeStationClassLibrary.RFIDReader
{
   public interface IRFIDReader
   {
      event EventHandler<RFIDChangedEventArgs> IdChangedEvent;
      public void ReadRFIDTag(int id);
   }
}
