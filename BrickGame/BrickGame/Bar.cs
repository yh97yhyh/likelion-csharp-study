using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickGame
{
    class Bar
    {
        public BarData MyBarData { get; set; }
        public bool IsCatch { get; set; }// 공을 잡았는지 체크

        const int LEFT_KEY = 75; // 상수로 만들어준다.변수에 값 대입 x
        const int RIGHT_KEY = 77;

        public Bar()
        {
            MyBarData = new BarData();
            IsCatch = false; // 초기값 false로 설정

            MyBarData.Y = 18;
            MyBarData.Xs[0] = 12;
            MyBarData.Xs[1] = 14;
            MyBarData.Xs[2] = 16;
        }

        // 공의 객체를 가지고와서 잡았는지 판단, 움직임
        public void Progress(Ball ball)
        {
            int input = 0;

            if (Console.KeyAvailable)
            {
                input = Program._getch(); // 키눌림 값
                if (input == 0 || input == 224) // 화살표 키 또는 특수 키 감지
                {
                    input = Program._getch(); // 실제 키 값 읽기
                }

                switch (input)
                {
                    case LEFT_KEY:
                        if (MyBarData.Xs[0] > 1)
                        {
                            MyBarData.Xs[0]--;
                            MyBarData.Xs[1]--;
                            MyBarData.Xs[2]--;
                        }

                        if (ball.MyBallData.IsReady && IsCatch)
                        {
                            // 공이 잡힌 상태
                            ball.MyBallData.X -= 1; // 공 왼쪽으로 움직이게 값 주기
                        }

                        break;
                    case RIGHT_KEY:
                        if (MyBarData.Xs[2] + 1 < 79)
                        {
                            MyBarData.Xs[0]++;
                            MyBarData.Xs[1]++;
                            MyBarData.Xs[2]++;
                        }

                        if (ball.MyBallData.IsReady && IsCatch)
                        {
                            // 공이 잡힌 상태
                            ball.MyBallData.X += 1; // 공 오른쪽으로 움직이게 값 주기
                        }
                        break;
                    case 'a':
                        ball.MyBallData.IsReady = false; // 공이 움직임 
                        IsCatch = false; // 공을 놓음
                        break;
                    case 's':
                        if (ball.MyBallData.X >= MyBarData.Xs[0] &&
                            ball.MyBallData.X <= MyBarData.Xs[2] + 1 &&
                            ball.MyBallData.Y == (MyBarData.Y - 1))
                        {
                            ball.MyBallData.IsReady = true;
                            IsCatch = true; // 공을 잡음
                        }
                        break;
                }
            }
        }

        public void Render()
        {
            for (int i = 0; i < 3; i++)
            {
                Program.GotoXy(MyBarData.Xs[i], MyBarData.Y);
                Console.Write("▥");
            }
        }

    }
}
