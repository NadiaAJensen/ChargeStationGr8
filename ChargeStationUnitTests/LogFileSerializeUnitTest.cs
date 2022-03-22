using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargeStationClassLibrary.LogFile;
using NUnit.Framework;

namespace ChargeStationUnitTests
{
    public class LogFileSerializeUnitTest
    {
        private LogFileSerialize _uut;
        private DTO_LogData _uutDtoLogData;
        

        [SetUp]
        public void Setup()
        {
            _uut = new LogFileSerialize();
            _uutDtoLogData = new DTO_LogData();

        }

        public void IsSaved()
        {
            //_uut.Save(_uutDtoLogData);
            //Assert.That(_uut.Save(_uutDtoLogData), );
        }
    }
}
