using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study16
{
    class Program
    {
        // 구조체
        //struct Point
        //{
        //    public int X;
        //    public int Y;

        //    public Point(int x, int y)
        //    {
        //        X = x;
        //        Y = y;
        //    }

        //    public void Print()
        //    {
        //        Console.WriteLine($"Porint({X}, {Y})");
        //    }
        //}
        struct Rectangle
        {
            public int Width;
            public int Height;

            public int GetArea() => Width * Height;
        }

        // 클래스
        class Point
        {
            public int X;
            public int Y;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public void Print()
            {
                Console.WriteLine($"Point({X}, {Y})");
            }
        }

        static void Main(string[] args)
        {
            //var p1 = new Point(10, 20);
            //var p2 = p1;

            //p2.X = 50;
            //p1.Print();
            //p2.Print();

            var rect = new Rectangle();
            rect.Width = 10;
            rect.Height = 20;
            Console.WriteLine($"Rectangle Area : {rect.GetArea()}");
        }
    }
}
