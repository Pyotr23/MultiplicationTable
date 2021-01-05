using MultiplicationTable.MathExample.Creators;
using System;
using System.Collections.Generic;

namespace MultiplicationTable
{
    public static class Constants
    {
        /// <summary>
        ///     Количество правильных ответов подряд для окончания задания.
        /// </summary>
        public const int RightAnswersCount = 15;

        /// <summary>
        ///     Время ожидания ответа, в мс.
        /// </summary>
        public const int TimeForAnswerInMillis = 14000;

        public static readonly List<IExampleCreator> ExampleCreators = new List<IExampleCreator>
        { 
            new MultiplyExampleCreator(),
            new DivisionExampleCreator(),
            new MixedExampleCreator()
        };
    }

    public class Operator
    {
        private Operator(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public static Operator Multiply => new Operator("*");
        public static Operator Division => new Operator(":");
    }
}
