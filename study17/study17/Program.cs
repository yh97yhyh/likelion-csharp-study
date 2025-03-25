using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study17
{
    public struct Student
    {
        public string Name { get; private set; }
        public int KoreanScore { get; private set; }
        public int EnglishScore { get; private set; }
        public int MathScore { get; private set; }

        public Student(string name, int koreanScore, int englishScore, int mathScore)
        {
            Name = name;
            KoreanScore = koreanScore;
            EnglishScore = englishScore;
            MathScore = mathScore;
        }

        public void Print()
        {
            Console.WriteLine($"{Name}\t{KoreanScore}\t{EnglishScore}\t{MathScore}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>();
            var st1 = new Student("홍길동", 100, 80, 70);
            var st2 = new Student("홍길란", 90, 10, 20);
            var st3 = new Student("홍길순", 20, 55, 70);
            students.Add(st1);
            students.Add(st2);
            students.Add(st3);

            Console.WriteLine("이름\t국어\t영어\t수학");
            foreach (var student in students)
            {
                student.Print();
            }

        }
    }
}
