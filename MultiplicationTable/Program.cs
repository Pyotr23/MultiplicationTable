using MultiplicationTable.Duration;
using MultiplicationTable.MathExample.Creators;
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
            SetExampleCreator(GetModeNumber());

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
        ///     Получить цифру, обозначающую режим проверки знаний.
        /// </summary>
        /// <returns> Введённый пользователем режим. </returns>
        private static char GetModeNumber()
        {
            char readKey;
            do
            {
                Console.WriteLine("Выберите тип примеров:");
                var creatorDescriptions = Constants
                    .ExampleCreators
                    .Select(cr => cr.Description);
                var stringCreators = string.Join("\n", creatorDescriptions);
                Console.WriteLine(stringCreators);
                readKey = Console.ReadKey().KeyChar;
                Console.WriteLine();
                _exampleCreator = Constants
                    .ExampleCreators
                    .FirstOrDefault(cr => cr.Code == readKey);                
                Console.Clear();
                if (_exampleCreator == null)
                    Console.WriteLine("Тип примеров не выбран.");
            }
            while (_exampleCreator == null);
           
            return readKey;
        }

        /// <summary>
        ///     Установить конкретный класс, который будет создавать примеры.
        /// </summary>
        /// <param name="mode"></param>
        private static void SetExampleCreator(char mode)
        {
            switch (mode)
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
            }
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
