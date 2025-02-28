using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study19
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        {
            Name = "이름 없음";
            Age = 0;
            Console.WriteLine("기본 생성자가 실행됨");
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            Console.WriteLine("매개변수가 있는 생성자가 실행됨");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"이름 : {Name}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Person("홍길동", 18);
            p1.ShowInfo();

            Console.WriteLine("--------------------");

            var p2 = new Person(); 
            p2.ShowInfo();
        }
    }
}
