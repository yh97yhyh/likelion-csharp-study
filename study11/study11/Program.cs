using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace study11
{
    class Program
    {
        static void Main(string[] args)
        {
            // 배열
            //int[] nums = new int[3];

            //nums[0] = 10;
            //nums[1] = 20;
            //nums[2] = 30;

            //foreach (int num in nums)
            //{
            //    Console.WriteLine(num);
            //}

            //int[] numbers = { 1, 2, 3 };

            //string[] fruits = { "사과", "바나나", "오렌지" };
            //var fruits2 = new List<string> { "사과", "바나나", "오렌지" };
            //foreach (var fruit in fruits2)
            //{
            //    Console.WriteLine($"오늘의 과일은 {fruit}");
            //}

            //string[] subjects = { "국어", "영어", "수학" };
            //int[] scores = new int[3];

            //for (int i=0; i<subjects.Length; i++)
            //{
            //    Console.Write($"{subjects[i]} 점수를 입력해 주세요 : ");
            //    int input = int.Parse(Console.ReadLine());
            //    scores[i] = input;
            //}

            //Console.WriteLine($"총점 : {scores.Sum()} | 평균: {(int)scores.Average()}");

            //double value = 123.456789;
            //Console.WriteLine(value.ToString("F2"));
            //Console.WriteLine($"소수점 둘째자리 : {value:F2}");

            //int num1 = 123456789;
            //double num2 = 98765.4321;

            //Console.WriteLine(num1.ToString("N0"));  // 123,456,789
            //Console.WriteLine(num2.ToString("N2"));  // 98,765.43 (소수점 2자리까지)

            // 2차원 배열
            //int[,] arr = new int[3, 4];

            //int[,] arr2 =
            //    { { 1, 2, 3, 4 },
            //    { 5, 6, 7, 8 },
            //    { 9, 10, 11, 12 } };

            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 4; j++)
            //    {
            //        Console.Write($"{arr2[i, j]} ");
            //    }
            //    Console.WriteLine();
            //}

            // 가변배열
            //int[][] jaggedArr = new int[3][];

            //jaggedArr[0] = new int[] { 1, 2 };
            //jaggedArr[1] = new int[] { 3, 4, 5 };
            //jaggedArr[2] = new int[] { 6 };

            //for(int i=0; i<jaggedArr.Length; i++)
            //{
            //    for(int j=0; j < jaggedArr[i].Length; j++)
            //    {
            //        Console.Write($"{jaggedArr[i][j]} ");
            //    }
            //    Console.WriteLine();
            //}

        }

        static void Print2DArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++) // 행
            {
                for (int j = 0; j < array.GetLength(1); j++) // 열
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        static void PrintArray(int[] array)
        {
            foreach (var num in array)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }

        static void PrintStringArray(string[] array)
        {
            string result = string.Join(" ", array);
            Console.WriteLine(result);
        }
    }
}
