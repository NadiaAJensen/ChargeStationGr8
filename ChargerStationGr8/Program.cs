using System;
using ChargeStationClassLibrary;
using ChargeStationClassLibrary.LogFile;

namespace ChargerStationGr8
{
    class Program
    {
        static void Main(string[] args)
        {
            //json:
            var logFile = new LogFile();
            var logFileControl = new LogFileSerialize();


            logFileControl.Save(logFile); // hvis DoorIsUnlocked

            logFileControl.Load(logFile, @"..\..\logFile.json"); // hvis DoorIsLocked

            Console.WriteLine("Hello World!");
        }
    }
}
