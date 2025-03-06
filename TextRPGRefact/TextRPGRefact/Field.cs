using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextRPGRefact
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

                CurPlayer.ShowInfo();

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
                    CurMonster = new Monster("초보몬스터", 3, 30);
                    break;
                case 2:
                    CurMonster = new Monster("중수몬스터", 6, 60);
                    break;
                case 3:
                    CurMonster = new Monster("고수몬스터", 9, 90);
                    break;
                default:
                    break;
            }

        }

        public void Fight()
        {
            var input = 0;

            while (true)
            {
                Console.Clear();
                
                CurPlayer.ShowInfo();
                CurMonster.ShowInfo();

                Console.WriteLine("1. 공격 | 2. 도망");
                input = int.Parse(Console.ReadLine());

                if (input == 1)
                {
                    CurPlayer.TakeDamage(CurMonster.Attack);
                    CurMonster.TakeDamage(CurPlayer.Attack);

                    Console.WriteLine("공격!");
                    Thread.Sleep(500);

                    if (CurPlayer.Hp <= 0)
                    {
                        Console.WriteLine("사망하였습니다.. 부활합니다.");
                        Thread.Sleep(1000);
                        CurPlayer.ResetHp(100);
                        break;
                    }
                }

                if (input == 2)
                {
                    Console.WriteLine("도망쳤습니다...");
                    Thread.Sleep(1000);
                    break;
                }

                if (CurMonster.Hp <= 0)
                {
                    Console.WriteLine("승리하였습니다! ");
                    Thread.Sleep(1000);
                    break;
                }

            }
        }
    }
}
