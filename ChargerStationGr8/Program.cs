using System;
using ChargeStationClassLibrary;
using ChargeStationClassLibrary.Display;
using ChargeStationClassLibrary.LogFile;
using ChargeStationClassLibrary.Door;
using ChargeStationClassLibrary.RFIDReader;

namespace ChargerStationGr8
{
    class Program
    {
        static void Main(string[] args)
        {

            IRFIDReader rfidReader = new RFIReader();

            IDoor door = new Door();

            ILogFile logFile = new LogFile(new DTO_LogData(),new LogFileSerialize());

            IDisplay display = new Display();

            USBChargerSimulator usbsChargerSimulator = new USBChargerSimulator();
            ChargeControl chargeControl = new ChargeControl(display, usbsChargerSimulator);

            StationControl stationControl = new StationControl(chargeControl, rfidReader, door, logFile);

            bool cont = true;
            Console.WriteLine("Control Menu");
            Console.WriteLine("----------------------");
            Console.WriteLine("[O]      Open door");
            Console.WriteLine("[C]      Close door");
            Console.WriteLine("[R]      Indtast RFID id");
            Console.WriteLine("[U]      Simulates phone to charger");
            Console.WriteLine("[W]      Simulates phone off charger");
            Console.WriteLine("[E]      Ending Program");

            while (cont)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case 'O':
                    case 'o':
                        door.OpenDoor(true);
                        break;
                    case 'C':
                    case 'c':
                        door.CloseDoor(false);
                        break;
                    case 'R':
                    case 'r':
                        display.PrintString("Indtast RFID id: ");
                        string idString = System.Console.ReadLine();
                        rfidReader.ReadRFIDTag(Convert.ToInt32(idString));
                        break;
                    case 'U':
                    case 'u':
                        usbsChargerSimulator.SimulateConnected(true);
                        break;
                    case 'W':
                    case 'w':
                        usbsChargerSimulator.SimulateConnected(false);
                        break;
                    case 'E':
                    case 'e':
                        cont = false;
                        break;
                }
            }
        }

    }
    }

