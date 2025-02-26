using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BingoGame2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            for (int i = 0; i < 4; i++)
            {
                Console.Write("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                for (int j = 1; j <= 10; j++)
                {
                    var emoji = (i % 2 == 0) ? "💙" : "💛";
                    if (j == 5)
                    {
                        Console.SetCursorPosition(0, j);
                        Console.Write($"┃                               {emoji}   Bingo Game   {emoji}                           ┃");
                        continue;
                    }
                    Console.SetCursorPosition(0, j);
                    Console.Write("┃                                                                              ┃");
                }
                Console.Write("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                Thread.Sleep(500);
                Console.Clear();
            }

            Random rand = new Random();
            var isPlaying = true;
            var bingo = 0;

            bool[] rowChecked = new bool[5];
            bool[] columnChecked = new bool[5];
            bool rightDiagonalChecked = false;
            bool leftDiagonalChecked = false;

            int[,] nums = new int[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    nums[i, j] = i * 5 + j + 1;
                }
            }

            // 빙고판 출력
            PrintBingo(nums);
            Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine("카드를 섞는 중입니다... ⏳");

            // 셔플
            for (int i = 0; i < 100; i++)
            {
                int iA = rand.Next(0, 5);
                int jA = rand.Next(0, 5);
                int iB = rand.Next(0, 5);
                int jB = rand.Next(0, 5);

                // swap
                int temp = nums[iA, jA];
                nums[iA, jA] = nums[iB, jB];
                nums[iB, jB] = temp;

                PrintBingo(nums);
                Thread.Sleep(5);
            }

            Console.Clear();

            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"현재 빙고 : {bingo}");
                PrintBingo(nums);

                Console.Write("\n숫자를 입력하세요 (1 ~ 25): ");
                var input = int.Parse(Console.ReadLine());

                // 선택한 숫자를 0으로 변경
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (nums[i, j] == input)
                        {
                            nums[i, j] = 0;
                            break;
                        }
                    }
                }

                PrintBingo(nums);

                // 가로 체크
                for (int i = 0; i < 5; i++)
                {
                    if (!rowChecked[i] && CheckRowBingo(nums, i))
                    {
                        bingo++;
                        rowChecked[i] = true;
                    }
                }

                // 세로 체크
                for (int i = 0; i < 5; i++)
                {
                    if (!columnChecked[i] && CheckColumnBingo(nums, i))
                    {
                        bingo++;
                        columnChecked[i] = true;
                    }
                }

                // 대각선 체크
                if (!rightDiagonalChecked && CheckRightDiagonalBingo(nums))
                {
                    bingo++;
                    rightDiagonalChecked = true;
                }

                if (!leftDiagonalChecked && CheckLeftDiagonalBingo(nums))
                {
                    bingo++;
                    leftDiagonalChecked = true;
                }

                if (bingo >= 12)
                {
                    Console.Clear();
                    Console.WriteLine("모든 빙고를 달성했습니다! 💫");
                    PrintCompleteBingo();
                    Environment.Exit(0);
                }
            }
        }

        static void PrintBingo(int[,] array)
        {
            Console.SetCursorPosition(0, 1);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (array[i, j] == 0)
                    {
                        Console.Write("🌟 "); // 0일 경우 체크
                    }
                    else
                    {
                        Console.Write($"{array[i, j].ToString("D2")} ");
                    }
                }
                Console.WriteLine();
            }
        }

        static void PrintCompleteBingo()
        {
            Console.SetCursorPosition(0, 1);

            var cnt = 0;
            while (true)
            {
                if (cnt >= 25)
                {
                    break;
                }

                Console.SetCursorPosition(0, 1);

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (i * 5 + j <= cnt)
                        {
                            Console.Write("❤🔥 ");
                        }
                        else
                        {
                            Console.Write("🌟 ");
                        }
                    }
                    Console.WriteLine();
                }

                Thread.Sleep(10);
                cnt++;
            }
        }

        static bool CheckRowBingo(int[,] array, int row) // 가로 체크
        {
            for (int j = 0; j < 5; j++)
            {
                if (array[row, j] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        static bool CheckColumnBingo(int[,] array, int column) // 세로 체크
        {
            for (int j = 0; j < 5; j++)
            {
                if (array[j, column] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        static bool CheckRightDiagonalBingo(int[,] array)
        {
            for (int i = 0; i < 5; i++)
            {
                if (array[i, 4 - i] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        static bool CheckLeftDiagonalBingo(int[,] array)
        {
            for (int i = 0; i < 5; i++)
            {
                if (array[i, i] != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}