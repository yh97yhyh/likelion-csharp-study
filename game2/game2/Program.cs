using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace game2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Random rand = new Random();

            int gold = 500;
            int health = 100;
            int power = 10;
            int monsterHealth = 100;
            int input;
            bool isAlive = true;

            Console.WriteLine("⚔️ 모험가 키우기 ⚔️");

            while (isAlive)
            {
                Console.Clear();
                Console.WriteLine($"현재 상태 - 체력 {health} | 공격력 {power} | 골드 {gold} | 몬스터 체력 {monsterHealth}\n");
                Console.WriteLine("1. 탐험하기 🏕️");
                Console.WriteLine("2. 장비뽑기 🎲 (1000골드)");
                Console.WriteLine("3. 휴식하기 💤 (체력 +20)");
                Console.WriteLine("4. 게임종료");
                Console.Write("입력 : ");

                input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("탐험을 떠납니다.");
                        Thread.Sleep(500);
                        Console.WriteLine("탐험을 떠납니다..");
                        Thread.Sleep(500);
                        Console.WriteLine("탐험을 떠납니다...");
                        Thread.Sleep(500);
                        Console.WriteLine("탐험을 떠납니다....");

                        int eventChance = rand.Next(1, 101);

                        if (eventChance <= 40) // 40% 확률로 전투 발생
                        {
                            int monsterPower = rand.Next(10, 31);

                            Console.WriteLine($"⚔️ 몬스터를 만났습니다! (몬스터 공격력: {monsterPower})");

                            int damage = monsterPower;
                            if (power < monsterPower)
                            {
                                damage = (int)(monsterPower * 1.5);
                                Console.WriteLine($"몬스터가 강합니다! 피해가 증가합니다. (체력 -{damage})");
                                Console.WriteLine($"몬스터에게 공격을 했습니다. (몬스터체력 -{power})");
                            }
                            else
                            {
                                damage = monsterPower / 2;
                                Console.WriteLine($"몬스터가 약합니다! 피해가 감소합니다. (체력 -{damage})");
                                Console.WriteLine($"몬스터에게 공격을 했습니다. (몬스터체력 -{power})");

                            }

                            health -= damage;
                            monsterHealth -= power;
                        }
                        else if (eventChance <= 80) // 40% 확률로 보상
                        {
                            int reward = rand.Next(100, 301);
                            Console.WriteLine($"💰 보물을 발견했습니다! (골드 +{reward})");
                            gold += reward;
                        } else // 20% 확률로 회복
                        {
                            int heal = rand.Next(10, 31);
                            Console.WriteLine($"🌿 신비한 약초를 발견했습니다! (체력 +{heal})");
                            health += heal;
                        }

                        if (health <= 0)
                        {
                            Console.WriteLine("💀 체력이 0이 되어 사망했습니다... 게임 오버!");
                            isAlive = false;
                        } else if (monsterHealth <= 0)
                        {
                            Console.WriteLine("🎉 몬스터를 물리쳤습니다!!");
                            isAlive = false;
                        }
                        break;
                    case 2:
                        if (gold >= 1000)
                        {
                            gold -= 1000;
                            Console.Clear();
                            Console.WriteLine("🎲 장비를 뽑습니다...");
                            Thread.Sleep(1000);

                            int rnd = rand.Next(1, 101);

                            if (rnd <= 1)
                            {
                                Console.WriteLine("SSS 전설의검 획득! (공격력 +50)");
                                power += 50;
                            }
                            else if (rnd <= 10)
                            {
                                Console.WriteLine("SS 희귀의검 획득! (공격력 +30)");
                                power += 30;
                            }
                            else if (rnd <= 30)
                            {
                                Console.WriteLine("S 강철검 획득! (공격력 +20)");
                                power += 20;
                            }
                            else
                            {
                                Console.WriteLine("녹슨칼 획득! (공격력 +5)");
                                power += 5;
                            }
                            //Console.WriteLine($"현재 공격력 : {power}");
                        }
                        else
                        {
                            Console.WriteLine("골드가 부족합니다. (1000골드 필요)");

                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("휴식을 취합니다... (체력 +20)");
                        health += 20;
                        break;
                    case 4:
                        Console.WriteLine("게임을 종료합니다.");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
                Thread.Sleep(2000);

            }
        }
    }
}
