using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Inventory
{

    struct Inventory
    {
        public int MexItemCount { get; set; }
        public Item[] Items { get; set; }

        public Inventory(int maxItemCount)
        {
            MexItemCount = maxItemCount;
            Items = new Item[maxItemCount];
        }

        public void AddItem(string name, int count)
        {
            for (int i = 0; i < MexItemCount; i++)
            {
                if (Items[i].Name == name)
                {
                    Items[i].Count += count;
                    return;
                }
            }

            for (int i = 0; i < MexItemCount; i++)
            {
                if (Items[i].Name == null)
                {
                    Items[i].Name = name;
                    Items[i].Count = count;
                    return;
                }
            }

            Console.WriteLine("인벤토리가 가득 찼습니다.");
        }

        public void RemoveItem(string name, int count)
        {
            for (int i = 0; i < MexItemCount; i++)
            {
                if (Items[i].Name == name)
                {
                    if (Items[i].Count >= count) 
                    {
                        Items[i].Count -= count;
                        if (Items[i].Count == 0) 
                        {
                            Items[i].Name = null;
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

        public void ShowInventory()
        {
            Console.WriteLine("┌───────────현재 인벤토리───────────┐");
            bool isEmpty = true;

            for (int i = 0; i < MexItemCount; i++)
            {
                if (Items[i].Name != null)
                {
                    Console.WriteLine($" {Items[i].Name} (x{Items[i].Count})");
                    isEmpty = false;
                }
            }
            Console.WriteLine("└───────────────────────────────────┘");

            if (isEmpty)
            {
                Console.WriteLine("인벤토리가 비어있습니다.");
            }

            Console.WriteLine();
        }
    }
    struct Item
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var sword = "🗡️ 칼";
            var potion = "🧪 포션";
            var shield = "🛡️ 방패";

            var inventory = new Inventory(10);

            inventory.AddItem(potion, 5);
            inventory.AddItem(sword, 1);
            inventory.AddItem(potion, 3);
            inventory.ShowInventory();

            Console.WriteLine("- 포션 2개 사용!");
            inventory.RemoveItem(potion, 2);
            inventory.ShowInventory();

            Console.WriteLine("- 방패 1개 제거 시도");
            inventory.RemoveItem(shield, 1);
            inventory.ShowInventory();

            Console.WriteLine("- 포션 6개 사용(초과 사용 테스트)");
            inventory.RemoveItem(potion, 7);
            inventory.ShowInventory();
        }
    }
}
