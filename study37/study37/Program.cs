using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study37
{
    class Character
    {
        public string Name { get; private set; }
        public int Health { get; private set; }

        public event EventHandler OnDamaged; // 이벤트 선언

        public Character(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name}이(가) {damage} 데미지를 입었습니다.");
            OnDamaged?.Invoke(this, EventArgs.Empty);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var hero = new Character("용사", 100);
            hero.OnDamaged += HeroOnDamaged; // 이벤트 구독 
            hero.TakeDamage(30); // TakeDamage 내에서 OnDamaged 이벤트가 발생함
            Console.WriteLine();

            hero.OnDamaged -= HeroOnDamaged; // 이벤트 구독 취소
            hero.TakeDamage(30);
        }

        // 이벤트핸들러 메서드
        // sender : 이벤트를 발생시킨 객체 (여기서는 Character)
        // e : 이벤트와 관련된 추가 데이터
        static void HeroOnDamaged(object sender, EventArgs e)
        {
            var character = sender as Character;
            Console.WriteLine($"Event Alert! {character.Name}이(가) 데미지를 입었습니다! " +
                $"(현재 체력 {character.Health})");
        }
    }
}
