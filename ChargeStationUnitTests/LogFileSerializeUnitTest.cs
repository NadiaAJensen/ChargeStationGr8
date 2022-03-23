using System;
using System.Collections.Generic;
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
            
            //tjekker om fil eksisterer
            // logger noget i filen
            string testDescription = "test";
            int testId = 5678;
            bool locked = true;

            _uut.Save(_uutDtoLogData);
            //laver en streamreader
            //læser det ind som text og tjekker om det er det samme som er logget
        }

    }
}
