using System;
using ChargeStationClassLibrary;
using ChargeStationClassLibrary.LogFile;
using ChargeStationClassLibrary.Door;
using ChargeStationClassLibrary.RFIDReader;

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

            IRFIDReader rfidReader;

            IDoor door = new Door();

            bool finish = false;
            do
            {
                string input;
                System.Console.WriteLine("Indtast E, O, C, R: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                switch (input[0])
                {
                    case 'E':
                        finish = true;
                        break;

                    case 'O':
                        door.OpenDoor();
                        break;

                    case 'C':
                        door.CloseDoor();
                        break;

                    case 'R':
                        System.Console.WriteLine("Indtast RFID id: ");
                        string idString = System.Console.ReadLine();

                        int id = Convert.ToInt32(idString);
                        rfidReader.OnRfidRead(id);
                        break;

                    default:
                        break;
                }

            } while (!finish);
        }

    }
    }

