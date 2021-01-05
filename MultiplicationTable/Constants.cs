using System.Collections.Generic;

namespace MultiplicationTable
{
    public static class Constants
    {
        public const int RightAnswersCount = 15;
        public const int TimeForAnswerInMillis = 14000;
        public static readonly Dictionary<Operator, string> OperatorSymbol = new Dictionary<Operator, string>
        {
            { Operator.Multiply, "*" },
            { Operator.Division, ":"}
        };
        public static readonly char[] ModeNumbers = { '0', '1', '2' };
    }
}
