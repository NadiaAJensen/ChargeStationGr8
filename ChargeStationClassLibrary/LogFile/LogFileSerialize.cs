using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChargeStationClassLibrary.LogFile
{
    public class LogFileSerialize
    {
        
        public void Save(DTO_LogData dtoLogData)
        {
            string json = JsonSerializer.Serialize(dtoLogData);
            File.WriteAllText(@"..\..\logFile.json", json);
        }
        public DTO_LogData Load(string path)
        {
                string text = File.ReadAllText(path);
                DTO_LogData logFileConfig = JsonSerializer.Deserialize<DTO_LogData>(text);
                return logFileConfig;
        }

        
    }
}
