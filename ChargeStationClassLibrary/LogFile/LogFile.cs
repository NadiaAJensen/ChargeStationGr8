using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeStationClassLibrary.LogFile
{
    public class LogFile : ILogFile
    {
        public int Id { get; set; }
        public bool Locked { get; set; }
        public string Description { get; set; }
        public DateTime TimeStamp { get; set; }

        LogFileSerialize logFileSerialize;

        public LogFile()
        {
            
        }

        public void LogDoorLocked(int id)
        {
            Id = id;
            Locked = true;
            //timestamp (timer, min, sek)
            Description = "Door is locked";
            TimeStamp = DateTime.Now;
        }

        public void LogDoorUnlocked(int id)
        {
            Id = id;
            Locked = false;
            //timestamp (timer, min, sek)
            Description = "Door is unlocked";
            TimeStamp = DateTime.Now;
        }
    }
}
