using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Task_For.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void IncorrectData()
        {
            Assert.ThrowsException<ArgumentException>(() => new Rectangle(-5, 6));
        }
        [TestMethod()]
        public void MinRectAreaIsNegative()
        {
            Assert.ThrowsException<FieldAccessException>(() => Program.MinRectArea = -5);            
        }
        [TestMethod()]
        public void RectangleHasIntegerSides()
        {
            Rectangle rect = new Rectangle(91, 47);
            int SquareCount = Program.CutRectangle(rect);
            Assert.AreEqual(SquareCount, 19);
        }
        [TestMethod()]
        public void RectangleHasFloatSides()
        {
            Program.MinRectArea = 0.7f;
            Rectangle rect = new Rectangle(34.7423f, 17.3908f);
            int SquareCount = Program.CutRectangle(rect);
            Assert.AreEqual(SquareCount, 2);
        }
    }
}