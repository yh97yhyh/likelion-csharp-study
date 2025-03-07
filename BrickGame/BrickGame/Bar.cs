using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickGame
{
    class Bar
    {
        public BarData MyBarData = new BarData();
        public int m_nCatch; //공을 잡았는지 체크

        const int LEFTKEY = 75; // 상수로 만들어준다.  변수에 값 대입 x

        public Bar()
        {
            m_nCatch = 0;

            MyBarData.Y = 18;
            MyBarData.Xs[0] = 12;
            MyBarData.Xs[1] = 14;
            MyBarData.Xs[2] = 16;
        }

        //공의 객체를 가지고와서 잡았는지 판단, 움직임
        public void Progress(Ball ball)
        {
            int input = 0;

            if (Console.KeyAvailable)
            {
                input = Program._getch(); //키눌림 값

                switch (input)
                {
                    case LEFTKEY: //왼쪽 
                        MyBarData.Xs[0]--;
                        MyBarData.Xs[1]--;
                        MyBarData.Xs[2]--;

                        if (ball.MyBallData.IsReady && m_nCatch == 1)
                        {
                            //공이 잡힌상태
                            ball.MyBallData.X -= 1; //공왼쪽으로 움직이게 값주기
                        }

                        break;
                    case 77:
                        MyBarData.Xs[0]++;
                        MyBarData.Xs[1]++;
                        MyBarData.Xs[2]++;

                        if (ball.MyBallData.IsReady && m_nCatch == 1)
                        {
                            //공이 잡힌상태
                            ball.MyBallData.X = 1;//공오른쪽으로 움직이게 값주기
                        }
                        break;
                    case 'a':
                        ball.MyBallData.IsReady = false; //공이움직임 
                        m_nCatch = 0;
                        break;
                    case 's':
                        if (ball.MyBallData.X >= MyBarData.Xs[0] &&
                            ball.MyBallData.X <= MyBarData.Xs[2] + 1 &&
                            ball.MyBallData.Y == (MyBarData.Y - 1))
                        {
                            ball.MyBallData.IsReady = true;
                            m_nCatch = 1;
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
        public void Release()
        { }

    }

}
