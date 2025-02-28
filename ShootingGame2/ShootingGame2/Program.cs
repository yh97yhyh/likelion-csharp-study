using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ShootingGame2
{
    public class Bullet
    {
        public int x;
        public int y;
        public bool isFire;
    }

    public class Player
    {
        [DllImport("msvcrt.dll")]
        static extern int _getch();  //c언어 함수 가져옴

        public int playerX;
        public int playerY;
        public Bullet[] playerBullet = new Bullet[20];
        public Bullet[] playerBullet2 = new Bullet[20];
        public Bullet[] playerBullet3 = new Bullet[20];
        public int Score = 100;
        public Item item = new Item();
        public int itemCount = 0;

        public Player()
        {
            playerX = 0;
            playerY = 12;

            for(int i=0; i<20; i++)
            {
                playerBullet[i] = new Bullet();
                playerBullet[i].x = 0;
                playerBullet[i].y = 0;
                playerBullet[i].isFire = false;

                playerBullet2[i] = new Bullet();
                playerBullet2[i].x = 0;
                playerBullet2[i].y = 0;
                playerBullet2[i].isFire = false;

                playerBullet3[i] = new Bullet();
                playerBullet3[i].x = 0;
                playerBullet3[i].y = 0;
                playerBullet3[i].isFire = false;
            }
        }

        public void GameMain()
        {
            KeyControl();
            DrawPlayer();
            UIscore();

            if(item.ItemLife)
            {
                item.MoveItem();
                item.DrawItem();
                CrashItem();
            }
        }

        public void KeyControl()
        {
            int pressKey;

            if (Console.KeyAvailable)
            {
                pressKey = _getch();
                if (pressKey == 0 || pressKey == 224) // 화살표 키 또는 특수 키 감지
                {
                    pressKey = _getch(); // 실제 키 값 읽기
                }

                switch (pressKey)
                {
                    case 72: // up  
                        playerY = (playerY > 1) ? playerY - 1 : 1;
                        break;
                    case 75: // left
                        playerX = (playerX > 0) ? playerX - 1 : 0;
                        break;
                    case 77: // right
                        playerX = (playerX < 75) ? playerX + 1 : 75;
                        break;
                    case 80: // down
                        playerY = (playerY < 22) ? playerY + 1 : 22;
                        break;
                    case 32: // spacebar
                        for (int i = 0; i < 20; i++)
                        {
                            if (!playerBullet[i].isFire)
                            {
                                playerBullet[i].isFire = true;
                                playerBullet[i].x = playerX + 5;
                                playerBullet[i].y = playerY + 1;
                                break;
                            }
                        }

                        for (int i = 0; i < 20; i++)
                        {
                            if (!playerBullet2[i].isFire)
                            {
                                playerBullet2[i].isFire = true;
                                playerBullet2[i].x = playerX + 5;
                                playerBullet2[i].y = playerY;
                                break;
                            }
                        }

                        for (int i = 0; i < 20; i++)
                        {
                            if (!playerBullet3[i].isFire)
                            {
                                playerBullet3[i].isFire = true;
                                playerBullet3[i].x = playerX + 5;
                                playerBullet3[i].y = playerY + 2;
                                break;
                            }
                        }
                        break;
                }

            }

        }

        public void DrawBullet()
        {
            string bullet = "->";

            for(int i=0; i<20; i++)
            {
                if (playerBullet[i].isFire)
                {
                    Console.SetCursorPosition(playerBullet[i].x - 1, playerBullet[i].y);
                    Console.Write(bullet);

                    playerBullet[i].x++; // 미사일 오른쪽으로 날라가게

                    if (playerBullet[i].x > 78)
                    {
                        playerBullet[i].isFire = false;
                    }
                }
            }
        }

        public void DrawBullet2()
        {
            string bullet = "->";

            for (int i = 0; i < 20; i++)
            {
                if (playerBullet2[i].isFire)
                {
                    Console.SetCursorPosition(playerBullet2[i].x - 1, playerBullet2[i].y);
                    Console.Write(bullet);

                    playerBullet2[i].x++; // 미사일 오른쪽으로 날라가게

                    if (playerBullet2[i].x > 78)
                    {
                        playerBullet2[i].isFire = false;
                    }
                }
            }
        }

        public void DrawBullet3()
        {
            string bullet = "->";

            for (int i = 0; i < 20; i++)
            {
                if (playerBullet3[i].isFire)
                {
                    Console.SetCursorPosition(playerBullet3[i].x - 1, playerBullet3[i].y);
                    Console.Write(bullet);

                    playerBullet3[i].x++; // 미사일 오른쪽으로 날라가게

                    if (playerBullet3[i].x > 78)
                    {
                        playerBullet3[i].isFire = false;
                    }
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

            for(int i=0; i<player.Length; i++)
            {
                Console.SetCursorPosition(playerX, playerY + i);
                Console.WriteLine(player[i]);
            }
        }

        public void ClashEnemyAndBullet(Enemy enemy)
        {
            for(int i=0; i<20; i++)
            {
                if (playerBullet[i].isFire)
                {
                    if (playerBullet[i].y == enemy.enemyY) // 미사일과 적의 y가 같을 때
                    {
                        if (playerBullet[i].x >= (enemy.enemyX - 1) && playerBullet[i].x <= (enemy.enemyX + 1)) // 충돌
                        {

                            item.ItemLife = true;
                            item.itemX = enemy.enemyX;
                            item.itemY = enemy.enemyY;

                            var rand = new Random();
                            enemy.enemyX = 75;
                            enemy.enemyY = rand.Next(2, 22);

                            playerBullet[i].isFire = false;

                            Score += 100;
                        }
                    }
                }
            }
        }

        public void ClashEnemyAndBullet2(Enemy enemy)
        {
            for (int i = 0; i < 20; i++)
            {
                if (playerBullet2[i].isFire)
                {
                    if (playerBullet2[i].y == enemy.enemyY) // 미사일과 적의 y가 같을 때
                    {
                        if (playerBullet2[i].x >= (enemy.enemyX - 1) && playerBullet2[i].x <= (enemy.enemyX + 1)) // 충돌
                        {
                            var rand = new Random();
                            enemy.enemyX = 75;
                            enemy.enemyY = rand.Next(2, 22);

                            playerBullet2[i].isFire = false;

                            Score += 100;
                        }
                    }
                }
            }
        }

        public void ClashEnemyAndBullet3(Enemy enemy)
        {
            for (int i = 0; i < 20; i++)
            {
                if (playerBullet3[i].isFire)
                {
                    if (playerBullet3[i].y == enemy.enemyY) // 미사일과 적의 y가 같을 때
                    {
                        if (playerBullet3[i].x >= (enemy.enemyX - 1) && playerBullet3[i].x <= (enemy.enemyX + 1)) // 충돌
                        {
                            var rand = new Random();
                            enemy.enemyX = 75;
                            enemy.enemyY = rand.Next(2, 22);

                            playerBullet3[i].isFire = false;

                            Score += 100;
                        }
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

        public void CrashItem()
        {
            if (playerY+1 == item.itemY)
            {
                if (playerX >= item.itemX-2 && playerX <= item.itemX+2)
                {
                    item.ItemLife = false;
                    if(itemCount < 3)
                    {
                        itemCount++;
                    }

                    for (int i = 0; i < 20; i++)
                    {
                        playerBullet[i] = new Bullet();
                        playerBullet[i].x = 0;
                        playerBullet[i].y = 0;
                        playerBullet[i].isFire = false;

                        playerBullet2[i] = new Bullet();
                        playerBullet2[i].x = 0;
                        playerBullet2[i].y = 0;
                        playerBullet2[i].isFire = false;

                        playerBullet3[i] = new Bullet();
                        playerBullet3[i].x = 0;
                        playerBullet3[i].y = 0;
                        playerBullet3[i].isFire = false;
                    }
                }
            }
        }
    }

    public class Enemy
    {
        public int enemyX;
        public int enemyY;

        public Enemy()
        {
            enemyX = 77;
            enemyY = 12;
        }

        public void DrawEnemy()
        {
            var enemy = "<-0->";
            Console.SetCursorPosition(enemyX, enemyY);
            Console.WriteLine(enemy);
        }

        public void MoveEnemy()
        {
            var rand = new Random();
            enemyX--;

            if (enemyX < 2)
            {
                enemyX = 75;
                enemyY = rand.Next(2, 22);
            }
        }
    }

    public class Item
    {
        public string ItemName;
        public string ItemSprite;
        public int itemX = 0;
        public int itemY = 0;
        public bool ItemLife = false;

        public void DrawItem()
        {
            Console.SetCursorPosition(itemX, itemY);
            ItemSprite = "Item★";
            Console.Write(ItemSprite);
        }

        public void MoveItem()
        {
            //if (itemX <= 1 || itemY <= 1)
            //{
            //    ItemLife = false;
            //}
        }
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

            int dwTime = Environment.TickCount; // 프레임속도 (1/1000초가 흐른다)
            
            while(true)
            {
                // 0.05초 지연
                if (dwTime + 50 < Environment.TickCount)
                {
                    dwTime = Environment.TickCount;
                    Console.Clear();

                    if (player.itemCount == 0)
                    {
                        player.DrawBullet();
                    }
                    else if (player.itemCount == 1)
                    {
                        player.DrawBullet();
                        player.DrawBullet2();
                    }
                    else
                    {
                        player.DrawBullet();
                        player.DrawBullet2();
                        player.DrawBullet3();
                    }

                    player.GameMain();
                    player.DrawBullet();

                    enemy.MoveEnemy();
                    enemy.DrawEnemy();

                    player.ClashEnemyAndBullet(enemy);
                    player.ClashEnemyAndBullet2(enemy);
                    player.ClashEnemyAndBullet3(enemy);
                }
            }
        }
    }
}
