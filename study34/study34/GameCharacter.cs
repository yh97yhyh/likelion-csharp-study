using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study34
{
    public abstract class GameCharacter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        protected GameCharacter(string name, int health, int attack, int defense)
        {
            Name = name;
            Health = health;
            Attack = attack;
            Defense = defense;
        }

        public abstract void BaseAttack(GameCharacter target);

        public abstract void SpecialAttack(GameCharacter target);

        public void TakeDamage(int damage)
        {
            int actualDamage = Math.Max(1, damage - Defense);
            Health = Math.Max(0, Health - actualDamage);
            
            Console.WriteLine($"🤕 {Name}이(가) {actualDamage}의 피해를 받았습니다. (남은 체력 {Health})\n");
        }
    }
}
