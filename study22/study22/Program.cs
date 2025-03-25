using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study22
{

    class Cup<T>
    {
        public T Content { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Generic
            //Cup<string> cupOfString = new Cup<string> { Content = "Coffee" };
            //Cup<int> cupOfInt = new Cup<int> { Content = 42 };

            //Console.WriteLine($"CupOfString: {cupOfString.Content}");
            //Console.WriteLine($"cupOfInt: {cupOfInt.Content}");

            // Enumerator
            //ArrayList list = new ArrayList { "Apple", "Banana", "Cherry" };
            //IEnumerator enumerator = list.GetEnumerator();

            //while (enumerator.MoveNext())
            //{
            //    Console.Write(enumerator.Current + " ");
            //}

            // Dictionary
            //var dict = new Dictionary<string, int>();

            //dict["금도끼"] = 10;
            //dict["은도끼"] = 5;
            //dict["돌도끼"] = 1;

            //foreach(var pair in dict)
            //{
            //    Console.WriteLine($"{pair.Key}: {pair.Value}");
            //}

            // null값
            //string str = null;
            //int? num = null;

            //Console.WriteLine(str?.Length);

            //int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //var evenNums = nums.Where(n => n % 2 == 0);
            
            //foreach(var num in evenNums)
            //{
            //    Console.Write(num + " ");
            //}

        }
    }
}
