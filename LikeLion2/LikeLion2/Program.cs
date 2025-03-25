using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeLion2
{
    class Program
    {
        static void Main(string[] args)
        {
            int age; // 정수형 변수
            age = 25; // 변수에 값 저장

            // Console.WriteLine(age); // 변수에 저장된 값을 출력

            // 리터럴: 코드에서 고정된 값을 의미
            int number = 10;
            double pi = 3.14;
            char letter = 'A';
            string name = "Alice";

            //Console.WriteLine(number);
            //Console.WriteLine(pi);
            //Console.WriteLine(letter);
            //Console.WriteLine($"number : {number}, pi : {pi}");
            //Console.WriteLine($"letter : {letter}, name : {name}");

            int hp = 100;
            double att = 56.7;
            string nickname = "닉네임뭐하지";
            char grade = 'S';
            Console.WriteLine($"캐릭터 정보 - {nickname}({grade}) 체력:{hp} 공격력:{att}");
        }
    }
}
