using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargerStationGr8;
using ChargeStationClassLibrary;
using ChargeStationClassLibrary.RFIDReader;
using NSubstitute;
using NUnit.Framework;

namespace ChargeStationUnitTests
{
   public class TestRFIDreader
   {
      private RFIReader _uut;
      private RFIDChangedEventArgs _receivedEventArgs;
      private StationControl _stationControl;

         [SetUp]
      public void Setup()
      {
         _receivedEventArgs = null;
         _uut = new RFIReader();
         _uut.IdChangedEvent += (o, args) => _receivedEventArgs = args;

      }

      [TestCase(1234)]
      [TestCase(0001)]

      public void TestReadId_IsCalled_WithTheRightId(int id)
      {
         _uut.ReadRFIDTag(id);
         if (id != 0)
         {
            Assert.That(_receivedEventArgs.Id, Is.EqualTo(id));
            Assert.That(_receivedEventArgs, Is.Not.Null);
         }
         else
         {
            Assert.That(_receivedEventArgs, Is.Null);

         }

      }

    
   }
}
