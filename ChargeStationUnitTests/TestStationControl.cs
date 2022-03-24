using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargeStationClassLibrary;
using ChargeStationClassLibrary.Display;
using ChargeStationClassLibrary.Door;
using ChargeStationClassLibrary.LogFile;
using ChargeStationClassLibrary.RFIDReader;
using NUnit.Framework;
using NSubstitute;

namespace ChargeStationUnitTests
{
   public class TestStationControl
   {
      private StationControl _uut;
      private IChargeControl _fakeChargeControl;
      private IRFIDReader _fakeRfidReader;
      private IDoor _fakeDoor;
      private ILogFile _fakeLogFile;
      private IDisplay _fakeDisplay;

      [SetUp]
      public void Setup()
      {
         _fakeChargeControl = Substitute.For<IChargeControl>();
         _fakeRfidReader = Substitute.For<IRFIDReader>();
         _fakeDoor = Substitute.For<IDoor>();
         _fakeLogFile = Substitute.For<ILogFile>();
         _fakeDisplay = Substitute.For<IDisplay>();
         

         _uut = new StationControl(_fakeChargeControl, _fakeRfidReader, _fakeDoor, _fakeLogFile, _fakeDisplay);
      }
   
      [TestCase(1234)]
      public void TestRFIDdetected_CorrectID_StateAvailable(int id)
      {
          _fakeChargeControl.Connected = true;
          _fakeRfidReader.IdChangedEvent += Raise.EventWith(new RFIDChangedEventArgs {Id = id});
          _fakeDoor.DoorStatusChangedEvent += Raise.EventWith(new DoorChangedEventArgs { DoorStatus = true });

            _fakeLogFile.Received(1).LogDoorLocked(id);
      }

    

      [TestCase(1000)]
      public void TestRFIDdetected_FalseID_StateAvailable(int id)
      {
          _fakeChargeControl.Connected = false;

          _fakeRfidReader.IdChangedEvent += Raise.EventWith(new RFIDChangedEventArgs { Id = id });

          _fakeDisplay.Received(1).PrintString("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");

      }
      [TestCase(1234, false)]
      public void TestRFIDdetected_CorrectID_StateLocked(int id, bool state)
      {
          _fakeChargeControl.Connected = true;

          _fakeRfidReader.IdChangedEvent += Raise.EventWith(new RFIDChangedEventArgs { Id = id });
          //should set the old id

          //_fakeDoor.DoorStatusChangedEvent += Raise.EventWith(new DoorChangedEventArgs { DoorStatus = state });

          _fakeRfidReader.IdChangedEvent += Raise.EventWith(new RFIDChangedEventArgs { Id = id });

            _fakeDisplay.Received(1).PrintString("Tag din telefon ud af skabet og luk døren");

            _fakeLogFile.Received(1).LogDoorUnlocked(id);
      }

      [TestCase(1234,1000, false)]
      public void TestRFIDdetected_FalseID_StateLocked(int Old_id, int new_id, bool state)
      {
          _fakeChargeControl.Connected = true;

          _fakeRfidReader.IdChangedEvent += Raise.EventWith(new RFIDChangedEventArgs { Id = Old_id });
          //should set the old id

          //_fakeDoor.DoorStatusChangedEvent += Raise.EventWith(new DoorChangedEventArgs { DoorStatus = state });

          _fakeRfidReader.IdChangedEvent += Raise.EventWith(new RFIDChangedEventArgs { Id = new_id });

          _fakeDisplay.Received(1).PrintString("Forkert RFID tag");

          
      }

      [Test]

      public void Testdooropen_noRFIDDetected()
      {
         _fakeChargeControl.Connected = true;

         _fakeDoor.DoorStatusChangedEvent += Raise.EventWith(new DoorChangedEventArgs { DoorStatus = false });

         _fakeDisplay.Received(1).PrintString("Indlæs RFID");

      }

      [TestCase(1234, 1234, false)]

      public void Testdoorclosed_oldIdIsNotNulld(int Old_id, int new_id, bool state)
      {
         _fakeDoor.DoorStatusChangedEvent += Raise.EventWith(new DoorChangedEventArgs { DoorStatus = false });
         _fakeChargeControl.Connected = true;
         _fakeRfidReader.IdChangedEvent += Raise.EventWith(new RFIDChangedEventArgs { Id = Old_id });
         _fakeRfidReader.IdChangedEvent += Raise.EventWith(new RFIDChangedEventArgs { Id = new_id });
         
         _fakeDisplay.Received(1).PrintString("Tag din telefon ud af skabet og luk døren");
      }


   }
}
