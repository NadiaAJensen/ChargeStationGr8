using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ChargeStationClassLibrary.Door;
using ChargeStationClassLibrary.RFIDReader;
using ChargeStationClassLibrary.LogFile;

namespace ChargeStationClassLibrary
{
    public class StationControl
    {
        private LogFileSerialize logFileSerialize;

        private DTO_LogData _dtoLogData;
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

        private string logFile = "logFile.json"; // Navnet på systemets log-fil

        public StationControl(IRFIDReader rfidReader, IDoor door, DTO_LogData dtoLog)
        {
            _door = door;
            door.DoorStatusChangedEvent += HandleDoorChangedEvents;

            rfidReader.IdChangedEvent += HandleRFIDChangedEvent;
            _dtoLogData = dtoLog;
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
                        logFileSerialize.Save(_dtoLogData);
                        //using (var writer = File.AppendText(logFile))
                        //{
                        //    writer.WriteLine(DateTime.Now + ": Skab låst med RFID: {0}", id);
                        //}

                        //Console.WriteLine("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        Console.WriteLine("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
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
                        logFileSerialize.Load(_dtoLogData, logFile);
                    //    using (var writer = File.AppendText(logFile))
                    //    {
                    //        writer.WriteLine(DateTime.Now + ": Skab låst op med RFID: {0}", id);
                    //    }

                    //    Console.WriteLine("Tag din telefon ud af skabet og luk døren");
                           _state = LadeskabState.Available;
                    
                    }
                    else
                    {
                        Console.WriteLine("Forkert RFID tag");
                    }

                    break;
            }
        }

        public void DoorOpened()
        {
        }

        public void DoorClosed()
        {

        }

        public void CheckID(int oldId, int id)
        {

        }

        private void HandleDoorChangedEvents(object sender, DoorChangedEventArgs e)
        {
            if (e.DoorStatus)
            {
                _state = LadeskabState.DoorOpen;
            }
            else
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
