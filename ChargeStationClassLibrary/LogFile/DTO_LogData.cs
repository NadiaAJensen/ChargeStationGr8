using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeStationClassLibrary.LogFile
{
    public class DTO_LogData
    {
        public int Id { get; set; }
        public bool Locked { get; set; }
        public string Description { get; set; }
        public string TimeStamp { get; set; }
    }
}
