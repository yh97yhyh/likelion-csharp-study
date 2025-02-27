using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    class Program
    {
        const int MAX_ITEMS = 10;

        static string[] itemNames = new string[MAX_ITEMS];
        static int[] itemCounts = new int[MAX_ITEMS];

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var sword = "🗡️ 칼";
            var potion = "🧪 포션";
            var shield = "🛡️ 방패";

            AddItem(potion, 5);
            AddItem(sword, 1);
            AddItem(potion, 3);
            ShowInventory();

            Console.WriteLine("- 포션 2개 사용!");
            RemoveItem(potion, 2);
            ShowInventory();

            Console.WriteLine("- 방패 1개 제거 시도");
            RemoveItem(shield, 1);
            ShowInventory();

            Console.WriteLine("- 포션 6개 사용(초과 사용 테스트)");
            RemoveItem(potion, 7);
            ShowInventory();
    

        }

        static void AddItem(string name, int count)
        {
            for(int i=0; i<MAX_ITEMS; i++)
            {
                if (itemNames[i] == name) // 이미 있는 아이템이면 개수 증가
                {
                    itemCounts[i] += count;
                    return;
                }
            }

            for(int i=0; i<MAX_ITEMS; i++)
            {
                if (itemNames[i] == null) // 빈 슬롯에 새로운 아이템 추가
                {
                    itemNames[i] = name;
                    itemCounts[i] = count;
                    return;
                }
            }

            Console.WriteLine("인벤토리가 가득 찼습니다.");
        }

        static void RemoveItem(string name, int count)
        {
            for(int i=0; i<MAX_ITEMS; i++)
            {
                if (itemNames[i] == name) // 해당 아이템 찾기
                {
                    if (itemCounts[i] >= count) // 개수가 충분하면 차감
                    {
                        itemCounts[i] -= count;
                        if (itemCounts[i] == 0) // 개수가 0이면 삭제
                        {
                            itemNames[i] = null;
                        }
                        return;
                    }
                    else
                    {
                        Console.WriteLine("아이템 개수가 부족합니다!");
                        return;
                    }
                }
            }

            Console.WriteLine("아이템을 찾을 수 없습니다!");
        }

        static void ShowInventory()
        {
            Console.WriteLine("========== 현재 인벤토리 ==========");
            bool isEmpty = true;

            for(int i=0; i<MAX_ITEMS; i++)
            {
                if (itemNames[i] != null)
                {
                    Console.WriteLine($"{itemNames[i]} (x{itemCounts[i]})");
                    isEmpty = false;
                }
            }
            Console.WriteLine("===================================");

            if (isEmpty)
            {
                Console.WriteLine("인벤토리가 비어있습니다.");
            }

            Console.WriteLine();
        }
    }
}
