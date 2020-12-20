using System.Collections.Generic;

namespace MultiplicationTable
{
    public static class Constants
    {
        public const int RightAnswearsCount = 15;
        public const int TimeForAnswearInMillis = 15000;
        public static readonly Dictionary<Operator, string> OperatorSymbol = new Dictionary<Operator, string>
        {
            { Operator.Multiply, "*" },
            { Operator.Division, ":"}
        };
    }
}
