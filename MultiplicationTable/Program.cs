using MultiplicationTable.Duration;
using MultiplicationTable.MathExample.Creators;
using MultiplicationTable.MathExample.Models;
using System;

namespace MultiplicationTable
{

    public class Program
    {        
        /// <summary>
        ///     Счётчик примеров.
        /// </summary>
        private static int _exampleCounter = 0;

        /// <summary>
        ///     Измеритель длительности метода.
        /// </summary>
        private static readonly DurationMeter _durationMeter = new DurationMeter();

        /// <summary>
        ///     Класс, создающий определённые примеры.
        /// </summary>
        private static IExampleCreator _exampleCreator;

        static void Main()
        {
            SetExampleCreatorByCode();

            do
            {
                var example = GetExampleWithValue();
                Console.Write(example.ToStringWithoutAnswer());
                CheckUserAnswer(example);
            }
            while (_exampleCounter != Constants.RightAnswersCount);

            Console.WriteLine("Победа!");
            Console.ReadKey();
        }

        /// <summary>
        ///     Установить по введённому пользователем символу класс, который будет создавать примеры.
        /// </summary>
        private static void SetExampleCreatorByCode()
        {
            do
            {
                Console.WriteLine("Выберите тип примеров:");

                var stringWithCreatorDescriptions = Constants
                    .ExampleCreators
                    .GetStringWithDescriptions();
                Console.WriteLine(stringWithCreatorDescriptions);

                char readKey = Console.ReadKey().KeyChar;
                Console.WriteLine();

                _exampleCreator = Constants
                    .ExampleCreators
                    .GetExampleCreator(readKey);                
                Console.Clear();
                if (_exampleCreator == null)
                    Console.WriteLine("Тип примеров не выбран.");
            }
            while (_exampleCreator == null);           
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
        private static void CheckUserAnswer(Example example)
        {
            static string operation() => ConsoleReader.ReadLine(Constants.TimeForAnswerInMillis);
            var measure = _durationMeter.Measure(operation);
            if (int.TryParse(measure.OperationResult, out int userAnswer) && userAnswer == example.RightAnswer)
            {
                _exampleCounter++;
                Console.WriteLine($"Правильно! Ещё нужно {Constants.RightAnswersCount - _exampleCounter} правильных ответов.");
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
