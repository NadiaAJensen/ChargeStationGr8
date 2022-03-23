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
        public void TestofSerializationAndDeserialization()
        {
            string path = @"..\..\logFile.json";

            // logger noget i filen
            _uutDtoLogData.Id = 1234;
            _uutDtoLogData.Locked = true;
            _uutDtoLogData.Description = "Door is locked";
            _uutDtoLogData.TimeStamp = DateTime.Now.ToString("HH':'mm':'ss");


            _uut.Save(_uutDtoLogData);
            DTO_LogData testData = _uut.Load(path);
            string data = Convert.ToString(testData);
            Assert.That(data, Is.EqualTo(_uutDtoLogData.ToString()));

            Assert.AreEqual(data, _uutDtoLogData.ToString());

            
        }

    }
}
