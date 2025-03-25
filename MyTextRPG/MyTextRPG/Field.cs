using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyTextRPG
{ 
    class Field
    {
        const int BASIC = 1;
        const int INTERMEDATE = 2;
        const int ADVANCED = 3;

        public Player CurPlayer { get; set; }
        public Monster CurMonster { get; set; }
        public int CurFieldLevel { get; set; }

        public Field()
        {
            CurFieldLevel = 1;
        }

        public Field(Player curPlayer)
        {
            CurPlayer = curPlayer;
            CurMonster = new Monster();
            CurFieldLevel = 1;
        }

        public Field(Player curPlayer, Monster curMonster, int curFieldLevel)
        {
            CurPlayer = curPlayer;
            CurMonster = curMonster;
            CurFieldLevel = curFieldLevel;
        }

        public void Progress()
        {
            SetField();
        }

        public void SetField()
        {
            var input = 0;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("👉 탐색할 필드를 선택해 주세요. 1. 초보 | 2. 중수 | 3. 고수 | 4. 뒤로");
                input = int.Parse(Console.ReadLine());

                if (input >= 0 && input <= 3)
                {
                    CreateMonster(input);
                    Fight();
                }
                else
                {
                    break;
                }
            }
        }

        public void CreateMonster(int input)
        {
            switch (input)
            {
                case BASIC:
                    CurMonster.Name = "말랑이";
                    CurMonster.Hp = 30;
                    CurMonster.Attack = 3;
                    break;
                case INTERMEDATE:
                    CurMonster.Name = "질퍽이";
                    CurMonster.Hp = 60;
                    CurMonster.Attack = 6;
                    break;
                case ADVANCED:
                    CurMonster.Name = "단단이";
                    CurMonster.Hp = 90;
                    CurMonster.Attack = 9;
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
                CurMonster.ShowInfo();
                Console.WriteLine($"1. {CurMonster.Name}와(과) 맞선다. | 2. 도망간다.");
                input = int.Parse(Console.ReadLine());

                if (input == 1)
                {
                    Console.WriteLine($"⚔️ {CurMonster.Name}와(과) 맞섭니다!");
                    CurPlayer.TakeDamage(CurMonster.Attack);
                    CurMonster.TakeDamage(CurPlayer.Attack);
                    Thread.Sleep(1500);

                    if (CurPlayer.Hp <= 0)
                    {
                        CurPlayer.Revival();
                        Thread.Sleep(1500);
                        break;
                    }

                    if (CurMonster.Hp <= 0)
                    {
                        CurMonster.Die();
                        Thread.Sleep(1500);
                        break;
                    }
                }

                if (input == 2)
                {
                    Console.WriteLine("💨 도망갑니다... ");
                    Thread.Sleep(1500);
                    break;
                }

            }
        }
    }

}
