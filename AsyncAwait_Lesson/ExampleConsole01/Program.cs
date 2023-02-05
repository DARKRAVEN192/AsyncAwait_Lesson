using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ExampleConsole01
{
    class Program
    {
        static void Main(string[] args)
        {
            //AsyncMath();

            //AsyncWriteBook(); 
            Task task = AsyncAdd();
            Console.ReadLine();
        }

        static void SyncMath()
        {
            Math();
        }
        
        static async Task AsyncMath()
        {
            await Task.Run(Math);
            Console.WriteLine("я все сделал");
        }

        static void Math()
        {
            Console.WriteLine("Start counting");
            Thread.Sleep(5000);
            Console.WriteLine("counting finished");
        }
        static async Task<int> AsyncAdd()
        {
            int a = 12;
            int b = 13;
            int res = await Task.Run(() => Add(a, b));
            return res;
        }
        static int Add(int a, int b)
        {
            Console.WriteLine("Start Adding");
            Thread.Sleep(5000);
            Console.WriteLine("Adding finished");
            return a + b;
        }
        static async Task AsyncWriteBook()
        {
            string text = "Мое приключение начинается здесь, в лаборатории приключений. " +
                "Что меня ждет? Надеюсь не стрела в колене";
            await Task.Run(() => WriteBook(text));

            Console.WriteLine("Я написал книгу");
        }
        static void WriteBook(string text)
        {
            Console.WriteLine("Start Writing");
            Thread.Sleep(5000);
            Console.WriteLine("writing finished");
            Console.WriteLine($"Text: {text}");
        }
    }
}
