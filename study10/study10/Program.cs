using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace study10
{
    class Program
    {
        static void Main(string[] args)
        {
            //int day = 6;
            //switch(day)
            //{
            //    case 1:
            //        Console.WriteLine("월요일");
            //        break;
            //    case 2:
            //        Console.WriteLine("화요일");
            //        break;
            //    case 3:
            //        Console.WriteLine("수요일");
            //        break;
            //    case 4:
            //        Console.WriteLine("목요일");
            //        break;
            //    case 5:
            //        Console.WriteLine("금요일");
            //        break;
            //    case 6:
            //    case 7:
            //        Console.WriteLine("주말입니다.");
            //        break;
            //    default:
            //        Console.WriteLine("유효하지 않은 요일입니다.");
            //        break;
            //}

            // 캐릭터를 선택하세요 (1. 검사 2. 마법사 3. 도적)
            //Console.WriteLine("캐릭터를 선택하세요 (1. 검사 2. 마법사 3. 도적)");
            //int character = int.Parse(Console.ReadLine());
            //string job = "검사";
            //int att = 0;
            //int def = 0;

            //switch(character)
            //{
            //    case 1:
            //        job = "검사";
            //        att = 100;
            //        def = 90;
            //        break;
            //    case 2:
            //        job = "마법사";
            //        att = 110;
            //        def = 80;
            //        break;
            //    case 3:
            //        job = "도적";
            //        att = 115;
            //        def = 70;
            //        break;
            //    default:
            //        Console.WriteLine("유효한 직업이 아닙니다.");
            //        break;
            //}

            //Console.WriteLine($"{job} 공격력은 {att}, 방어력은 {def}입니다.");

            //int sum = 0;
            //for (int i=1; i<=10; i++)
            //{
            //    sum += i;
            //    //Console.WriteLine($"숫자: {i}");
            //}
            //Console.WriteLine($"합: {sum}");

            //int c = 1;
            //while (true) {
            //    if (c > 5)
            //    {
            //        break;
            //    }

            //    Console.WriteLine($"count: {c}");
            //    c++;
            //}

            // 랜덤
            //Random rand = new Random();
            //for (int i = 0; i<10; i++)
            //{
            //    //int randomNumber = rand.Next(0, 10); // 0~9
            //    double randomNumber = rand.NextDouble();
            //    Console.WriteLine($"랜덤수 : {randomNumber}");
            //}

            // 대장장이 키우기
            // 도끼등급 sss     10%
            // 도끼등급 ss      30%
            // 도끼등급 s       60%
            //Console.WriteLine("=== 대장장이 키우기 - 도끼 뽑기 ===");
            //Random rand = new Random();
            //int prob = 0;

            //for(int i=0; i<20; i++)
            //{
            //    prob = rand.Next(1, 101); // 1~100

            //    if (prob <= 10)
            //    {
            //        Console.WriteLine("도끼등급 sss");
            //    }
            //    else if (prob <= 40)
            //    {
            //        Console.WriteLine("도끼등급 ss");
            //    }
            //    else
            //    {
            //        Console.WriteLine("도끼등급 s");
            //    }

            //    Thread.Sleep(500); // 0.5초
            //}
            
            // continue
            for(int i=1; i<=10; i++)
            {
                if (i % 2 == 0)
                {
                    continue;
                }
                Console.WriteLine(i);
            }
        }
    }
}
