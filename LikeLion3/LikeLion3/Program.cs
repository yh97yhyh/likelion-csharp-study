using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion3
{
    class Program
    {
        static void Main(string[] args)
        {
            //string greeting = "Heelo, World!";
            //Console.WriteLine(greeting);

            //int x = 10, y = 20, z = 30;
            //Console.WriteLine($"{x} {y} {z}");

            //const double PI = 3.14159;
            //const int MAX_SCORE = 100;
            //Console.WriteLine($"{PI} {MAX_SCORE}");

            int attackPower = 16755;      
            int maxHealth = 78103;   
            double criticalStrike = 36; 
            int specialization = 1017; 
            int overpower = 41;   
            int swiftness = 611;      
            int persistence = 22;   
            int mastery = 39;

            Console.WriteLine($"기본 특성 - 공격력:{attackPower} 최대생명력:{maxHealth}");
            Console.WriteLine($"전투 특성 - 치명:{criticalStrike} 특화:{specialization} 제압:{overpower}" +
                $" 신속:{swiftness} 인내:{persistence} 숙련:{mastery}");
        }
    }
}
