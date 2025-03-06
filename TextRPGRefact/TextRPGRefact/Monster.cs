using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGRefact
{
    class Monster: Character
    {
        public Monster()
        {

        }

        public Monster(string name, int attack, int hp) : base(name, attack, hp)
        {

        }

        public override void ShowInfo()
        {
            Console.WriteLine("========= 몬스터 정보 =========");
            Console.WriteLine($"이름\t{Name}");
            Console.WriteLine($"체력\t{Hp}");
            Console.WriteLine($"공격력\t{Attack}");
            Console.WriteLine("===============================");
            Console.WriteLine();
        }
    }
}
