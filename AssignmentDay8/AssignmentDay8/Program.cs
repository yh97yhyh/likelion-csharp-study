using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDay8
{
    class Warrior
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int Strength { get; set; }

        public Warrior()
        {
            Name = "";
            Score = 0;
            Strength = 0;
        }

        public Warrior(string name, int score, int strength)
        {
            Name = name;
            Score = score;
            Strength = strength;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 과제 1
            var warrior = new Warrior("홍길동", 80, 96);
            Console.WriteLine("Name\tScore\tStrength");
            Console.WriteLine($"{warrior.Name}\t{warrior.Score}\t{warrior.Strength}");

            // 과제 2
            Console.Write("숫자를 입력하세요: ");
            try
            {
                var input = Console.ReadLine();
                var num = int.Parse(input);
                Console.WriteLine($"{num}을 입력했습니다.");
            }
            catch (FormatException)
            {
                Console.WriteLine("올바른 숫자를 입력하세요.");
            }

            // 과제3
            var fruits = new List<string>();
            fruits.Add("사과");
            fruits.Add("바나나");
            fruits.Add("포도");

            foreach (var fruit in fruits)
            {
                Console.Write(fruit + " ");
            }
            Console.WriteLine();

            var queue = new Queue<string>();
            queue.Enqueue("첫번째작업");
            queue.Enqueue("두번째작업");
            queue.Enqueue("세번째작업");

            while (queue.Count > 0)
            {
                Console.Write(queue.Dequeue() + " ");
            }
            Console.WriteLine();

            var stack = new Stack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }
            Console.WriteLine();

            // 과제4
            Console.Write("문장을 입력하세요: ");
            var input2 = Console.ReadLine();

            var upperInput = input2.ToUpper();
            Console.WriteLine(upperInput);

            var replacedInput = input2.Replace("C#", "CSharp");
            Console.WriteLine(replacedInput);

            Console.WriteLine(input2.Length);

            // 과제5
            var nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var evenNums = nums.Where( n => n % 2 == 0 );
            foreach(var n in evenNums)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();

            var sum = nums.Sum();
            Console.WriteLine(sum);
        }
    }
}
