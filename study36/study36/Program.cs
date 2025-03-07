using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study36
{
    class Program
    {
        delegate void MessageHandler(string message);

        static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        static void DisplayUpperMessage(string message) 
        {
            Console.WriteLine(message.ToUpper());
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== 간단한 델리게이트와 이벤트 예제 ===");

            Console.WriteLine("1. 델리게이트");
            var messageHandler = new MessageHandler(DisplayMessage);
            messageHandler("Hello, World!");
            Console.WriteLine();

            Console.WriteLine("2. 메서드 체인(멀티캐스트 델리게이트)");
            messageHandler += DisplayUpperMessage;
            messageHandler("Hello, World!");

        }
    }
}
