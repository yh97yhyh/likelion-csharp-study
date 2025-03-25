using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// namespace
// 클래스, 함수, 변수 등 이름이 충돌하는 것을 방지하기 위해 사용
namespace Dev1
{
    class MyClass
    {
        public static void SayHello()
        {
            Console.WriteLine("안녕하세요! dev1의 MyClass의 SayHello입니다");
        }
    }
}

namespace study14
{
    class Program
    {
        static void Main(string[] args)
        {
            Dev1.MyClass.SayHello();
        }
    }
}
