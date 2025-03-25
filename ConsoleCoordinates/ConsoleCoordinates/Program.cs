using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleCoordinates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25); // 콘솔 창 크기 설정
            Console.SetBufferSize(80, 25); // 콘솔 버퍼 크기도 설정 (스크롤 없이 고정된 창 유지)
            //Console.Title = "멋사 콘솔 게임 만들기";
            //Console.BackgroundColor = ConsoleColor.Yellow;
            Console.CursorVisible = false;
            Console.Clear();

            Console.SetCursorPosition(0, 0);
            Console.Write("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            for (int j=1; j<=24; j++)
            {
                if (j == 12)
                {
                    Console.SetCursorPosition(0, j);
                    Console.Write("┃                                   타겟 맞추기                                ┃");
                    continue;
                }
                Console.SetCursorPosition(0, j);
                Console.Write("┃                                                                              ┃");
            }
            Console.Write("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");

            Thread.Sleep(3000);
            Console.Clear();

            Random rand = new Random();

            Console.WriteLine("wsad로 이동하여 타겟(★)을 맞춰주세요!");
            Console.WriteLine("장애물(x)을 건너 이동할 수 없습니다.");
            Thread.Sleep(2000);

            int round = 1;
            int score = 0;
            string player = "◎";
            string target = "★";
            string barrier = "x";
            int playerX = 0, playerY = 0;
            int targetX = 0, targetY = 0;
            List<(int, int)> barriers = new List<(int, int)>();
            bool isGameRunning = true;

            while (isGameRunning)
            {
                int barrierX = rand.Next(0, 80);
                int barrierY = rand.Next(1, 25);
                barriers.Add((barrierX, barrierY));
                playerX = rand.Next(0, 80);
                playerY = rand.Next(0, 25);
                targetX = rand.Next(0, 80);
                targetY = rand.Next(0, 25);

                Console.Clear();

                Console.SetCursorPosition(0, 0);
                Console.Write($"{round}단계 | 점수 {score}");

                Console.SetCursorPosition(playerX, playerY);
                Console.Write(player);

                Console.SetCursorPosition(targetX, targetY);
                Console.Write(target);

                foreach (var b in barriers)
                {
                    Console.SetCursorPosition(b.Item1, b.Item2);
                    Console.Write(barrier);
                }

                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    int newX = playerX;
                    int newY = playerY;

                    switch (key.Key)
                    {
                        case ConsoleKey.W:
                            if (playerY > 1)
                            {
                                newY--;
                            }
                            break;
                        case ConsoleKey.S:
                            if (playerY < 24)
                            {
                                newY++;
                            }
                            break;
                        case ConsoleKey.A:
                            if (playerX > 1)
                            {
                                newX--;
                            }
                            break;
                        case ConsoleKey.D:
                            if (playerX < 79)
                            {
                                newX++;
                            }
                            break;
                    }

                    if (!barriers.Contains((newX, newY))) // 장애물 확인!
                    {
                        playerX = newX;
                        playerY = newY;
                    }

                    Console.Clear();

                    Console.SetCursorPosition(0, 0);
                    Console.Write($"{round}단계 | 점수 {score}");

                    Console.SetCursorPosition(playerX, playerY);
                    Console.Write(player);

                    Console.SetCursorPosition(targetX, targetY);
                    Console.Write(target);

                    foreach (var b in barriers)
                    {
                        Console.SetCursorPosition(b.Item1, b.Item2);
                        Console.Write(barrier);
                    }

                    if (playerX == targetX && playerY == targetY)
                    {
                        score += 1;
                        break;
                    }
                }

                round++;
            }

        }
    }
}
