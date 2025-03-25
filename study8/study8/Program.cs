using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace study8
{
    class Program
    {
        static void Main(string[] args)
        {
            //int score = 65;

            //if (score >= 90)
            //{
            //    Console.WriteLine("A 학점");
            //}
            //else if (score >= 80)
            //{
            //    Console.WriteLine("B학점");
            //}
            //else if (score >= 70)
            //{
            //    Console.WriteLine("C학점");
            //}
            //else
            //{
            //    Console.WriteLine("F학점");
            //}


            Console.WriteLine("가지고 있는 소지금을 입력하세요.");
            int money = Convert.ToInt32(Console.ReadLine());
            int extraAtt = 0;

            if (money >= 601)
            {
                Console.WriteLine("전설의검을 구매했습니다.");
                extraAtt += 7;
            }
            else if (money >= 501)
            {
                Console.WriteLine("유령검을 구매했습니다.");
                extraAtt += 6;
            }
            else if (money >= 401)
            {
                Console.WriteLine("엑스칼리버를 구매했습니다.");
                extraAtt += 5;
            }
            else if (money >= 301)
            {
                Console.WriteLine("집판검을 구매했습니다.");
                extraAtt += 4;
            }
            else if (money >= 201)
            {
                Console.WriteLine("진은검을 구매했습니다.");
                extraAtt += 3;
            }
            else if (money >= 101)
            {
                Console.WriteLine("카타나를 구매했습니다.");
                extraAtt += 2;
            }
            else 
            {
                Console.WriteLine("무한의대검을 구매했습니다.");
                extraAtt += 1;
            }

            Console.WriteLine();

            Console.WriteLine("캐릭터 이름을 입력하세요.");
            string name = Console.ReadLine();
            Console.WriteLine($"{name}의 공격력 : {100 + extraAtt}");
        }
    }
}
