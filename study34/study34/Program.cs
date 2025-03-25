using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study34
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("간단한 RPG 게임을 시작합니다.");
            var warrior = new Warrior("전사");
            var mage = new Mage("마법사");

            Console.WriteLine("============= 전투 시작! =============");

            warrior.BaseAttack(mage);
            warrior.SpecialAttack(mage);

            mage.BaseAttack(warrior);
            mage.SpecialAttack(warrior);

            Console.WriteLine("============= 전투 종료. =============");
            Console.WriteLine($"전사의 남은 체력 : {warrior.Health}");
            Console.WriteLine($"마법사의 남은 체력 : {warrior.Health}");
        }
    }
}
