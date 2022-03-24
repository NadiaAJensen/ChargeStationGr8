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

            ILogFile logFile = new LogFile(new DTO_LogData(), new LogFileSerialize());

            IDisplay display = new Display();

            USBChargerSimulator usbsChargerSimulator = new USBChargerSimulator();
            ChargeControl chargeControl = new ChargeControl(display, usbsChargerSimulator);

            StationControl stationControl = new StationControl(chargeControl, rfidReader, door, logFile, display);


            bool finish = false;
            Console.WriteLine("Control Menu");
            Console.WriteLine("----------------------");
            Console.WriteLine("To put in your phone: Open door, put phone to charger, enter RFID id and close door ");
            Console.WriteLine("To take your phone: Enter RFID id, open door take phone off charger and close door");
            Console.WriteLine("[O]      Open door");
            Console.WriteLine("[U]      Simulates phone to charger");
            Console.WriteLine("[C]      Close door");
            Console.WriteLine("[R]      Enter RFID id");
            Console.WriteLine("[W]      Simulates phone off charger");
            Console.WriteLine("[E]      Ending Program");

            do
            {
                string input;

                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                switch (input[0])
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
                        finish = true;
                        break;
                }
            } while (!finish);
        }
    }

}
    

