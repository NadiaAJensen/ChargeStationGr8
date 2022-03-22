﻿using System;
using System.Collections.Generic;
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

      [Test]

      public void testRFIDdetected()
      {
         
      }
   }
}
