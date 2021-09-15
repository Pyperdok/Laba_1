using System;

namespace Task_String
{
    public class StringRow
    {
        private bool Sign = true;
        public int Sum { get; private set; }
        public StringRow(string row)
        {
            for (int i = 0; i < row.Length; i++)
            {
                if (i % 2 == 0)
                {
                    int value = int.Parse(row[i].ToString());
                    if (value <= 1) throw new FormatException("Неверный Формат строки"); // Условие: (n > 1) нарушено

                    if (Sign) {
                        Sum += value;
                    }
                    else
                    {
                        Sum -= value;
                    }
                }
                else
                {
                    switch(row[i])
                    {
                        case '+':
                            Sign = true;
                        break;
                        case '-':
                            Sign = false;
                        break;
                        default:
                            throw new FormatException("Неверный Формат строки");
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string input = Console.ReadLine();
                StringRow row = new StringRow(input);

                Console.WriteLine($"Сумма: {row.Sum}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
