using System;

namespace Task_For
{
   public class Rectangle
    {
        public float Width { get; private set; }
        public float Height { get; private set; }
        public float MinSide { get { return Width < Height ? Width : Height; } }
        public float Area { get { return Width * Height; } }
        public Rectangle(float width, float height)
        {
           if(width <= 0 || height <= 0)
           {
                throw new ArgumentException("Введены неверные данные (Фигура с отрицательной стороной)");
           }

           Width = width;
           Height = height;   
        }

        public static Rectangle operator -(Rectangle rect, Square square)
        {
            if(rect.Width > rect.Height)
            {
                rect.Width -= square.Width;
            }
            else
            {
                rect.Height -= square.Height;
            }
            return rect;
        }
    };
    public class Square : Rectangle
    {
        public Square(float side) : base(side, side){}
    }

    public class Program
    {
        private static float _MinReactArea = 1;
        public static float MinRectArea 
        { 
            get { return _MinReactArea; } 
            set 
            {
                if (value < 0)
                {
                    throw new FieldAccessException("MinReactArea не может быть отрицательным числом");
                }
                _MinReactArea = value;
            } 
        }
        public static int CutRectangle(Rectangle rect)
        {
            Console.WriteLine($"Исходный прямоугольник: {rect.Width}x{rect.Height}");

            int SquareCount = 0;
            while(rect.Area >= MinRectArea)
            {
                Console.WriteLine($"Квадрат: {rect.MinSide}x{rect.MinSide}");
                rect -= new Square(rect.MinSide);
                SquareCount++;
            }

            return SquareCount;
        }

        static void Main()
        {
            try
            {
                Console.Write("Минимальная допустимая площадь прямоугольника: ");
                MinRectArea = float.Parse(Console.ReadLine());

                Console.Write("Ширина прямоугольника: ");
                float Width = float.Parse(Console.ReadLine());

                Console.Write("Высота прямоугольника: ");
                float Height = float.Parse(Console.ReadLine());

                Rectangle rect = new Rectangle(Width, Height);
                int SquareCount = CutRectangle(rect);
                Console.WriteLine($"Количество нарезанных квадратов: {SquareCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
