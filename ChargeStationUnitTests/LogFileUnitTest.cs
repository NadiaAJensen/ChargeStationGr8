using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargeStationClassLibrary;
using ChargeStationClassLibrary.LogFile;
using NUnit.Framework;

namespace ChargeStationUnitTests
{
    [TestFixture]
    public class LogFileUnitTest
    {
        private LogFile _uut;
        private DTO_LogData _uutDtoLogData;

        [SetUp]
        public void Setup()
        {
            _uutDtoLogData = new DTO_LogData();
            _uut = new LogFile(_uutDtoLogData, new LogFileSerialize());
            
        }

        [TestCase(1234)]
        [TestCase(2345)]
        [TestCase(3456)]
        [TestCase(4567)]
        [TestCase(5678)]
        [TestCase(6789)]
        [TestCase(7890)]

        public void IdDetected(int id) 
        {
            _uut.LogDoorLocked(id);
            Assert.That(_uutDtoLogData.Id, Is.EqualTo(id));
        }


        [Test]
        public void IsCalled_LockDoorLocked()
        {
            _uut.LogDoorLocked(1234);
            Assert.That(_uutDtoLogData.Id, Is.EqualTo(1234));
            Assert.That(_uutDtoLogData.Description, Is.EqualTo("Door is locked"));
            Assert.That(_uutDtoLogData.Locked, Is.EqualTo(true));
            Assert.That(_uutDtoLogData.TimeStamp, Is.EqualTo(DateTime.Now.ToString("HH':'mm':'ss")));
        }

        [Test]
        public void IsCalled_UnlockDoorLocked()
        {
            _uut.LogDoorUnlocked(5678);
            Assert.That(_uutDtoLogData.Id, Is.EqualTo(5678));
            Assert.That(_uutDtoLogData.Description, Is.EqualTo("Door is unlocked"));
            Assert.That(_uutDtoLogData.Locked, Is.EqualTo(false));
            Assert.That(_uutDtoLogData.TimeStamp, Is.EqualTo(DateTime.Now.ToString("HH':'mm':'ss")));
        }

    }
}
