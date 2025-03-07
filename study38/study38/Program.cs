using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study38
{
    class Character
    {
        public string Name { get; private set; }
        public int Health { get; private set; }

        public Action<Character, int> OnDamaged; // 이벤트 역할

        public Character(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name}이(가) {damage} 데미지를 입었습니다.");
            OnDamaged?.Invoke(this, Health);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Action sayHello = SayHello; // 매개변수와 반환값이 없는 메서드를 참조
            //sayHello += ShowNotification;
            //sayHello();

            var hero = new Character("용사", 100);
            hero.OnDamaged += HandleDamage;
            hero.TakeDamage(30);
            Console.WriteLine();

            hero.OnDamaged -= HandleDamage;
            hero.TakeDamage(30);
            Console.WriteLine();
        }

        static void HandleDamage(Character character, int health)
        {
            Console.WriteLine($"Event Alert! {character.Name}이(가) 데미지를 입었습니다! " +
        $"(현재 체력 {character.Health})");
        }

        //static void SayHello()
        //{
        //    Console.WriteLine("안녕하세요.");
        //}

        //static void ShowNotification()
        //{
        //    Console.WriteLine("중요한 알림이 있습니다.");
        //}
    }
}
