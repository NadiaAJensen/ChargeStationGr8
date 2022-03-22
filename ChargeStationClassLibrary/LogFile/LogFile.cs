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
        private LogFileSerialize _logFileSerialize;


        public LogFile(DTO_LogData dtoLog, LogFileSerialize logFileSerialize)
        {
            dtoLogData = dtoLog;
            _logFileSerialize = logFileSerialize;
        }

        public void LogDoorLocked(int id)
        {
            dtoLogData.Id = id;
            dtoLogData.Locked = true;
            dtoLogData.Description = "Door is locked";
            dtoLogData.TimeStamp = DateTime.Now.ToString("HH':'mm':'ss");
            _logFileSerialize.Save(dtoLogData);
        }

        public void LogDoorUnlocked(int id)
        {
            dtoLogData.Id = id;
            dtoLogData.Locked = false;
            dtoLogData.Description = "Door is unlocked";
            dtoLogData.TimeStamp = DateTime.Now.ToString("HH':'mm':'ss");
         _logFileSerialize.Load(dtoLogData, @"..\..\logFile.json");
        }
    }
}
