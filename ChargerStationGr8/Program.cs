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

            ILogFile logFile = new LogFile();

            IDisplay display = new Display();

            USBChargerSimulator usbsChargerSimulator = new USBChargerSimulator();
            ChargeControl chargeControl = new ChargeControl(display, usbsChargerSimulator);

            StationControl stationControl = new StationControl(chargeControl, rfidReader, door, logFile);
            
            

            bool finish = false;
            do
            {
                string input;
                System.Console.WriteLine("Indtast E, O, C, R, u: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                switch (input[0])
                {
                    case 'E':
                        finish = true;
                        break;

                    case 'O':
                        door.OpenDoor(true);
                        break;

                    case 'C':
                        door.CloseDoor(false);
                        break;

                    case 'R':
                        System.Console.WriteLine("Indtast RFID id: ");
                        string idString = System.Console.ReadLine();
                        rfidReader.ReadRFIDTag(Convert.ToInt32(idString));
                        break;
                    
                    case 'u':
                       usbsChargerSimulator.SimulateConnected(true);
                       break; 

                    default:
                        break;
                }

            } while (!finish);
        }

    }
    }

