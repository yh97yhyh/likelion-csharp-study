using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShootingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);
            Console.CursorVisible = false;

            var keyInfo = new ConsoleKeyInfo();
            //int x = 10, y = 10;
            int playerX = 0;
            int playerY = 12;
            var player = new string[]
            {
                "->",
                ">>>",
                "->"
            }; // 배열 문자열로 그리기

            var stopwatch = new Stopwatch(); // 루프 활용
            stopwatch.Start();

            long prevSecond = stopwatch.ElapsedMilliseconds;

            while (true)
            {

                long currentSecond = stopwatch.ElapsedMilliseconds;
                
                if(currentSecond - prevSecond >= 500)
                {
                    //Console.WriteLine("루프");
                    Console.Clear();

                    keyInfo = Console.ReadKey(true); // 키 입력 받기
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow: if (playerY > 0) playerY--; break;
                        case ConsoleKey.DownArrow: if (playerY < Console.WindowHeight - 3) playerY++; break;
                        case ConsoleKey.LeftArrow: if (playerX > 0) playerX--; break;
                        case ConsoleKey.RightArrow: if (playerX < Console.WindowWidth - 3) playerX++; break;
                        case ConsoleKey.Spacebar: Console.SetCursorPosition(playerX + 3, playerY + 1);  Console.Write("🔹"); break;
                        case ConsoleKey.Escape: return;
                    }

                    for (int i = 0; i < player.Length; i++) // 플레이어 그리기
                    {
                        Console.SetCursorPosition(playerX, playerY + i);
                        Console.WriteLine(player[i]);
                    }

                    prevSecond = currentSecond; // 이전 시간 업데이트
                }

            }

        }
    }
}
