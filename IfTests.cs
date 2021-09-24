using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Task_If.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void PassengerWithTrain() 
        {
            Time TrainArrive = new Time(14, 50);
            Time TrainLeave = new Time(16, 30);
            Time Passenger = new Time(15, 30);

            Assert.IsTrue(Program.IsTrainStand(TrainArrive, TrainLeave, Passenger, true));
        }
        [TestMethod()]
        public void PassengerAfterTrain()
        {
            Time TrainArrive = new Time(17, 40);
            Time TrainLeave = new Time(18, 30);
            Time Passenger = new Time(21, 30);

            Assert.IsFalse(Program.IsTrainStand(TrainArrive, TrainLeave, Passenger, true));
        }
        [TestMethod()]
        public void PassengerBeforeTrain()
        {
            Time TrainArrive = new Time(6, 30);
            Time TrainLeave = new Time(7, 55);
            Time Passenger = new Time(3, 27);

            Assert.IsFalse(Program.IsTrainStand(TrainArrive, TrainLeave, Passenger, true));
        }
        [TestMethod()]
        public void IncorrectData()
        {
            Assert.ThrowsException<ArgumentException>(() => 
            {
                Time TrainArrive = new Time(6, 60);
                Time TrainLeave = new Time(25, -55);
                Time Passenger = new Time(113, -27);
            });
        }
        [TestMethod()]
        public void TrainLeaveNextDay()
        {
            Time TrainArrive = new Time(15, 30);
            Time TrainLeave = new Time(7, 30);

            Time Passenger1 = new Time(3, 0);
            Time Passenger2 = new Time(16, 30);

            Assert.IsTrue(Program.IsTrainStand(TrainArrive, TrainLeave, Passenger1, true));  //Пассажир пришел в день отправления поезда
            Assert.IsFalse(Program.IsTrainStand(TrainArrive, TrainLeave, Passenger2, true)); //Пассажир пришел в день отправления поезда
            
            Assert.IsFalse(Program.IsTrainStand(TrainArrive, TrainLeave, Passenger1, false)); //Пассажир пришел в день прибытия поезда
            Assert.IsTrue(Program.IsTrainStand(TrainArrive, TrainLeave, Passenger2, false)); //Пассажир пришел в день прибытия поезда
        }
    }
}