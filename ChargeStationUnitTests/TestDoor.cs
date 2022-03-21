using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ChargeStationClassLibrary.Door;

namespace ChargeStationUnitTests
{
    class TestDoor
    {
        private Door _uut;
        private DoorChangedEventArgs _receivedEventArgs;

        [SetUp]
        public void Setup()
        {
            _receivedEventArgs = null; 
            _uut = new Door();

            _uut.DoorStatusChangedEvent += (o, args) => _receivedEventArgs = args;
        }

        [Test]
        public void TestUnLockDoor()
        {
            var stringwriter = new StringWriter();
            Console.SetOut(stringwriter);

            _uut.UnLockDoor();
            Assert.AreEqual("Door is unlocked\r\n", stringwriter.ToString());
        }

        [Test]
        public void TestLockDoor()
        {
            var stringwriter = new StringWriter();
            Console.SetOut(stringwriter);

            _uut.LockDoor();
            Assert.AreEqual("Door is locked\r\n", stringwriter.ToString());
        }

        [Test]
        public void TestOpenDoorEvent()
        {
            _uut.OpenDoor(true);
            Assert.That(_receivedEventArgs,Is.Not.Null);
        }

        [Test]
        public void TestCloseDoorEvent()
        {
            _uut.CloseDoor(false);
            Assert.That(_receivedEventArgs, Is.Not.Null);
        }

    }
}
