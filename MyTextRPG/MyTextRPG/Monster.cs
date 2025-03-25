using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyTextRPG
{
    class Monster : Character
    {
        public Monster()
        {

        }

        public Monster(string name, int hp, int attack) : base(name, hp, attack)
        {

        }

        public void Die()
        {
            Console.WriteLine("🥳 몬스터를 쓰러뜨렸습니다!");
        }

        public override void ShowInfo()
        {
            Console.WriteLine("========= 몬스터 정보 =========");
            base.ShowInfo();
        }
    }
}
