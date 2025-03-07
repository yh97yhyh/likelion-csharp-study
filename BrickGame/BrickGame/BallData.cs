using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickGame
{
    enum Direction
    {
        Up = 0,
        UpRight = 1,
        DownRight = 2,
        Down = 3,
        DownLeft = 4,
        UpLeft = 5
    }

    class BallData
    {
        public bool IsReady { get; set; } // 움직임 false 안움직임 true
        public Direction Direct { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
