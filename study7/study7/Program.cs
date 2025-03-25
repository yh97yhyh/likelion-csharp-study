using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study7
{
    class Program
    {
        static void Main(string[] args)
        {
            // 증감 연산자
            int b = 3;
            Console.WriteLine($"b의 값은{b++}"); // 후위
            Console.WriteLine($"b의 값은{++b}"); // 전위

            int key = 1;
            string str;
            str = (key == 2) ? "문이 열렸습니다." : "문이 열리지 않았습니다.";
            Console.WriteLine(str);
       }
    }
}
