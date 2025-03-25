using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("루인 스킬 피해를 입력하세요:");
            double runeSkillDamage = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("카드 게이지 획득량을 입력하세요:");
            double cardGaugeGain = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("각성기 피해를 입력하세요:");
            double awakeningSkillDamage = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("최대 마나를 입력하세요:");
            int maxMana = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("전투 중 마나 회복량을 입력하세요:");
            int combatManaRecovery = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("비전투 중 마나 회복량을 입력하세요:");
            int nonCombatManaRecovery = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("이동 속도를 입력하세요:");
            double movementSpeed = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("탈 것 속도를 입력하세요:");
            double mountSpeed = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("운반 속도를 입력하세요:");
            double carrySpeed = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("스킬 재사용 대기시간 감소를 입력하세요:");
            double cooldownReduction = Convert.ToDouble(Console.ReadLine());


            //Console.WriteLine($"루인 스킬 피해: {runeSkillDamage:F1}%");
            //Console.WriteLine($"카드 게이지 획득량: {cardGaugeGain:F1}%");
            //Console.WriteLine($"각성기 피해: {awakeningSkillDamage:F1}%");
            //Console.WriteLine($"최대 마나: {maxMana}");
            //Console.WriteLine($"전투 중 마나 회복량: {combatManaRecovery}");
            //Console.WriteLine($"비전투 중 마나 회복량: {nonCombatManaRecovery}");
            //Console.WriteLine($"이동 속도: {movementSpeed:F1}%");
            //Console.WriteLine($"탈 것 속도: {mountSpeed:F1}%");
            //Console.WriteLine($"운반 속도: {carrySpeed:F1}%");
            //Console.WriteLine($"스킬 재사용 대기시간 감소: {cooldownReduction:F1}%");

            Console.WriteLine($"루인 스킬 피해\t\t\t{runeSkillDamage}%");
            Console.WriteLine($"카드 게이지 획득량\t\t{cardGaugeGain}%");
            Console.WriteLine($"각성기 피해\t\t\t{awakeningSkillDamage}%");
            Console.WriteLine($"최대 마나\t\t\t{maxMana}%");
            Console.WriteLine($"전투 중 마나 회복량\t\t{combatManaRecovery}%");
            Console.WriteLine($"비전투 중 마나 회복량\t\t{nonCombatManaRecovery}%");
            Console.WriteLine($"이동 속도\t\t\t{movementSpeed}%");
            Console.WriteLine($"탈 것 속도\t\t\t{mountSpeed}%");
            Console.WriteLine($"운반 속도\t\t\t{carrySpeed}%");
            Console.WriteLine($"스킬 재사용 대기시간 감소\t{cooldownReduction}%");

            //Console.WriteLine($"{"루인 스킬 피해", -20} {runeSkillDamage, 10:F1}%");
            //Console.WriteLine($"{"카드 게이지 획득량", -20} {cardGaugeGain, 10:F1}%");
            //Console.WriteLine($"{"각성기 피해", -20} {awakeningSkillDamage, 10:F1}%");
            //Console.WriteLine($"{"최대 마나", -20} {maxMana, 10}");
            //Console.WriteLine($"{"전투 중 마나 회복량", -20} {combatManaRecovery, 10}");
            //Console.WriteLine($"{"비전투 중 마나 회복량", -20} {nonCombatManaRecovery, 10}");
            //Console.WriteLine($"{"이동 속도", -20} {movementSpeed, 10:F1}%");
            //Console.WriteLine($"{"탈 것 속도", -20} {mountSpeed, 10:F1}%");
            //Console.WriteLine($"{"운반 속도", -20} {carrySpeed, 10:F1}%");
            //Console.WriteLine($"{"스킬 재사용 대기시간 감소", -20} {cooldownReduction, 10:F1}%");
        }
    }
}
