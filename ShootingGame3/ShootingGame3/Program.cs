using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShootingGame3
{

    public class Bullet
    {
        public int X;
        public int Y;
        public bool IsFire;

        public Bullet()
        {
            Reset();
        }

        public void Reset()
        {
            X = 0;
            Y = 0;
            IsFire = false;
        }
    }

    public class Player
    {
        [DllImport("msvcrt.dll")]
        static extern int _getch();

        const int UP = 72;
        const int LEFT = 75;
        const int RIGHT = 77;
        const int DOWN = 80;
        const int SPACE_BAR = 32;

        public int X;
        public int Y;
        public List<List<Bullet>> Bullets = new List<List<Bullet>>();
        public int Score = 0;
        public Item BulletItem = new Item();
        public int ItemCount = 0;

        public Player()
        {
            X = 0;
            Y = 12;

            for(int i=0; i<3; i++)
            {
                var bulletGroup = new List<Bullet>();
                for(int j=0; j<20; j++)
                {
                    bulletGroup.Add(new Bullet());
                }
                Bullets.Add(bulletGroup);
            }
        }

        public void GameMain()
        {
            ControlKey();
            DrawPlayer();
            UIscore();
            HandleItem();
        }

        public void ControlKey()
        {
            int pressKey;

            if (Console.KeyAvailable)
            {
                pressKey = _getch();
                pressKey = (pressKey == 0 || pressKey == 224) ? _getch() : pressKey;

                switch (pressKey)
                {
                    case UP: Y = (Y > 1) ? Y - 1 : 1; break;
                    case LEFT: X = (X > 0) ? X - 1 : 0; break;
                    case RIGHT: X = (X < 75) ? X + 1 : 75; break;
                    case DOWN: Y = (Y < 22) ? Y + 1 : 22; break;
                    case SPACE_BAR: FireBullet(); break;
                }
            }
        }

        public void DrawPlayer()
        {
            var player = new string[]
            {
                "->",
                ">>>",
                "->"
            };

            for (int i = 0; i < player.Length; i++)
            {
                Console.SetCursorPosition(X, Y + i);
                Console.WriteLine(player[i]);
            }
        }

        public void FireBullet()
        {
            int[] bulletYOffsets = { 1, 0, 2 };
            for(int i=0; i<=ItemCount; i++)
            {
                foreach(var bullet in Bullets[i])
                {
                    if (!bullet.IsFire)
                    {
                        bullet.IsFire = true;
                        bullet.X = X + 5;
                        bullet.Y = Y + bulletYOffsets[i];
                        break;
                    }
                }
            }
        }

        public void DrawBullets()
        {
            string bulletShape = "->";
            foreach(var bulletGroup in Bullets)
            {
                foreach(var bullet in bulletGroup)
                {
                    if (bullet.IsFire)
                    {
                        Console.SetCursorPosition(bullet.X - 1, bullet.Y);
                        Console.Write(bulletShape);

                        bullet.X++;
                        bullet.IsFire = (bullet.X > 78) ? false : bullet.IsFire;
                    }
                }
            }
        }

        public void HandleCrash(Enemy enemy)
        {
            foreach(var bulletGroup in Bullets)
            {
                foreach(var bullet in bulletGroup)
                {
                    if (bullet.IsFire && bullet.Y == enemy.Y && Math.Abs(bullet.X - enemy.X) <= 1)
                    {
                        BulletItem.IsExist = true;
                        BulletItem.X = enemy.X;
                        BulletItem.Y = enemy.Y;
                        enemy.Respawn();
                        bullet.IsFire = false;
                        Score += 100;
                    }
                }
            }
        }

        public void HandleItem()
        {
            if (BulletItem.IsExist)
            {
                BulletItem.Move();
                BulletItem.Draw();
                CrashItem();
            }
        }

        public void CrashItem()
        {
            if (Y+1 == BulletItem.Y && Math.Abs(X - BulletItem.X) <= 2)
            {
                BulletItem.IsExist = false;
                ItemCount = (ItemCount < 2) ? ItemCount += 1 : ItemCount;
                foreach(var bulletGroup in Bullets)
                {
                    foreach(var bullet in bulletGroup)
                    {
                        bullet.Reset();
                    }
                }
            }
        }

        public void UIscore()
        {
            Console.SetCursorPosition(63, 0);
            Console.Write("┏━━━━━━━━━━━━━━┓");
            Console.SetCursorPosition(63, 1);
            Console.Write("┃              ┃");
            Console.SetCursorPosition(65, 1);
            Console.Write("Score : " + Score);
            Console.SetCursorPosition(63, 2);
            Console.Write("┗━━━━━━━━━━━━━━┛");
        }
    }

    public class Enemy
    {
        public int X = 77;
        public int Y = 12;
        private static Random Rand = new Random();

        public void DrawEnemy()
        {
            var enemy = "<-0->";
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(enemy);
        }

        public void Move()
        {
            X--;
            if (X < 2)
            {
                Respawn();
            }
        }

        public void Respawn()
        {
            X = 75;
            Y = Rand.Next(2, 22);
        }
    }

    public class Item
    {
        public int X = 0;
        public int Y = 0;
        public bool IsExist = false;

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("Item★");
        }

        public void Move() { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            var player = new Player();
            var enemy = new Enemy();
            var dwTime = Environment.TickCount; 

            while (true)
            {
                if (dwTime + 50 < Environment.TickCount)
                {
                    dwTime = Environment.TickCount;
                    Console.Clear();

                    player.GameMain();
                    player.DrawBullets();

                    enemy.Move();
                    enemy.DrawEnemy();

                    player.HandleCrash(enemy);
                }
            }
        }
    }
}
