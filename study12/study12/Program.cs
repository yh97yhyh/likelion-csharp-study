using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace study12
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintLoading();

            //var baseAtt = 0;
            //var att = 0;

            //baseAtt = BaseAttack();
            //Console.Write("캐릭터의 추가 공격력을 입력해 주세요 : ");
            //att = int.Parse(Console.ReadLine());

            //PrintAttack(baseAtt + att);

            var sum = Add(10, 20);
            Console.WriteLine($"10 + 20 = {sum}");

        }

        static int Add(int n1, int n2)
        {
            int sum = n1 + n2;
            return sum;
        }
        static void PrintLoading()
        {
            Console.WriteLine("Loading..");
            Thread.Sleep(100);
            Console.WriteLine("Loading...");
            Thread.Sleep(100);
            Console.WriteLine("Loading....");
            Thread.Sleep(100);
            Console.WriteLine("Loading.....");
        }
        static void PrintAttack(int att)
        {
            Console.WriteLine($"캐릭터의 공격력은 {att}입니다");
        }
        static int BaseAttack()
        {
            int att = 10;
            return att;
        }
    }
}
