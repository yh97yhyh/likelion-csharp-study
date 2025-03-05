using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study29
{
    class Player
    {
        protected string Name;

        public Player()
        {
            Name = "플레이어";
            Console.WriteLine("Player 생성자 호출!");
        }

        public void Show()
        {
            Console.WriteLine($"이름은 {Name}입니다.");
        }
    }

    class Wizard: Player
    {
        public Wizard()
        {
            Name = "마법사";
            Console.WriteLine("Wizard 생성자 호출!");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var p = new Player();
            p.Show();

            Console.WriteLine();

            var w = new Wizard();
            w.Show();
        }
    }
}
