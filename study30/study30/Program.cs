using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace study30
{
    class Skill
    {
        public string Name;
        public int ManaCost;
        public int Cooldown;
        public int LastUsedTime;

        public Skill(string name, int manaCost, int cooldown)
        {
            Name = name;
            ManaCost = manaCost;
            Cooldown = cooldown * 1000;
            LastUsedTime = 0;
        }
        
        public bool CanUse(int playerMana)
        {
            var currentTime = Environment.TickCount;
            
            if (playerMana < ManaCost)
            {
                Console.WriteLine($"💙 마나가 부족합니다. (필요 MP: {ManaCost}");
                return false;
            }


            if (currentTime - LastUsedTime < Cooldown)
            {
                var remainingTime = (Cooldown - (currentTime - LastUsedTime)) / 1000;
                Console.WriteLine($"⏳ {Name} 스킬은 아직 사용할 수 없습니다. (남은 시간: {remainingTime})");
                return false;
            }

            return true;
        }

        public void Use(ref int playerMana)
        {
            if(!CanUse(playerMana))
            {
                return;
            }

            playerMana -= ManaCost;
            LastUsedTime = Environment.TickCount;
            Console.WriteLine($"{Name} 스킬 사용! (MP -{ManaCost})");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int playerMana = 200;
            var skills = new List<Skill>()
            {
                new Skill("🔥 파이어볼", 20, 3),
                new Skill("🧊 얼음창", 15, 2),
                new Skill("💫 힐링", 30, 5)
            };

            while(true)
            {
                Console.Clear();
                Console.WriteLine($"현재 MP: {playerMana}");
                Console.WriteLine("--- 사용 가능한 스킬 ---");
                for(int i=0; i<skills.Count; i++)
                {
                    Console.Write($"{i + 1}. {skills[i].Name} (MP {skills[i].ManaCost} ");
                    Console.WriteLine($"(Cooldown {skills[i].Cooldown / 1000}s)");
                }
                Console.WriteLine("0. 종료");
                Console.WriteLine("");
                Console.Write("사용할 스킬 번호를 입력하세요. ");

                try
                {
                    int skillIndex = int.Parse(Console.ReadLine());

                    if(skillIndex == 0)
                    {
                        break;
                    }
                    else if (skillIndex > 0 && skillIndex <= skills.Count)
                    {
                        skills[skillIndex - 1].Use(ref playerMana);
                    }
                    else
                    {
                        Console.WriteLine("올바른 스킬을 입력하세요.");
                    }
                }
                catch
                {
                    Console.WriteLine("숫자를 입력하세요!");
                }

                Thread.Sleep(1000);
            }

            Console.WriteLine("게임 종료");
        }
    }
}
