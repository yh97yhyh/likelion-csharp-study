using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TypingGame
{
    public class Item
    {
        public string Setence;
        public int X;
        public int Y;
        public bool IsClear;

        public Item()
        {
            Reset();
        }

        public Item(string sentence, int x, int y)
        {
            Setence = sentence;
            X = x;
            Y = y;
            IsClear = false;
        }

        public void Reset()
        {
            Setence = "";
            X = 0;
            Y = 0;
            IsClear = false;
        }
    }
    class Game
    {
        const int SENTENCES_COUNT = 30;
        const int GROUND_Y = 23;
        const int SKY_Y = 3;

        public List<Item> Items = new List<Item>();
        public int Score;
        public string UserInput;
        private static Random Rand = new Random();

        public Game()
        {
            SetItems();
            Score = 0;
            UserInput = "";
        }

        private void SetItems()
        {
            var setnences = SetSentences();
            var y = SKY_Y;
            foreach (var sentence in setnences)
            {
                var x = Rand.Next(0, 80 - sentence.Length);
                var sen = new Item(sentence, x, y);
                Items.Add(sen);
                y -= 4;
            }
        }

        public void GameMain()
        {
            DrawItems();
            DrawUI();
            CheckGameOver();
        }

        public void DrawItems()
        {
            foreach(var item in Items)
            {
                if ((item.Y >= SKY_Y && item.Y < GROUND_Y) && !item.IsClear)  
                {
                    Console.SetCursorPosition(item.X, item.Y);
                    Console.WriteLine(item.Setence);
                }
                item.Y++;
            }
        }

        //public async Task GetUserInputAsync()
        //{
        //    Console.SetCursorPosition(0, GROUND_Y + 1);
        //    //Console.Write("Enter a sentence 👉 ");
        //    //Console.SetCursorPosition(25, GROUND_Y + 1);
        //    UserInput = await Task.Run(() => Console.ReadLine());
        //    CheckClear();
        //}

        public async Task GetUserInputAsync()
        {
            Console.SetCursorPosition(0, GROUND_Y + 1);

            while (true)
            {
                var keyInfo = await Task.Run(() => Console.ReadKey(true));

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    UserInput += keyInfo.KeyChar;
                    Console.SetCursorPosition(UserInput.Length, GROUND_Y + 1);
                    Console.Write(keyInfo.KeyChar);
                }
                //else if (keyInfo.Key == ConsoleKey.Backspace && UserInput.Length > 0)
                //{
                //    UserInput = UserInput.Substring(0, UserInput.Length - 1);
                //    Console.SetCursorPosition(UserInput.Length, GROUND_Y + 1);
                //    Console.Write(new string(' ', Console.WindowWidth));
                //    Console.SetCursorPosition(UserInput.Length, GROUND_Y + 1);
                //    Console.Write(UserInput);
                //}
            }

            CheckClear();
        }



        public void CheckClear()
        {
            Console.SetCursorPosition(0, GROUND_Y + 1);
            Console.Write(new string(' ', Console.WindowWidth));

            foreach (var item in Items)
            {
                if (item.Y >= SKY_Y && UserInput == item.Setence)
                {
                    item.IsClear = true;
                    Score += 1;
                    break;
                }
            }

            UserInput = "";
        }

        public void CheckGameOver()
        {
            var isGameOver = false;

            if (Score >= Items.Count)
            {
                GameClear();
            }

            foreach (var item in Items)
            {
                if (item.Y >= GROUND_Y && !item.IsClear)
                {
                    isGameOver = true;
                    break;
                }
            }

            if (isGameOver)
            {
                GameOver();
            }
        }

        public void DrawUI()
        {
            Console.SetCursorPosition(60, 0);
            Console.Write("┏━━━━━━━━━━━━━━━━━━┓");
            Console.SetCursorPosition(60, 1);
            Console.Write("┃                  ┃");
            Console.SetCursorPosition(62, 1);
            Console.Write($"🔥 Score : {Score}/{Items.Count}");
            Console.SetCursorPosition(60, 2);
            Console.Write("┗━━━━━━━━━━━━━━━━━━┛");

            Console.SetCursorPosition(0, 23);
            Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
        }

        public void Clear()
        {
            for (int y = 0; y < GROUND_Y; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write(new string(' ', Console.WindowWidth));
            }
        }

        private void GameOver()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);

            Console.Write("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            for (int j = 1; j <= 10; j++)
            {
                if (j == 5)
                {
                    Console.SetCursorPosition(0, j);
                    Console.Write($"┃                             😵‍💫   Game Over   😢                           ┃");
                    continue;
                }
                Console.SetCursorPosition(0, j);
                Console.Write("┃                                                                              ┃");
            }
            Console.Write("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");

            Environment.Exit(0);
        }

        private void GameClear()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);

            Console.Write("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            for (int j = 1; j <= 10; j++)
            {
                if (j == 5)
                {
                    Console.SetCursorPosition(0, j);
                    Console.Write($"┃                              🌟   Game Clear!  🥳                            ┃");
                    continue;
                }
                Console.SetCursorPosition(0, j);
                Console.Write("┃                                                                              ┃");
            }
            Console.Write("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");

            Environment.Exit(0);
        }

        private List<string> SetSentences()
        {
            List<string> sentences = new List<string>
            {
                "Hello, how are you?",
                "Welcome to the typing game!",
                "Type as fast as you can.",
                "The quick brown fox jumps over the lazy dog.",
                "This is a typing speed test.",
                "How fast can you type?",
                "Practice makes perfect.",
                "Typing is a useful skill.",
                "The rain in Spain falls mainly on the plain.",
                "She sells seashells by the seashore.",
                //"A quick movement of the enemy will jeopardize six gunboats.",
                //"Jackdaws love my big sphinx of quartz.",
                //"I wish to wish the wish you wish to wish.",
                //"The five boxing wizards jump quickly.",
                //"Mr Jock, TV quiz PhD, bags few lynx.",
                //"Waltz, nymph, for quick jigs vex Bud.",
                //"The wizard quickly jinxed the gnomes before they vaporized.",
                //"Gazing at the vast sky, you think of flying.",
                //"A brown dog jumped over the wall.",
                //"The sun sets in the west.",
                //"Sly foxes jump over lazy dogs.",
                //"The mountains look beautiful at sunset.",
                //"The stars are shining brightly tonight.",
                //"Learning new things is always exciting.",
                //"The river flows quietly through the valley.",
                //"Reading books can expand your mind.",
                //"Music brings joy to our lives.",
                //"Hiking up the hill is a great way to stay healthy.",
                //"A peaceful mind leads to a happy life.",
                //"Inspiration can strike at any time."
            };

            return sentences;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.CursorVisible = false;
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            var game = new Game();
            var dwTime = Environment.TickCount;

            var inputTask = game.GetUserInputAsync();

            Console.Clear();
            SplashGame();

            while (true)
            {
                if (dwTime + 1000 < Environment.TickCount)
                {
                    dwTime = Environment.TickCount;
                    game.Clear();

                    game.GameMain();
                }

                if (inputTask.IsCompleted)
                {
                    inputTask = game.GetUserInputAsync();
                }
            }
        }

        static void SplashGame()
        {
            var cnt = 0;
            while (true)
            {
                Console.Write("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                for (int j = 1; j <= 10; j++)
                {
                    var emoji = (cnt % 2 == 0) ? "💙" : "💛";
                    if (j == 5)
                    {
                        Console.SetCursorPosition(0, j);
                        Console.Write($"┃                              {emoji}   Typing Game   {emoji}                           ┃");
                        continue;
                    }
                    Console.SetCursorPosition(0, j);
                    Console.Write("┃                                                                              ┃");
                }
                Console.Write("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");

                Console.SetCursorPosition(15, 15);
                Console.Write("┏━━━━━━━━━━━━━━━━━━━━┓");
                Console.SetCursorPosition(15, 16);
                Console.Write("┃ Enter : 게임 시작  ┃");
                Console.SetCursorPosition(15, 17);
                Console.Write("┗━━━━━━━━━━━━━━━━━━━━┛");

                Console.SetCursorPosition(50, 15);
                Console.Write("┏━━━━━━━━━━━━━━━━━━┓");
                Console.SetCursorPosition(50, 16);
                Console.Write("┃ Esc : 게임 종료  ┃");
                Console.SetCursorPosition(50, 17);
                Console.Write("┗━━━━━━━━━━━━━━━━━━┛");

                if (Console.KeyAvailable)
                {
                    var keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        Environment.Exit(0);
                    }
                }

                Thread.Sleep(300);
                Console.Clear();
                cnt++;
            }
        }
    }
}