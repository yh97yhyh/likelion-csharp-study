using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study33
{
    abstract class Animal
    {
        public abstract void MakeSound(); // 추상 메서드 (강제 구현)

        public void Sleep() // 일반 메서드
        {
            Console.WriteLine("동물이 잠을 잡니다.");
        }
    }

    class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("멍멍!");
        }
    }

    class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("야옹!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var dog = new Dog();
            dog.MakeSound();
            dog.Sleep();

            var cat = new Cat();
            cat.MakeSound();
            cat.Sleep();
        }
    }
}
