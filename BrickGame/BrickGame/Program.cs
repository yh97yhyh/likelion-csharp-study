using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BrickGame
{
    class Program
    {

        [DllImport("msvcrt.dll")]
        public static extern int _getch();

        public static void GotoXy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }


        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);
            Console.CursorVisible = false;

            var gameManger = new GameManager();

            int curTime = Environment.TickCount;

            while (true)
            {
                if (curTime + 50 < Environment.TickCount)
                {
                    curTime = Environment.TickCount;
                    gameManger.Progress();
                    gameManger.Render();
                }
            }
        }
    }
}
