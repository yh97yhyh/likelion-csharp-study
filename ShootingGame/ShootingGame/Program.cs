using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShootingGame
{

    struct Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string[] Shape { get; set; }

        public Player(int x, int y)
        {
            X = x;
            Y = y;
            Shape = new string[] { "->", ">>>", "->" };
        }

        public void HandleKeyInfo(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow: if (Y > 0) Y--; break;
                case ConsoleKey.DownArrow: if (Y < Console.WindowHeight - Shape.Length) Y++; break;
                case ConsoleKey.LeftArrow: if (X > 0) X--; break;
                case ConsoleKey.RightArrow: if (X < Console.WindowWidth - 3) X++; break;
                case ConsoleKey.Spacebar: Console.SetCursorPosition(X + 3, Y + 1);  Console.Write("🔹"); break;
            }
        }

        public void Draw()
        {
            for (int i = 0; i < Shape.Length; i++)
            {
                Console.SetCursorPosition(X, Y + i);
                Console.WriteLine(Shape[i]);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);
            Console.CursorVisible = false;
            var keyInfo = new ConsoleKeyInfo();

            var player = new Player(0, 12);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            long prevSecond = stopwatch.ElapsedMilliseconds;

            while (true)
            {
                long currentSecond = stopwatch.ElapsedMilliseconds;
                
                if(currentSecond - prevSecond >= 100)
                {
                    keyInfo = Console.ReadKey(true); 
                    Console.Clear();

                    player.HandleKeyInfo(keyInfo);
                    player.Draw();

                    prevSecond = currentSecond;
                }

            }

        }
    }
}
