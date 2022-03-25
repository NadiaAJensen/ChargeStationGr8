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

        [TestCase(true)]
        [TestCase(false)]
        public void TestOpenDoorEventIscalledRight(bool status)
        {
           _uut.OpenDoor(status);
           if (status)
           {
               Assert.That(_receivedEventArgs.DoorStatus, Is.EqualTo(status));
               Assert.That(_receivedEventArgs, Is.Not.Null);
           }
           else
           {
               Assert.That(_receivedEventArgs, Is.Null); //Null betyder den ikke er kaldt.
           }
        }


      [TestCase(true)]
      [TestCase(false)]
        public void TestCloseDoorEvent(bool status)
        {
            _uut.CloseDoor(status);

            if (!status)
            {
               Assert.That(_receivedEventArgs.DoorStatus, Is.EqualTo(status));
               Assert.That(_receivedEventArgs, Is.Not.Null);
            }
            else
            {
                Assert.That(_receivedEventArgs, Is.Null);
            }

        }

    }
}
