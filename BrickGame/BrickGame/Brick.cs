using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickGame
{
    class Brick
    {
        public int[] Xs { get; set; }
        public int Y { get; set; }
        public bool IsAlive { get; set; }

        public Brick(int[] xs, int y)
        {
            Xs = xs;
            Y = y;
            IsAlive = true;
        }

        public void Progress()
        {

        }

        public void Render()
        {
            for (int i = 0; i < 3; i++)
            {
                Program.GotoXy(Xs[i], Y);
                Console.Write("■");
            }
        }
    }
}
