using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNamespace;

namespace MyNamespace
{
    class MyClass
    {
        public void SayHello()
        {
            Console.WriteLine("Hello from MyNamespace!");
        }
    }
}

namespace study32
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new MyClass();
            obj.SayHello();
        }
    }
}
