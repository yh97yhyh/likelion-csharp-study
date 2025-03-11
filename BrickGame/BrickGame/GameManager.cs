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

        public List<Brick> MyBricks { get; set; }

        private Random Rand = new Random();

        public GameManager()
        {
            MyBricks = new List<Brick>();
            MyBall = new Ball();
            MyBar = new Bar();

            CreateBricks();
            MyBall.MyBar = MyBar;
            MyBall.MyBricks = MyBricks;
        }

        public void CreateBricks()
        {
            var createdXy = new HashSet<(int, int)>();

            for (int i = 0; i < 20; i++)
            {
                int x, y;

                while (true)
                {
                    x = Rand.Next(2, 74);
                    y = Rand.Next(2, 15);

                    if (!createdXy.Contains((x, y)) &&
                        !createdXy.Contains((x + 1, y)) &&
                        !createdXy.Contains((x + 2, y)))
                    {
                        createdXy.Add((x, y));
                        createdXy.Add((x + 1, y));
                        createdXy.Add((x + 2, y));
                        break;
                    }
                }

                var xs = new int[] { x, x + 1, x + 2 };
                var brick = new Brick(xs, y);
                MyBricks.Add(brick);
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
            foreach (var brick in MyBricks)
            {
                if (brick.IsAlive)
                {
                    brick.Render();
                }
            }
        }
    }
}
