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
        //private CurrentChangedEventArgs _receivedEventArgs;

        [SetUp]
        public void Setup()
        {
            //_receivedEventArgs = null;
            _fakeDisplay = Substitute.For<IDisplay>();
            _fakeUsbCharger = Substitute.For<IUSBCharger>();

            _uut = new ChargeControl(_fakeDisplay, _fakeUsbCharger);

            //_uut.CurrentChangeEvent += (o, args) => _receivedEventArgs = args;
        }

        
        [TestCase(true)]
        [TestCase(false)]
        [TestCase(true)]
        public void TestConnectedIsAsSet(bool connected)
        {
            _uut.Connected = connected;

            Assert.That(_uut.Connected, Is.EqualTo(connected));
        }

        [TestCase(300)]
        [TestCase(400)]
        [TestCase(500)]
        public void CurrentChanged_DifferentArguments_CurrentCurrentIsCorrect(int newCurrent)
        {
            _fakeUsbCharger.CurrentChangedEventArgs +=
                Raise.EventWith(new CurrentChangedEventArgs {Current = newCurrent});
            

            Assert.That(_uut.LatestCurrent, Is.EqualTo(newCurrent));
        }

        
    }
}
