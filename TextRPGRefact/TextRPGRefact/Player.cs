using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGRefact
{
    class Player: Character
    {

        public Player()
        {

        }

        public Player(string name, int attack, int hp) : base(name, attack, hp)
        {

        }

        public void ResetHp(int hp)
        {
            Hp = hp;
        }

        public void SelectJob()
        {
            Console.WriteLine("직업을 선택하세요 (1. 전사 | 2. 마법사 | 3. 도적)");
            var input = 0;
            input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    Name = "전사";
                    Hp = 100;
                    Attack = 10;
                    break;
                case 2:
                    Name = "마법사";
                    Hp = 90;
                    Attack = 15;
                    break;
                case 3:
                    Name = "도적";
                    Hp = 85;
                    Attack = 13;
                    break;
                default:
                    break;
            }
        }

        public override void ShowInfo()
        {
            Console.WriteLine("======== 플레이어 정보 ========");
            Console.WriteLine($"이름\t{Name}");
            Console.WriteLine($"체력\t{Hp}");
            Console.WriteLine($"공격력\t{Attack}");
            Console.WriteLine("===============================");
            Console.WriteLine();
        }
    }
}
