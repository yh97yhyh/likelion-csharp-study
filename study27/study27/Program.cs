using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study27
{
    class Animal
    {
        public void Speak()
        {
            Console.WriteLine("동물이 소리를 냅니다.");
        }
    }

    class Dog: Animal
    {
        public void Bark()
        {
            Console.WriteLine("멍멍!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // UpCasting
            var dog = new Dog();
            Animal animal = dog;
            animal.Speak();

            // DownCasting
            var animal2 = new Animal();
            var dog2 = animal as Dog;
            var dog3 = animal2 as Dog;
            
            if (dog2 != null)
            {
                dog2.Bark();
            }
            else
            {
                Console.WriteLine("dog2 다운캐스팅 실패!");
            }

            if (dog3 != null)
            {
                dog2.Bark();
            }
            else
            {
                Console.WriteLine("dog3 다운캐스팅 실패!");
            }
        }
    }
}
