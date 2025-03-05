using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study24
{
    class Animal
    {
        public string Name { get; set; }

        public void Eat()
        {
            Console.WriteLine($"{Name}이(가) 음식을 먹고 있습니다.");
        }
    }

    class Dog: Animal
    {
        public void Bark()
        {
            Console.WriteLine($"{Name}이(가) 멍멍 짖습니다!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var dog = new Dog();
            dog.Name = "바둑이";
            dog.Eat();
            dog.Bark();
        }
    }
}
