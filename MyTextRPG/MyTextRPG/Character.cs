using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG
{
    class Character
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }

        public Character()
        {

        }

        public Character(string name, int hp, int attack)
        {
            Name = name;
            Hp = hp;
            Attack = attack;
        }

        public void TakeDamage(int enemyAttack)
        {
            Hp -= enemyAttack;
            Console.WriteLine($"{Name}이(가) {enemyAttack}만큼 피해를 받았습니다. (남은 HP : {Math.Max(Hp, 0)})");
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"이름\t{Name}");
            Console.WriteLine($"체력\t{Hp}");
            Console.WriteLine($"공격력\t{Attack}");
            Console.WriteLine("===============================");
            Console.WriteLine();
        }
    }
}
