using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
            //IsVisible = false;
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
                y -= 3;
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
                if (item.Y >= SKY_Y && item.Y < GROUND_Y)  
                {
                    Console.SetCursorPosition(item.X, item.Y);
                    Console.WriteLine(item.Setence);
                }
                item.Y++;
            }
        }

        public void GetUserInput()
        {
            Console.SetCursorPosition(0, GROUND_Y + 1);
            UserInput = Console.ReadLine();
        }


        public void CheckClear()
        {
            foreach (var item in Items)
            {
                if (item.Y >= SKY_Y && UserInput == item.Setence)
                {
                    item.IsClear = true;
                    Score += 100;
                    break;
                }
            }
        }

        public void CheckGameOver()
        {
            var isGameOver = false;

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
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("게임 종료!");
                Environment.Exit(0);
            }
        }

        public void DrawUI()
        {
            Console.SetCursorPosition(63, 0);
            Console.Write("┏━━━━━━━━━━━━━━┓");
            Console.SetCursorPosition(63, 1);
            Console.Write("┃              ┃");
            Console.SetCursorPosition(65, 1);
            Console.Write("Score : " + Score);
            Console.SetCursorPosition(63, 2);
            Console.Write("┗━━━━━━━━━━━━━━┛");

            Console.SetCursorPosition(0, 23);
            Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
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
                "A quick movement of the enemy will jeopardize six gunboats.",
                "Jackdaws love my big sphinx of quartz.",
                "I wish to wish the wish you wish to wish.",
                "The five boxing wizards jump quickly.",
                "Mr Jock, TV quiz PhD, bags few lynx.",
                "Waltz, nymph, for quick jigs vex Bud.",
                "The wizard quickly jinxed the gnomes before they vaporized.",
                "Gazing at the vast sky, you think of flying.",
                "A brown dog jumped over the wall.",
                "The sun sets in the west.",
                "Sly foxes jump over lazy dogs.",
                "The mountains look beautiful at sunset.",
                "The stars are shining brightly tonight.",
                "Learning new things is always exciting.",
                "The river flows quietly through the valley.",
                "Reading books can expand your mind.",
                "Music brings joy to our lives.",
                "Hiking up the hill is a great way to stay healthy.",
                "A peaceful mind leads to a happy life.",
                "Inspiration can strike at any time."
            };

            return sentences;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            var game = new Game();
            var dwTime = Environment.TickCount;

            while (true)
            {
                if (dwTime + 1000 >= Environment.TickCount)
                {
                    continue;
                }

                dwTime = Environment.TickCount;
                Console.Clear();

                game.GameMain();
            }
        }
    }
}