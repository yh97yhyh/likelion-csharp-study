using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study35
{
    interface IAnimal
    {
        void MakeSound();
    }

    class Dog : IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("멍멍!");
        }
    }

    public class Cat : IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("야옹!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var dog = new Dog();
            var cat = new Cat();

            dog.MakeSound(); // 멍멍!
            cat.MakeSound(); // 야옹!
        }
    }
}
