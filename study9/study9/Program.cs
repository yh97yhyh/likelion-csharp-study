using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== 문제1 =====");
            Console.WriteLine("정수 세 개를 입력해 주세요.");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());
            int max = 0;

            if (a > b && a > c)
            {
                max = a;
            }
            else if (b > c && b > a)
            {
                max = b;
            }
            else if (c > a && c > b)
            {
                max = c;
            }

            if (max == 0)
            {
                Console.WriteLine("최댓값은 없습니다.");
            }
            else
            {
                Console.WriteLine($"최댓값은 {max}입니다.");
            }


            Console.WriteLine("\n===== 문제2 =====");
            Console.WriteLine("점수를 입력해 주세요.");
            int score = Convert.ToInt32(Console.ReadLine());

            if (score >= 90)
            {
                Console.WriteLine("A학점입니다.");
            }
            else if (score >= 80)
            {
                Console.WriteLine("B학점입니다.");
            }
            else if (score >= 70)
            {
                Console.WriteLine("C학점입니다.");
            }
            else if (score >= 60)
            {
                Console.WriteLine("D학점입니다.");
            }
            else
            {
                Console.WriteLine("F학점입니다.");
            }

            Console.WriteLine("\n===== 문제3 =====");
            Console.WriteLine("두 개의 숫자를 입력해 주세요.");
            double num1 = Convert.ToDouble(Console.ReadLine());
            double num2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("연산자를 입력해 주세요.");
            string s = Console.ReadLine();
            double result = 0;
            bool isValid = true;

            if (c.Equals("+"))
            {
                result = num1 + num2;
            }
            else if (c.Equals("-"))
            {
                result = num1 - num2;
            }
            else if (c.Equals("*"))
            {
                result = num1 * num2;
            }
            else if (s.Equals("/"))
            {
                if (num2 == 0)
                {
                    Console.WriteLine("0으로 나누기는 불가능합니다.");
                    isValid = false;
                }
                else
                {
                    result = num1 / num2;
                }
            }

            if (isValid)
            {
                Console.WriteLine($"결과: {result}");
            }
        }
    }
}
