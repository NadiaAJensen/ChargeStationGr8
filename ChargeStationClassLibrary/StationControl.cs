using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ChargeStationClassLibrary.Door;
using ChargeStationClassLibrary.RFIDReader;
using ChargeStationClassLibrary.LogFile;
using ChargeStationClassLibrary.Display;

namespace ChargeStationClassLibrary
{
    public class StationControl
    {
        private ILogFile _logFile;
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private LadeskabState _state;
        private IChargeControl _charger; 
        private int _oldId;
        private IDoor _door;
        private IDisplay _display;

        private string logFile = "logFile.json"; // Navnet på systemets log-fil

        public StationControl(IChargeControl chargeControl, IRFIDReader rfidReader, IDoor door, ILogFile logfile, IDisplay display)
        {
            _state = LadeskabState.Available;
            _charger = chargeControl;
            _door = door;
            _logFile = logfile;
            _display = display;
            door.DoorStatusChangedEvent += HandleDoorChangedEvents;

            rfidReader.IdChangedEvent += HandleRFIDChangedEvent;
        }

        //Logik om ID == OldID skal skrives i denne klasse
        private void RfidDetected(int id)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_charger.Connected)
                    {
                        _door.LockDoor();
                        _charger.StartCharge(); 
                        _oldId = id;
                        _logFile.LogDoorLocked(id);
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        _display.PrintString("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
                    }

                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    break;

                case LadeskabState.Locked:
                    // Check for correct ID
                    if (id == _oldId)
                    {
                        _charger.StopCharge();
                        _door.UnLockDoor();
                        _logFile.LogDoorUnlocked(id);
                        

                        _display.PrintString("Tag din telefon ud af skabet og luk døren");
                           _state = LadeskabState.Available;
                    }
                    else
                    {
                        _display.PrintString("Forkert RFID tag");
                    }

                    break;
            }
        }


        private void HandleDoorChangedEvents(object sender, DoorChangedEventArgs e)
        {
            if (e.DoorStatus)
            {
                _state = LadeskabState.DoorOpen;
                _display.PrintString("Tilslut telefon");
            }

            if (e.DoorStatus&&_charger.Connected)
            {
               _state = LadeskabState.Available;
            }
            else if(e.DoorStatus==false)
            {
                _state = LadeskabState.Locked;
               
         }
        }

        private void HandleRFIDChangedEvent(object sender, RFIDChangedEventArgs e)
        {
            RfidDetected(e.Id);
        }
    }
}
