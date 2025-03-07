using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickGame
{
    class Ball
    {
        public BallData MyBallData { get; set; }
        public int[,] WallCollision { get; set; }
        public Bar MyBar { get; set; }
        public List<Brick> MyBricks { get; set; }

        public Ball()
        {
            MyBallData = new BallData();
            MyBallData.IsReady = false;
            MyBallData.CurDirection = Direction.UpRight;
            MyBallData.X = 30;
            MyBallData.Y = 10;
            WallCollision = new int[4, 6] // 벽면4 방향6
            {
                { 3, 2, -1, -1, -1, 4 },
                { -1, -1, -1, -1, 2, 1 },
                { -1, 5, 4, -1, -1, -1 },
                { -1, -1, 1, 0, 5, -1 }
            };
        }

        public void Progress()
        {
            if (MyBallData.IsReady == false)
            {
                switch (MyBallData.CurDirection)
                {
                    case Direction.Up:
                        if (!Collide(MyBallData.X, MyBallData.Y - 1))
                        {
                            MyBallData.Y--;
                        }
                        break;
                    case Direction.UpRight:
                        if (!Collide(MyBallData.X + 1, MyBallData.Y - 1))
                        {
                            MyBallData.X++;
                            MyBallData.Y--;
                        }
                        break;
                    case Direction.DownRight:
                        if (!Collide(MyBallData.X + 1, MyBallData.Y + 1))
                        {
                            MyBallData.X++;
                            MyBallData.Y++;
                        }
                        break;
                    case Direction.Down:
                        if (!Collide(MyBallData.X, MyBallData.Y + 1))
                        {
                            MyBallData.Y++;
                        }
                        break;
                    case Direction.DownLeft:
                        if (!Collide(MyBallData.X - 1, MyBallData.Y + 1))
                        {
                            MyBallData.X--;
                            MyBallData.Y++;
                        }
                        break;
                    case Direction.UpLeft:
                        if (!Collide(MyBallData.X - 1, MyBallData.Y - 1))
                        {
                            MyBallData.X--;
                            MyBallData.Y--;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public bool Collide(int x, int y)
        {
            // 벽 충돌 처리
            if (y == 0)
            {
                MyBallData.CurDirection = (Direction)WallCollision[0, (int)MyBallData.CurDirection];
                return true;
            }

            if (x == 1)
            {
                MyBallData.CurDirection = (Direction)WallCollision[1, (int)MyBallData.CurDirection];
                return true;
            }

            if (x == 77)
            {
                MyBallData.CurDirection = (Direction)WallCollision[2, (int)MyBallData.CurDirection];
                return true;
            }

            if (y == 23)
            {
                MyBallData.CurDirection = (Direction)WallCollision[3, (int)MyBallData.CurDirection];
                return true;
            }

            // Bar 충돌 처리
            if (x >= MyBar.MyBarData.Xs[0] && x <= MyBar.MyBarData.Xs[2] + 1 && 
                y == MyBar.MyBarData.Y) //바 위 충돌
            {
                if (MyBallData.CurDirection == Direction.UpRight)
                    MyBallData.CurDirection = Direction.DownRight;
                else if (MyBallData.CurDirection == Direction.DownRight)
                    MyBallData.CurDirection = Direction.UpRight;
                else if (MyBallData.CurDirection == Direction.UpLeft)
                    MyBallData.CurDirection = Direction.DownLeft;
                else if (MyBallData.CurDirection == Direction.DownLeft)
                    MyBallData.CurDirection = Direction.UpLeft;

                return true;
            }

            if (x >= MyBar.MyBarData.Xs[0] && x <= MyBar.MyBarData.Xs[2] + 1 &&
                y == MyBar.MyBarData.Y + 1) //바 아래 충돌
            {
                if (MyBallData.CurDirection == Direction.UpRight)
                    MyBallData.CurDirection = Direction.DownRight;
                else if (MyBallData.CurDirection == Direction.DownRight)
                    MyBallData.CurDirection = Direction.UpRight;
                else if (MyBallData.CurDirection == Direction.UpLeft)
                    MyBallData.CurDirection = Direction.DownLeft;
                else if (MyBallData.CurDirection == Direction.DownLeft)
                    MyBallData.CurDirection = Direction.UpLeft;

                return true;
            }

            // Brick 충돌 처리
            foreach (var brick in MyBricks)
            {
                if (!brick.IsAlive)
                {
                    continue;
                }

                if (x >= brick.Xs[0] && x <= brick.Xs[2] + 1 &&
                y == brick.Y) // 벽 위쪽 충돌
                {
                    if (MyBallData.CurDirection == Direction.UpRight)
                        MyBallData.CurDirection = Direction.DownRight;
                    else if (MyBallData.CurDirection == Direction.DownRight)
                        MyBallData.CurDirection = Direction.UpRight;
                    else if (MyBallData.CurDirection == Direction.UpLeft)
                        MyBallData.CurDirection = Direction.DownLeft;
                    else if (MyBallData.CurDirection == Direction.DownLeft)
                        MyBallData.CurDirection = Direction.UpLeft;

                    brick.IsAlive = false;
                    return true;
                }

                if (x >= brick.Xs[0] && x <= brick.Xs[2] + 1 &&
                y == brick.Y + 1) //벽 아래 충돌
                {
                    if (MyBallData.CurDirection == Direction.UpRight)
                        MyBallData.CurDirection = Direction.DownRight;
                    else if (MyBallData.CurDirection == Direction.DownRight)
                        MyBallData.CurDirection = Direction.UpRight;
                    else if (MyBallData.CurDirection == Direction.UpLeft)
                        MyBallData.CurDirection = Direction.DownLeft;
                    else if (MyBallData.CurDirection == Direction.DownLeft)
                        MyBallData.CurDirection = Direction.UpLeft;

                    brick.IsAlive = false;
                    return true;
                }
            }

            return false;
        }


        public void Render()
        {
            ScreenWall();
            Program.GotoXy(MyBallData.X, MyBallData.Y);
            Console.Write("●");
        }

        public void ScreenWall()
        {
            Program.GotoXy(0, 0);
            Console.Write("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            for (int i = 1; i < 23; i++)
            {
                Program.GotoXy(0, i);
                Console.Write("┃                                                                              ┃");
            }
            Program.GotoXy(0, 23);
            Console.Write("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
        }
    }
}
