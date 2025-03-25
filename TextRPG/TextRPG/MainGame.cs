using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class MainGame
    {
        public Player CurPlayer { get; set; }
        public Field CurField { get; set; }

        public void Init()
        {
            CurPlayer = new Player();
            CurPlayer.SelectJob();
        }

        public void Progress()
        {
            var input = 0;

            while (true)
            {
                Console.Clear();
                CurPlayer.ShowPlayerInfo();

                Console.WriteLine("1. 사냥터 | 2. 종료");
                input = int.Parse(Console.ReadLine());

                if (input == 2)
                {
                    break;
                }

                if (input == 1)
                {
                    if (CurField == null)
                    {
                        CurField = new Field();
                        CurField.CurPlayer = CurPlayer;
                    }

                    CurField.Progress();
                }
            }
        }
    }
}
