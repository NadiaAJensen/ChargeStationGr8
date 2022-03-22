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
   public class TesRFIDreader
   {
      private RFIReader _uut;
      [SetUp]
      public void Setup()
      {
         _uut = new RFIReader();
      }

      [Test]
      public void test()
      {

      }
   }
}
