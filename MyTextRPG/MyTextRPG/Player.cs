using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG
{
    class Player : Character
    {
        const int WARRIOR = 1;
        const int MAGE = 2;
        const int THIEF = 3;

        public Player()
        {

        }

        public Player(string name, int hp, int attack) : base(name ,hp, attack)
        {

        }

        public void SelectClass()
        {
            var input = 0;
            Console.WriteLine("👉 직업을 선택해 주세요. 1. 전사 | 2. 마법사 | 3. 도적");
            input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case WARRIOR:
                    Name = "전사";
                    Hp = 100;
                    Attack = 10;
                    break;
                case MAGE:
                    Name = "마법사";
                    Hp = 75;
                    Attack = 15;
                    break;
                case THIEF:
                    Name = "도적";
                    Hp = 88;
                    Attack = 13;
                    break;
                default:
                    break;
            }
        }
        
        public void Revival()
        {
            Console.WriteLine("🤕 사망하였습니다... 부활합니다. (HP : 100)");
            Hp = 100;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("======== 플레이어 정보 ========");
            base.ShowInfo();
        }
    }
}
