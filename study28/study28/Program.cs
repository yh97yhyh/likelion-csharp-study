using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study28
{
    class Animal
    {
        public virtual void Speak()
        {
            Console.WriteLine("동물이 소리를 냅니다.");
        }
    }

    class Dog: Animal
    {
        public override void Speak()
        {
            Console.WriteLine("멍멍!");
        }

        public void WagTail()
        {
            Console.WriteLine("꼬리를 흔든다.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Dog(); // 업캐스팅
            animal.Speak(); // 멍멍!

            var dog = animal as Dog;
            dog.WagTail();

            var animal2 = new Animal();
            animal2.Speak();
        }
    }
}
