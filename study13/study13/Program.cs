using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study13
{
    class Program
    {
        static void Main(string[] args)
        {
            //var i1 = 3;
            //var i2 = 5;
            //var d1 = 4.5;
            //var d2 = 7.2;
            //Console.WriteLine($"함수 오버로딩 {i1} x {i2} = {Multiply(i1, i2)}");
            //Console.WriteLine($"함수 오버로딩 {d1} x {d2} = {Multiply(d1, d2):F2}");

            //int q, r;
            //Divide(10, 3, out q, out r);
            //Console.WriteLine($" 몫: {q}, 나머지 : {r}");

            //int value = 5;
            //Increase(ref value);
            //Console.WriteLine(value);

            //Console.WriteLine(Sum(1, 2, 3));
            //Console.WriteLine(Sum(1, 2));

            Console.WriteLine(Factorial(5));

        }

        // 함수 오버로딩
        static int Multiply(int a, int b)
        {
            return a * b;
        }
        static double Multiply(double a, double b)
        {
            return a * b;
        }

        // out 키워드 (여러 값을 반환할 때 사용)
        static void Divide(int a, int b, out int quotient, out int remainder)
        {
            quotient = a / b;
            remainder = a % b;
        }

        // ref 키워드
        static void Increase(ref int num)
        {
            num += 10;
        }

        // params 키워드 (가변 개수의 매개변수)
        static int Sum(params int[] nums)
        {
            int total = 0;
            foreach(int num in nums)
            {
                total += num;
            }

            return total;
        }

        // 재귀함수
        static int Factorial(int n)
        {
            Console.WriteLine($"Factorial({n}) 호출!");

            if (n <= 1)
            {
                Console.WriteLine($"Factorial({n}) = 1 반환!");
                return 1;
            }
            else
            {
                int result = n * Factorial(n - 1);
                Console.WriteLine($"Factorial({n}) = {result} 반환!");
                return result;
            }
        }

    }
}
