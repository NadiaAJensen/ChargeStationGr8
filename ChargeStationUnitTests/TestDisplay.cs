using System;
using System.IO;
using ChargeStationClassLibrary.Display;
using NUnit.Framework;

namespace ChargeStationUnitTests
{
    public class Tests
    {
        private IDisplay _uut;
        [SetUp]
        public void Setup()
        {
            _uut = new Display();
        }

        [TestCase("TestString1")]
        [TestCase("TestString2")]
        [TestCase("TestString3")]
        public void StringIsPrintetCorrectly(string text)
        {
            var stringwriter = new StringWriter();
            Console.SetOut(stringwriter);

            _uut.PrintString(text);
            Assert.AreEqual(text+ "\r\n", stringwriter.ToString());
            Assert.Pass();
        }
    }
}