using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study20
{
    class Marine
    {
        public String Name;
        public int Mineral;

        public Marine()
        {
            Name = "마린0";
            Mineral = 50;
        }

        public Marine(string name, int mineral)
        {
            Name = name;
            Mineral = mineral;
        }

        public void Print()
        {
            Console.WriteLine($"마린 | {Name}의 미네랄 {Mineral}");
        }
    }

    class SCV
    {
        public String Name;
        public int Mineral;

        public SCV()
        {
            Name = "SCV";
            Mineral = 50;
        }

        public SCV(string name, int mineral)
        {
            Name = name;
            Mineral = mineral;
        }

        public void Print()
        {
            Console.WriteLine($"SCV | {Name}의 미네랄 {Mineral}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var m1 = new Marine();
            var m2 = new Marine("마린", 10);
            m1.Print();
            m2.Print();

            var s1 = new SCV();
            var s2 = new SCV("미네랄", 20);
            s1.Print();
            s2.Print();
        }
    }
}
