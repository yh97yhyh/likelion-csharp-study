using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study5
{
    class Program
    {
        static void Main(string[] args)
        {
            int integerNum = 10;
            float floatNum = 3.14f; // float은 f를 붙여줘야 함
            double doubleNum = 3.14159;

            //Console.WriteLine(integerNum);
            //Console.WriteLine(floatNum);
            //Console.WriteLine(doubleNum);

            sbyte signedByte = -50; // 1바이트 크기
            short signedShort = -32000; // 2바이트 크기

            string greeting = "Hello World";
            string name = "Alice";
            Console.WriteLine($"{greeting} {name}");

        }
    }
}
