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
                Console.Write(example.ToStringWithoutAnswear());
                CheckUserAnswear(example);
            }
            while (_exampleCounter != Constants.RightAnswearsCount);

            Console.WriteLine("Победа!");
            Console.ReadKey();
        }

        /// <summary>
        ///     Получить цифру, обозначающую режим проверки знаний.
        /// </summary>
        /// <returns> Введённый пользователем режим </returns>
        private static char GetModeNumber()
        {
            bool isModeSelectionOver;
            char readKey;
            do
            {
                Console.WriteLine("Выберите тип примеров:");
                Console.WriteLine("\t0 - умножение\n\t1 - деление\n\t2 - и умножение, и деление");
                readKey = Console.ReadKey().KeyChar;
                Console.WriteLine();                
                isModeSelectionOver = Constants.ModeNumbers.Contains(readKey);
                Console.Clear();
                if (!isModeSelectionOver)
                    Console.WriteLine("Тип примеров не выбран.");
            }
            while (!isModeSelectionOver);
           
            return readKey;
        }

        /// <summary>
        ///     Установить класс, создающий примеры.
        /// </summary>
        /// <param name="mode"> Режим работы программы </param>
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
        private static void CheckUserAnswear(Example example)
        {
            static string operation() => WaitConsoleReader.ReadLine(Constants.TimeForAnswearInMillis);
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
