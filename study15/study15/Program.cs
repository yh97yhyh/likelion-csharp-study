using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study15
{
    enum DayOfWeek
    {
        Sunday,    // 0
        Monday,    // 1
        Tuesday,   // 2
        Wednesday, // 3
        Thursday,  // 4
        Friday,    // 5
        Saturday   // 6
    }

    enum HttpStatus
    {
        OK = 200,
        Created = 201,
        Accepted = 202,
        NotFound = 404
    }

    enum Weapontype
    {
        Sword,
        Bow,
        Staff
    }

    class Program
    {
        static void Main(string[] args)
        {

            //var today = DayOfWeek.Thursday;
            //Console.WriteLine($"{today} ({(int)today})");

            //var status = HttpStatus.NotFound;
            //Console.WriteLine($"{status} ({(int)status})");

            var weapon = Weapontype.Bow;
            PrintWeapon(weapon);

            // Math 클래스
            //Console.WriteLine(Math.PI); // 3.14159265358979
            //Console.WriteLine(Math.Abs(-10));   // 10 (절댓값)
            //Console.WriteLine(Math.Max(5, 8));  // 8 (최댓값)
            //Console.WriteLine(Math.Min(5, 8));  // 5 (최솟값)
            //Console.WriteLine(Math.Pow(2, 3));  // 8 (2의 3제곱)
            //Console.WriteLine(Math.Sqrt(25));   // 5 (제곱근)
            //Console.WriteLine(Math.Round(3.6)); // 4 (반올림)
            //Console.WriteLine(Math.Ceiling(3.2)); // 4 (올림)
            //Console.WriteLine(Math.Floor(3.8));   // 3 (내림)
            //Console.WriteLine(Math.Truncate(3.9)); // 3 (소수점 제거)
            //Console.WriteLine(Math.Sin(Math.PI / 2)); // 1 (사인 함수)

        }


        static void PrintWeapon(Weapontype weapon)
        {
            switch (weapon)
            {
                case Weapontype.Sword:
                    Console.WriteLine("검을 선택했습니다");
                    break;
                case Weapontype.Bow:
                    Console.WriteLine("활을 선택했습니다");
                    break;
                case Weapontype.Staff:
                    Console.WriteLine("지팡이를 선택했습니다");
                    break;
            }
        }
    }
}
