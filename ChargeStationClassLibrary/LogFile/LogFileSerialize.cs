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
        // Tjek Solution "Configuration" fra ITS3 3. semester
        public void Save(LogFile logData)
        {

            string json = JsonSerializer.Serialize(logData);
            File.WriteAllText(@"..\..\nameOfFile.json", json);
        }
        public LogFile Load(LogFile logData, string path)
        {
            string text = File.ReadAllText(path);
            LogFile logFileConfig = JsonSerializer.Deserialize<LogFile>(text);
            return logFileConfig;

            // tilføj kode som overskriver 
        }
    }
}
