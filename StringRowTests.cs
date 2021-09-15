using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Task_String.Tests
{
    [TestClass()]
    public class StringRowTests
    {
        [TestMethod()]
        public void IncorrectData()
        {
            Assert.ThrowsException<FormatException>(() => new StringRow("1-7+d-t289t-28r+427t6"));
        }
        [TestMethod()]
        public void CorrectData()
        {
            Assert.AreEqual(new StringRow("2+3+4+5+6+7+8+9").Sum, 44);
            Assert.AreEqual(new StringRow("2-3+4-5+6-7+8-9").Sum, -4);
            Assert.AreEqual(new StringRow("2-3-4-5-6-7-8-9").Sum, -40);
        }
        [TestMethod()]
        public void NumbersLessOrEqualOne()
        {
            Assert.ThrowsException<FormatException>(() => new StringRow("4+7+3+0-1+3+4-0"));
        }
    }
}