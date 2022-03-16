using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeStationClassLibrary.LogFile
{
    public interface ILogFile
    {
        public void LogDoorLocked(int id);

        public void LogDoorUnlocked(int id);
    }
}
