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

        [Test]
        public void StartChargeIsCalled()
        {
            _uut.StartCharge();

            _fakeUsbCharger.Received(1).StartCharge();
        }

        [Test]
        public void StopeChargeIsCalled()
        {
            _uut.StopCharge();

            _fakeUsbCharger.Received(1).StopCharge();
        }

        [Test]
        public void StartChargeIsNotCalled()
        {
            _fakeUsbCharger.Received(0).StartCharge();
        }

        [Test]
        public void StopeChargeIsNotCalled()
        {
            _fakeUsbCharger.Received(0).StopCharge();
        }


        [TestCase(0)]
        public void CurrentChanged_ValueZero(int newCurrent)
        {
            _fakeUsbCharger.CurrentChangedEventArgs +=
                Raise.EventWith(new CurrentChangedEventArgs { Current = newCurrent });

            _fakeDisplay.Received(1).PrintString("No phone connected");
        }

        [TestCase(1)]
        [TestCase(5)]
        public void CurrentChanged_ValueBetweenZeroAndFive(int newCurrent)
        {
            _fakeUsbCharger.CurrentChangedEventArgs +=
                Raise.EventWith(new CurrentChangedEventArgs { Current = newCurrent });
            
            
            _fakeDisplay.Received(1).PrintString("Phone fully charged");
        }

        [TestCase(6)]
        [TestCase(500)]
        public void CurrentChanged_ValueBetweenFiveAndFivehundred(int newCurrent)
        {
            _fakeUsbCharger.CurrentChangedEventArgs +=
                Raise.EventWith(new CurrentChangedEventArgs { Current = newCurrent });


            _fakeDisplay.Received(1).PrintString("Chargeing ongoing");
        }

        [TestCase(501)]
        public void CurrentChanged_ValueOverFivehundred(int newCurrent)
        {
            _fakeUsbCharger.CurrentChangedEventArgs +=
                Raise.EventWith(new CurrentChangedEventArgs { Current = newCurrent });


            _fakeDisplay.Received(1).PrintString("Error in chargeing");
        }

    }
}
