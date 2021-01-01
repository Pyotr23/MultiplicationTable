using MultiplicationTable.MathExample.Models;
using System;

namespace MultiplicationTable
{

    public class Program
    {        
        private static int _exampleCounter = 0;
        private static readonly DurationMeter _durationMeter = new DurationMeter();
        private static IExampleCreator _exampleCreator;

        static void Main()
        {
            _exampleCreator = new MixedExampleCreator();            
            do
            {
                var example = GetExampleWithValue();                           
                Console.Write(example.ToStringWithoutAnswear());
                CheckUserAnswear(example);
            }
            while (_exampleCounter != Constants.RightAnswearsCount);

            Console.WriteLine("Победа!");
            Console.ReadKey();
        }

        /// <summary>
        ///     Получить сформированный пример. 
        /// </summary>
        /// <returns> Непустой пример </returns>
        private static Example GetExampleWithValue()
        {
            Example example;
            do
            {
                example = _exampleCreator.CreateExample();
            }
            while (example == null);

            return example;
        }

        /// <summary>
        ///     Проверить ответ пользователя на пример.
        /// </summary>
        /// <param name="example"> Пример </param>
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
            _exampleCreator.Clear();

            if (measure.OperationResult == null)
            {
                Console.WriteLine($"\nВремя вышло! {example}");
                return;
            }

            Console.WriteLine($"Ошибка! {example}");
        }
    }
}
