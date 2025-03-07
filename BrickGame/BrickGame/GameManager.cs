using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickGame
{
    class GameManager
    {
        public Ball MyBall { get; set; }
        public Bar MyBar { get; set; }

        public GameManager()
        {
            if (MyBall == null)
            {
                MyBall = new Ball();
            }

            if (MyBar == null)
            {
                MyBar = new Bar();
                MyBall.MyBar = MyBar;
            }

        }

        public void Progress()
        {
            MyBall.Progress();
            MyBar.Progress(MyBall);
        }

        public void Render()
        {
            Console.Clear();
            MyBall.Render();
            MyBar.Render();
        }

        public void Release()
        {
            MyBall.Release();
            MyBar.Release();
        }
    }
}
