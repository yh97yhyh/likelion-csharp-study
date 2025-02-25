using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace game1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 대장장이키우기

            Random rand = new Random();

            Console.WriteLine("=== 대장장이 키우기 ===");

            int pmoney = 100;
            int input = 0;
            int rnd = 0;

            Thread.Sleep(500);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. 나무캐기");
                Console.WriteLine("2. 장비뽑기");
                Console.WriteLine("3. 나가기");
                Console.Write("입력 : ");
                input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        while (true)
                        {
                            Console.WriteLine("나무캐기(엔터)");
                            Console.WriteLine("뒤로가기 x");

                            string str = Console.ReadLine();

                            if (str == "x")
                            {
                                Console.WriteLine("뒤로가기");
                                break;
                            }
                            else
                            {
                                pmoney += 100;
                                Console.WriteLine($"소지금: {pmoney}");
                            }
                        }
                        break;
                    case 2:
                        if (pmoney >= 1000)
                        {
                            pmoney -= 1000;
                            Console.WriteLine($"1000포인트를 사용합니다. 남은 소지금: {pmoney}");
                            Console.WriteLine($"20번 뽑기를 시작합니다.");

                            // 20번 뽑기
                            for (int i = 0; i < 20; i++)
                            {
                                rnd = rand.Next(1, 101);

                                if (rnd <= 1)
                                {
                                    Console.WriteLine("도끼등급 sss");
                                }
                                else if (rnd >= 2 && rnd <= 6)
                                {
                                    Console.WriteLine("도끼등급 ss");
                                }
                                else if (rnd >= 7 && rnd <= 17)
                                {
                                    Console.WriteLine("도끼등급 s");
                                }
                                else if (rnd >= 18 && rnd <= 38)
                                {
                                    Console.WriteLine("도끼등급 a");
                                }
                                else if (rnd >= 39 && rnd <= 69)
                                {
                                    Console.WriteLine("도끼등급 b");
                                }
                                else
                                {
                                    Console.WriteLine("도끼등급 c");
                                }

                                Thread.Sleep(500);
                            }
                        }
                        else
                        {
                            Console.WriteLine("돈이 부족합니다. \n");
                            Thread.Sleep(1000);
                        }
                        break;
                    case 3:
                        Console.WriteLine("나갑니다.");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }
    }
}
