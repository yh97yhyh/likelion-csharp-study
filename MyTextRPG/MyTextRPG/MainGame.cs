using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG
{
    class MainGame
    {
        public Player CurPlayer { get; set; }
        public Field CurField { get; set; }

        public MainGame()
        {
            CurPlayer = new Player();
            CurPlayer.SelectClass();
            CurField = new Field(CurPlayer);
        }

        public MainGame(Player curPlayer, Field curField)
        {
            CurPlayer = curPlayer;
            CurField = curField;
        }

        public void Progress()
        {
            var input = 0;

            while (true)
            {
                Console.Clear();
                CurPlayer.ShowInfo();

                Console.WriteLine("👉 1. 사냥터로 간다. | 2. 종료");
                input = int.Parse(Console.ReadLine());

                if (input == 1)
                {
                    CurField.Progress();
                }
                else
                {
                    break;
                }
            }
        }
    }
}
