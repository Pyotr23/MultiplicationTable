using MultiplicationTable.MathExample.Models;
using System;

namespace MultiplicationTable
{

    public class Program
    {        
        private static int _exampleCounter = 0;
        private static readonly DurationMeter _durationMeter = new DurationMeter();
        private static ExampleCreator _exampleCreator;

        static void Main()
        {
            _exampleCreator = new ExampleCreator(Operator.Multiply);
            do
            {
                var example = _exampleCreator.Create();                
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
            _exampleCreator.ClearStorage();

            if (measure.OperationResult == null)
            {
                Console.WriteLine($"\nВремя вышло! {example}");
                return;
            }

            Console.WriteLine($"Ошибка! {example}");
        }
    }
}
