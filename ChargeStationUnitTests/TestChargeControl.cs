using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargerStationGr8;
using ChargeStationClassLibrary;
using ChargeStationClassLibrary.Display;
using NSubstitute;
using NUnit.Framework;

namespace ChargeStationUnitTests
{
    public class TestChargeControl
    {
        private ChargeControl _uut;
        private IDisplay _fakeDisplay;
        private IUSBCharger _fakeUsbCharger;

        [SetUp]
        public void Setup()
        {
            _fakeDisplay = Substitute.For<IDisplay>();
            _fakeUsbCharger = new USBChargerSimulator();

            _uut = new ChargeControl(_fakeDisplay, _fakeUsbCharger);
        }

        
        [TestCase("TestString3")]
        public void StringIsPrintetCorrectly(string text)
        {
            
        }
    }
}
