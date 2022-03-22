using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargerStationGr8;
using ChargeStationClassLibrary.RFIDReader;
using NUnit.Framework;

namespace ChargeStationUnitTests
{
   public class TestRFIDreader
   {
      private RFIReader _uut;
      private RFIDChangedEventArgs _receivedEventArgs;

      [SetUp]
      public void Setup()
      {
         _receivedEventArgs = null;
         _uut = new RFIReader();
         _uut.IdChangedEvent += (o, args) => _receivedEventArgs = args;

      }

      [Test]
      public void testReadIdIsCalledWithAnId()
      {
         _uut.ReadRFIDTag(1234);
         Assert.That(_receivedEventArgs, Is.Not.Null);
      }
      [Test]

      public void testReadId_IsCalled_WithTheRightId()
      {
         _uut.ReadRFIDTag(1234);
         Assert.That(_receivedEventArgs.Id,Is.EqualTo(1234));
      }
   }
}
