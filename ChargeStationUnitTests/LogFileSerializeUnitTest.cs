using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargeStationClassLibrary.LogFile;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NSubstitute;
using NUnit.Framework;

namespace ChargeStationUnitTests
{
    public class LogFileSerializeUnitTest //skal denne klasse testes?
    {
        private LogFileSerialize _uut;
        private DTO_LogData _uutDtoLogData;



        [SetUp]
        public void Setup()
        {
            _uut = new LogFileSerialize();
            _uutDtoLogData = new DTO_LogData();
        }

        [Test]
        public void TestofDeserialization()
        {

        }
        [Test]
        public void TestofSerialization()
        {
            string path = @"..\..\logFile.json";
            //definerer fil

            // logger noget i filen
            _uutDtoLogData.Id = 1234;
            _uutDtoLogData.Locked = true;
            _uutDtoLogData.Description = "Door is locked";
            _uutDtoLogData.TimeStamp = DateTime.Now.ToString("HH':'mm':'ss");

            _uut.Save(_uutDtoLogData);
            _uut.Load(path);


            DTO_LogData testData = new DTO_LogData();
            if (testData == null) throw new ArgumentNullException(nameof(testData));
            testData = _uut.Load(path);
            Assert.That(testData, Is.EqualTo(_uutDtoLogData));

            //Assert.AreEqual(testdata, _uutDtoLogData);
            //string fildata = File.ReadAllText(path);
            //testdata  = JsonSerializer.

            





        }

    }
}
