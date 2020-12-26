using MultiplicationTable.MathExample.Models;
using System;

namespace MultiplicationTable
{

    public class Program
    {        
        private static int _exampleCounter = 0;
        private static readonly DurationMeter _durationMeter = new DurationMeter();
        private static IExampleStorage _exampleStorage;

        static void Main()
        {
            _exampleStorage = new MixedExampleStorage();            
            do
            {
                var example = _exampleStorage.CreateExample();                
                Console.Write(example.ToStringWithoutAnswear());
                CheckUserAnswear(example);
            }
            while (_exampleCounter != Constants.RightAnswearsCount);

            Console.WriteLine("Победа!");
            Console.ReadKey();
        }

        private static void CheckUserAnswear(Example example)
        {
            static string operation() => ConsoleReader.ReadLine(Constants.TimeForAnswearInMillis);
            var measure = _durationMeter.Measure(operation);
            if (int.TryParse(measure.OperationResult, out int userAnswear) && userAnswear == example.RightAnswear)
            {
                _exampleCounter++;
                Console.WriteLine($"Правильно! Ещё нужно {Constants.RightAnswearsCount - _exampleCounter} правильных ответов.");
                return;
            }

            _exampleCounter = 0;
            _exampleStorage.Clear();

            if (measure.OperationResult == null)
            {
                Console.WriteLine($"\nВремя вышло! {example}");
                return;
            }

            Console.WriteLine($"Ошибка! {example}");
        }
    }
}
