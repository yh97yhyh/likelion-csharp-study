using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGRefact
{
    class MainGame
    {
        public Player CurPlayer { get; set; }
        public Field CurField { get; set; }

        public MainGame()
        {
            CurPlayer = new Player();
            CurPlayer.SelectJob();
            CurField = new Field();
            CurField.CurPlayer = CurPlayer;
        }

        public void Progress()
        {
            var input = 0;

            while (true)
            {
                Console.Clear();
                CurPlayer.ShowInfo();

                Console.WriteLine("1. 사냥터 | 2. 종료");
                input = int.Parse(Console.ReadLine());

                if (input == 2)
                {
                    break;
                }

                if (input == 1)
                {
                    CurField.Progress();
                }
            }
        }
    }
}
