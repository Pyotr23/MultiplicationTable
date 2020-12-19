using System;
using System.Collections.Generic;
using System.Threading;

namespace MultiplicationTable
{

    public class Program
    {
        private const int RightAnswearsCount = 15;
        private const int TimeForAnswearImMillis = 5000;
        private static int _exampleCounter = 0;

        static void Main()
        {            
            do
            {
                var example = ExampleCreator.Create();                
                Console.Write(example.ToStringWithoutAnswear());
                CheckUserAnswear(example);
            }
            while (_exampleCounter != RightAnswearsCount);

            Console.WriteLine("Победа!");
            Console.ReadKey();
        }

        private static void CheckUserAnswear(Example example)
        {
            var res = Reader.ReadLine(TimeForAnswearImMillis);
            if (int.TryParse(res, out int userAnswear) && userAnswear == example.RightAnswear)
            {
                _exampleCounter++;
                Console.WriteLine($"Правильно! Ещё нужно {RightAnswearsCount - _exampleCounter} правильных ответов.");
                return;
            }

            _exampleCounter = 0;
            ExampleCreator.Clear();

            if (res == null)
            {
                Console.WriteLine($"\nВремя вышло! {example}");
                return;
            }

            Console.WriteLine($"Ошибка! {example}");
        }
    }

    public class Reader
    {
        private static readonly AutoResetEvent _getInput;
        private static readonly AutoResetEvent _gotInput;
        private static string _input;

        static Reader()
        {
            _getInput = new AutoResetEvent(false);
            _gotInput = new AutoResetEvent(false);
            var thread = new Thread(Read)
            {
                IsBackground = true
            };
            thread.Start();
        }

        private static void Read()
        {
            while (true)
            {
                _getInput.WaitOne();
                _input = Console.ReadLine();
                _gotInput.Set();
            }
        }

        public static string ReadLine(int timeOutMillisecs = Timeout.Infinite)
        {
            _getInput.Set();
            return _gotInput.WaitOne(timeOutMillisecs)
                ? _input
                : null;
        }
    }
}
