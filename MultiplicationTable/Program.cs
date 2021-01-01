using MultiplicationTable.MathExample.Models;
using System;
using System.Linq;

namespace MultiplicationTable
{

    public class Program
    {        
        private static int _exampleCounter = 0;
        private static readonly DurationMeter _durationMeter = new DurationMeter();
        private static IExampleCreator _exampleCreator;

        static void Main()
        {
            ChooseMode();

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

        

        private static void ChooseMode()
        {
            bool isModeSelectionOver;
            do
            {
                isModeSelectionOver = true;
                Console.WriteLine("Выберите тип примеров:");
                Console.WriteLine("\t0 - умножение\n\t1 - деление\n\t2 - и умножение, и деление");
                var readKey = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (readKey)
                {
                    case '0':
                        _exampleCreator = new MultiplyExampleCreator();
                        break;
                    case '1':
                        _exampleCreator = new DivisionExampleCreator();
                        break;
                    case '2':
                        _exampleCreator = new MixedExampleCreator();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Тип примеров не выбран.");
                        isModeSelectionOver = false;
                        break;
                }
            }
            while (!isModeSelectionOver);
            Console.Clear();
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
