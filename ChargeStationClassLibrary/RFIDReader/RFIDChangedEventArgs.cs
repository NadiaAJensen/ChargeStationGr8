using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeStationClassLibrary.RFIDReader
{
   public class RFIDChangedEventArgs: EventArgs
   {
      public int Id { get; set; }
   }
}
