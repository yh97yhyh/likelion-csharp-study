using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Player
    {
        public Info PlayerInfo { get; set; }

        //public Info GetInfo()
        //{
        //    return PlayerInfo;
        //}

        public void TakeDamage(int attack)
        {
            PlayerInfo.Hp -= attack;
        }

        public void ResetHp(int hp)
        {
            PlayerInfo.Hp = hp;
        }

        public void SelectJob()
        {
            PlayerInfo = new Info();

            Console.WriteLine("직업을 선택하세요 (1. 전사 | 2. 마법사 | 3. 도적)");
            var input = 0;
            input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    PlayerInfo.Name = "전사";
                    PlayerInfo.Hp = 100;
                    PlayerInfo.Attack = 10;
                    break;
                case 2:
                    PlayerInfo.Name = "마법사";
                    PlayerInfo.Hp = 90;
                    PlayerInfo.Attack = 15;
                    break;
                case 3:
                    PlayerInfo.Name = "도적";
                    PlayerInfo.Hp = 85;
                    PlayerInfo.Attack = 13;
                    break;
                default:
                    break;

            }
        }

        public void ShowPlayerInfo()
        {
            Console.WriteLine("======== 플레이어 정보 ========");
            Console.WriteLine($"직업\t{PlayerInfo.Name}");
            Console.WriteLine($"체력\t{PlayerInfo.Hp}");
            Console.WriteLine($"공격력\t{PlayerInfo.Attack}");
            Console.WriteLine("===============================");
            Console.WriteLine();
        }
    }
}
