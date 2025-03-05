using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study31
{
    class Skill
    {
        public string Name { get; set; }
        public int ManaCost { get; set; }
        public int Cooldown { get; set; }
        public int LastUsedTime { get; set; }

        public Skill(string name, int manaCost, int cooldown)
        {
            Name = name;
            ManaCost = manaCost;
            Cooldown = cooldown * 1000;
            LastUsedTime = 0;
        }

        public void ShowSkillInfo()
        {
            Console.WriteLine($"{Name} (필요 MP: {ManaCost} | 쿨타임: {Cooldown / 1000})");
        }

        public bool CanActiveSkill(int playerMana)
        {
            int currentTime = Environment.TickCount;

            if (playerMana < ManaCost)
            {
                Console.WriteLine($" 마나가 부족합니다! (필요 MP: {ManaCost}");
                return false;
            }

            if (currentTime - LastUsedTime < Cooldown)
            {
                int remainingTime = (Cooldown - (currentTime - LastUsedTime)) / 1000;
                Console.WriteLine($" {Name} 스킬은 아직 사용할 수 없습니다.(남은 시간 : {remainingTime}초)");
                return false;
            }

            return true;
        }

        public void ActivateSkill(ref int playerMana)
        {
            if (!CanActiveSkill(playerMana)) return;

            playerMana -= ManaCost;
            LastUsedTime = Environment.TickCount;

            Console.WriteLine($"⚔️ {Name} 발동 ! (MP - {ManaCost})");
        }

    }

    class BaseGroup
    {
        public string Name { get; set; }
        public List<Skill> Skills { get; set; }

        public BaseGroup(string name, List<Skill> commonSkills)
        {
            Name = name;
            Skills = commonSkills;
        }

        public void ShowSkillInfo()
        {
            Console.WriteLine($"{Name} 스킬");
            for (int i = 0; i < Skills.Count; i++)
            {
                Console.Write($"{i+1}) ");
                Skills[i].ShowSkillInfo();
            }
            Console.WriteLine();
        }
    }

    class OccupationLine: BaseGroup // 직업계열 (모험가, 영웅, ...)
    {
        public OccupationLine(string name, List<Skill> Skills) : base(name, Skills)
        {

        }
    }
 
    class Class: BaseGroup // 전직계열 (전사, 궁수, ...)
    {
        public Class(string name, List<Skill> Skills) : base(name, Skills)
        {

        }

    }

    class Occupation: BaseGroup // 직업
    {
        public Occupation(string name, List<Skill> Skills) : base(name, Skills)
        {

        }
    }

    class Player
    {
        public string NickName { get; set; }
        public Occupation PlayerOccupation { get; set; }
        public OccupationLine PlayerOccupationLine { get; set; }
        public Class PlayerClass { get; set; }
        public int Level { get; set; }
        public int Hp { get; set; }
        public int Mana { get; set; }
        public int Meso { get; set; }

        public Player(string nickname, Occupation playerOccupation, OccupationLine occupationLine, Class playerClass)
        {
            NickName = nickname;
            PlayerOccupation = playerOccupation;
            PlayerOccupationLine = occupationLine;
            PlayerClass = playerClass;
            Level = 10;
            Hp = 30000;
            Mana = 2000;
            Meso = 1000000;
        }

        public void ShowPlayerInfo()
        {
            Console.WriteLine("---------- 👤 캐릭터 정보 ----------");
            Console.WriteLine($"직업\t\t{PlayerOccupation.Name}");
            Console.WriteLine($"직업계열\t{PlayerOccupationLine.Name}");
            Console.WriteLine($"전직계열\t{PlayerClass.Name}");
            Console.WriteLine($"레벨\t\t{Level}");
            Console.WriteLine($"체력\t\t{Level}");
            Console.WriteLine($"마나\t\t{Level}");
            Console.WriteLine($"메소\t\t{Level}");
            Console.WriteLine("------------------------------------");
        }

        public void ShowPlayerSkillInfo()
        {
            Console.WriteLine("----------- ⚔️ 스킬 정보 -----------");
            PlayerOccupation.ShowSkillInfo();
            PlayerOccupationLine.ShowSkillInfo();
            PlayerClass.ShowSkillInfo();
            Console.WriteLine("------------------------------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var adventurerSkills = new List<Skill>();
            adventurerSkills.Add(new Skill("블리츠 실드", 200, 20));
            adventurerSkills.Add(new Skill("이블브", 200, 20));
            adventurerSkills.Add(new Skill("언스태이블 메모라이즈", 200, 20));

            var heroSkills = new List<Skill>();
            heroSkills.Add(new Skill("프리드의 가호", 600, 100));


            var warriorSkills = new List<Skill>();
            warriorSkills.Add(new Skill("오라 웨폰", 300, 30));
            warriorSkills.Add(new Skill("바디 오브 스틸", 300, 20));

            var archerSkills = new List<Skill>();
            archerSkills.Add(new Skill("크리티컬 리인포스", 300, 30));
            archerSkills.Add(new Skill("가이디드 애로우", 300, 20));

            var aranSkills = new List<Skill>();
            aranSkills.Add(new Skill("비욘더", 10, 1));
            aranSkills.Add(new Skill("아드레날린", 300, 70));
            aranSkills.Add(new Skill("헌터즈 타겟팅", 300, 70));

            var occupations = new List<Occupation>()
            {
                new Occupation("아란", aranSkills)
            };

            var occupationLines = new List<OccupationLine>()
            {
                new OccupationLine("모험가", adventurerSkills),
                new OccupationLine("영웅", heroSkills)
            };

            var classes = new List<Class>()
            {
                new Class("전사", warriorSkills),
                new Class("궁수", archerSkills)
            };

            var player = new Player("z지존아란z", occupations[0], occupationLines[1], classes[0]);
            player.ShowPlayerInfo();
            Console.WriteLine();
            player.ShowPlayerSkillInfo();
        }
    }
}
