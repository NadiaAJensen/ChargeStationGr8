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

      [Test]
      public void TestReadIdIsCalledWithAnId()
      {
         _uut.ReadRFIDTag(1234);
         Assert.That(_receivedEventArgs, Is.Not.Null);
      }
      [TestCase(1234)]
      [TestCase(0000)]
      [TestCase(0001)]

      public void TestReadId_IsCalled_WithTheRightId(int id)
      {
         _uut.ReadRFIDTag(id);
         Assert.That(_receivedEventArgs.Id,Is.EqualTo(id));
      }

      public void TestReadId_ifnothingiscalled(int id)
      {
         Assert.That(_receivedEventArgs.Id, Is.Null);
      }
   }
}
