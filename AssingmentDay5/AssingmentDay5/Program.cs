using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssingmentDay5
{
    class Program
    {
        static void Main(string[] args)
        {
            // 배열
            Console.WriteLine("========= 배열 =========");
            Console.WriteLine(" - 문제1");
            int[] nums = { 10, 20, 30, 40, 50 };
            PinrtIntArray(nums);

            Console.WriteLine("\n - 문제2");
            Console.Write("숫자 5개를 공백으로 구분해 입력해 주세요: ");
            string input = Console.ReadLine();
            int[] nums2 = StringToIntArray(input);
            Console.WriteLine($"배열의 합은 {MySum(nums2)} 입니다.");

            Console.WriteLine("\n - 문제3");
            int[] nums3 = { 3, 8, 15, 6, 2 };
            Console.WriteLine($"배열 요소의 최댓값은 {MyMax(nums3)} 입니다.");


            Console.WriteLine("\n\n========= 반복문 =========");
            Console.WriteLine(" - 문제4");
            for(int i=1; i<=10; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            Console.WriteLine("\n - 문제5");
            var cnt = 1;
            while (true)
            {
                if (cnt > 10)
                {
                    break;
                }

                if (cnt % 2 == 0)
                {
                    Console.Write($"{cnt} ");
                }

                cnt++;
            }
            Console.WriteLine();

            Console.WriteLine("\n - 문제6");
            int[] nums4 = { 1, 2, 3, 4, 5 };
            foreach(var num in nums4)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();


            Console.WriteLine("\n\n========= 함수 =========");
            Console.WriteLine("- 문제7");
            Console.Write("숫자 2개를 공백으로 구분해 입력해 주세요: ");
            string input2 = Console.ReadLine();
            var nums5 = StringToIntArray(input2);
            var n1 = nums5[0];
            var n2 = nums5[1];
            Console.WriteLine($"{n1}과 {n2}의 합 : {MySum(n1, n2)}");

            Console.WriteLine("\n - 문제8");
            Console.Write("문자열을 입력해 주세요: ");
            string input3 = Console.ReadLine();
            Console.WriteLine($"문자열의 길이 : {MyArrayLength(input3)}");

            Console.WriteLine("\n - 문제9");
            Console.Write("숫자 3개를 공백으로 구분해 입력해 주세요: ");
            string input4 = Console.ReadLine();
            var nums6 = StringToIntArray(input4);
            var n3 = nums6[0];
            var n4 = nums6[1];
            var n5 = nums6[2];
            Console.WriteLine($"가장 큰 수 : {MyMax(n3, n4, n5)}");
        }

        static void PinrtIntArray(int[] arr)
        {
            foreach(var num in arr)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }

        static int[] StringToIntArray(string str)
        {
            int[] nums = str.Split(' ')
                .Select(int.Parse)
                .ToArray();

            return nums;
        }

        static int MySum(int[] arr)
        {
            var sum = 0;
            foreach (var num in arr)
            {
                sum += num;
            }
            return sum;
        }

        static int MyMax(int[] arr)
        {
            var curMax = arr[0];

            foreach (var num in arr)
            {
                if (num > curMax)
                {
                    curMax = num;
                }
            }

            return curMax;
        }

        static int MySum(int n1, int n2)
        {
            return n1 + n2;
        }

        static int MyArrayLength(string str)
        {
            var len = 0;
            foreach(char c in str)
            {
                len++;
            }
            return len;
        }

        static int MyMax(int n1, int n2, int n3)
        {
            var curMax = n1;

            if (n2 > curMax)
            {
                curMax = n2;
            }

            if (n3 > curMax)
            {
                curMax = n3;
            }

            return curMax;
        }
    }
}
