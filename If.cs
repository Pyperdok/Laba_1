using System;

namespace Task_If
{
    public class Time
    {
       public int Hours { get; private set; }
       public int Minutes { get; private set; }

       public Time(int hours, int minutes)
       {
            if (hours < 0 || hours > 23 || minutes < 0 || minutes > 59) 
            { 
                throw new ArgumentException("Введены неверные данные");             
            }

            Hours = hours;
            Minutes = minutes;           
       }

       public static bool operator <(Time a, Time b)
       {
            bool Status = false;
            if (a.Hours < b.Hours)
            {
                Status = true;
            }
            else if (a.Hours == b.Hours && a.Minutes < b.Minutes)
            {
                Status = true;
            }
            return Status;
       }

       public static bool operator >(Time a, Time b)
       {
            bool Status = false;
            if (a.Hours > b.Hours)
            {
                Status = true;
            }
            else if (a.Hours == b.Hours && a.Minutes > b.Minutes)
            {
                Status = true;
            }
            return Status;
       }
    };

   public class Program
   {
        public static bool IsTrainStand(Time TrainArrive, Time TrainLeave, Time Passenger, bool IsLeaveDay)
        {
            bool CrossDay = TrainLeave < TrainArrive;
            bool Result = false;
            if (TrainArrive < Passenger && Passenger < TrainLeave) //Обычный целый день
            {
                Result = true;
            }
            else if(TrainArrive < Passenger && Passenger > TrainLeave && !IsLeaveDay && CrossDay) //Пассажир пришел в день прибытия
            {
                Result = true;
            }
            else if (TrainArrive > Passenger && Passenger < TrainLeave && IsLeaveDay && CrossDay) //Пассажир пришел в день отправления
            {
                Result = true;
            }
            return Result;
        }
        public static Time Fill(string Message)
        {
            Console.Write($"{Message} (hh:mm): ");
            string[] time;
            time = Console.ReadLine().Split(':');
            return new Time(int.Parse(time[0]), int.Parse(time[1]));
        }
        static void Main()
        {
            try
            {
                Time TrainArrive = Fill("Время прибытия поезда");
                Time TrainLeave = Fill("Время отправления поезда");
                Time Passenger = Fill("Время прихода пассажира");

                bool IsLeaveDay = false;
                if (TrainLeave < TrainArrive)
                {
                    Console.Write("Пассажир пришел в день отправления поезда? [True/False]: ");
                    IsLeaveDay = bool.Parse(Console.ReadLine());
                }

                if (IsTrainStand(TrainArrive, TrainLeave, Passenger, IsLeaveDay))
                {
                    Console.WriteLine("Поезд стоит на платформе");
                }
                else
                {
                    Console.WriteLine("Поезд НЕ стоит на платформе");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            Console.ReadLine();
        }
   }
}
