using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study23
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lambda
            //var names = new List<string> { "Charlie", "Alice", "Bob" };
            //var sortedNames = names.OrderBy(n => n);

            //foreach (var name in sortedNames)
            //{
            //    Console.WriteLine(name);
            //}

            //var firstName = names.First(n => n.StartsWith("A"));

            //Console.WriteLine($"First name starting with A: {firstName}");

            //int[] nums = { 5, 3, 8, 1 };

            ////메서드구문
            //var sortedMeshod = nums.OrderByDescending(n => n);

            ////쿼리 구문
            //var sortedQuery = from n in nums
            //                  orderby n
            //                  select n;


            //Console.WriteLine("Meshod syntax:");
            //foreach (var n in sortedMeshod)
            //    Console.Write(n + " ");

            //Console.WriteLine();

            //Console.WriteLine("Query syntax:");
            //foreach (var n in sortedQuery)
            //{
            //    Console.Write(n + " ");
            //}

            // Near 알고리즘

            // Rank 알고리즘
            var nums = new List<int> { 95, 90, 90, 80, 75 };
            var ranked = Rank(nums);

            foreach(var num in nums)
            {
                Console.WriteLine($"score: {num}, rank: {ranked[num]}");
            }
            Console.WriteLine();

        }

        static int FindNearest(List<int> nums, int target)
        {
            int left = 0, right = nums.Count - 1;
            while (true)
            {
                if (left >= right)
                {
                    break;
                }

                int mid = (left + right) / 2;
                if (nums[mid] < target)
                    left = mid + 1;
                else
                    right = mid;
            }

            if (left > 0 && Math.Abs(nums[left - 1] - target) < Math.Abs(nums[left] - target))
                return nums[left - 1];
            return nums[left];
        }

        // Rank
        static Dictionary<int, int> Rank(List<int> nums)
        {
            var sorted = nums.Distinct().OrderByDescending(x => x).ToList(); // 중복 제거 후 내림차순

            var dict = new Dictionary<int, int>(); // rank, score 

            for (int i = 0; i < sorted.Count; i++)
            {
                var num = sorted[i];
                dict[num] = i + 1;
            }

            return dict;
        }
    }
}
