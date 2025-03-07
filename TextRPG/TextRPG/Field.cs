using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Field
    {
        public Player CurPlayer { get; set; }
        public Monster CurMonster { get; set; }

        public void Progress()
        {
            int input = 0;

            while (true)
            {
                Console.Clear();

                CurPlayer.ShowPlayerInfo();

                Console.WriteLine("1. 초보필드 | 2. 중수필드 | 3. 고수필드 | 4. 전단계");
                input = int.Parse(Console.ReadLine());

                if (input == 4)
                {
                    break;
                }

                if (input >= 0 && input <= 3)
                {
                    CreateMonster(input);
                    Fight();
                }

            }
        }

        public void CreateMonster(int input)
        {
            switch (input)
            {
                case 1:
                    CurMonster = Create("초보몹", 30, 3);
                    break;
                case 2:
                    CurMonster = Create("중수몹", 60, 6);
                    break;
                case 3:
                    CurMonster = Create("고수몹", 90, 9);
                    break;
                default:
                    break;
            }
        }

        public Monster Create(string name, int hp, int attack)
        {
            var monster = new Monster();
            var monsterInfo = new Info();

            monsterInfo.Name = name;
            monsterInfo.Hp = hp;
            monsterInfo.Attack = attack;

            monster.MonsterInfo = monsterInfo;

            return monster;
        }

        public void Fight()
        {
            int input = 0;
            
            while (true)
            {
                Console.Clear();

                CurPlayer.ShowPlayerInfo();
                CurMonster.ShowPlayerInfo();

                Console.WriteLine("1. 공격 | 2. 도망");
                input = int.Parse(Console.ReadLine());

                if (input == 1)
                {
                    CurPlayer.TakeDamage(CurMonster.MonsterInfo.Attack);
                    CurMonster.TakeDamage(CurPlayer.PlayerInfo.Attack);

                    if (CurPlayer.PlayerInfo.Hp <= 0)
                    {
                        CurPlayer.ResetHp(100);
                        break;
                    }
                }

                if (input == 2 || CurMonster.MonsterInfo.Hp <= 0)
                {
                    CurMonster = null;
                    break;
                }
            }
        }
    }
}
