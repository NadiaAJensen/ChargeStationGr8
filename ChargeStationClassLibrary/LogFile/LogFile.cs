using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeStationClassLibrary.LogFile
{
    public class LogFile : ILogFile
    {
        private DTO_LogData dtoLogData;

        public LogFile(DTO_LogData dtoLog)
        {
            dtoLogData = dtoLog;
        }

        public void LogDoorLocked(int id)
        {
            dtoLogData.Id = id;
            dtoLogData.Locked = true;
            dtoLogData.Description = "Door is locked";
            dtoLogData.TimeStamp = DateTime.Now;
        }

        public void LogDoorUnlocked(int id)
        {
            dtoLogData.Id = id;
            dtoLogData.Locked = false;
            dtoLogData.Description = "Door is unlocked";
            dtoLogData.TimeStamp = DateTime.Now;
        }
    }
}
