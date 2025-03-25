using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Monster
    {
        public Info MonsterInfo { get; set; }

        public void TakeDamage(int attack)
        {
            MonsterInfo.Hp -= attack;
        }

        public void ShowPlayerInfo()
        {
            Console.WriteLine("========= 몬스터 정보 =========");
            Console.WriteLine($"이름\t{MonsterInfo.Name}");
            Console.WriteLine($"체력\t{MonsterInfo.Hp}");
            Console.WriteLine($"공격력\t{MonsterInfo.Attack}");
            Console.WriteLine("===============================");
            Console.WriteLine();
        }
    }
}
