using System;
using System.Threading;

namespace MultiplicationTable
{

    public class Program
    {
        private const int RightAnswearsCount = 15;
        private static int TimeForAnswearImMillis = 5000;
        private static readonly Random _random = new Random();

        static void Main(string[] args)
        {            
            var counter = 0;
            do
            {
                var firstDigit = _random.Next(2, 10);
                var secondDigit = _random.Next(2, 10);
                var rightAnswear = firstDigit * secondDigit;
                var message = $"{firstDigit} * {secondDigit} = ";
                Console.Write(message);

                var res = Reader.ReadLine(TimeForAnswearImMillis);
                Console.WriteLine(res);
                if (int.TryParse(res, out int userAnswear) && userAnswear == rightAnswear)
                {
                    counter++;
                    Console.WriteLine($"Правильно! Ещё нужно {RightAnswearsCount - counter} правильных ответов.");
                    continue;
                }  
                
                counter = 0;
                var fullAnswear = $"{firstDigit} * {secondDigit} = {rightAnswear}";

                if (res == null)
                {
                    Console.WriteLine($"\nВремя вышло! {fullAnswear}");
                    continue;
                }
                                      
                Console.WriteLine($"Ошибка! {fullAnswear}");
            }
            while (counter != RightAnswearsCount);

            Console.WriteLine("Победа!");
            Console.ReadKey();
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
