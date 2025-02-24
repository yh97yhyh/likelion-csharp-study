using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TodayTesk1
{
    class Program
    {
        static void Main(string[] args)
        {

            const int TOTAL = 10;
            for (int i = 0; i <= TOTAL; i++)
            {
                Console.Clear();
                string process = new string('■', i);
                string remain = new string('□', TOTAL - i);
                Console.WriteLine(process + remain);
                Thread.Sleep(1000);
            }

            Console.Clear();

            string[] texts = {캡처도구 녹화 안됨
                "엔터를 치면 이야기가 시작됩니다.",
                "당신은 유명한 탐정으로, 어느 날 의문의 편지를 받습니다.",
                "그 편지는 여러 탐정들을 초대하는 초대장이었습니다.",
                "하지만 이곳은 단순한 탐정들의 모임이 아닙니다.",
                "한 명씩 사라져가는 탐정들, 그리고 그 뒤에 감춰진 진실이 있습니다.",
                "범인을 밝혀내고 저택에서 살아남기 위해 당신의 지혜가 필요합니다.",
                "모험의 첫 발을 내딛으시겠습니까?"
            };

            foreach (string text in texts)
            {
                Console.WriteLine(text);
                Console.ReadLine();
                Console.Clear();
            }

        }
    }
}
