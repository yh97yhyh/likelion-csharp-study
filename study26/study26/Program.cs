using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study26
{
    class Animal
    {
        public string Name { get; set; }

        public virtual void Speak() // 자식 클래스에서 재정의 가능
        {
            Console.WriteLine("동물이 소리를 냅니다.");
        }
    }

    class Dog: Animal
    {
        public override void Speak()
        {
            Console.WriteLine($"{Name}이(가) 멍멍 짖습니다.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var animal = new Animal();
            animal.Name = "일반동물";
            animal.Speak();

            var dog = new Dog();
            dog.Name = "바둑이";
            dog.Speak();
        }
    }
}
