using MultiplicationTable.Examples;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiplicationTable
{
    public static class ExampleCreator
    {
        private static readonly Random _random = new Random();
        private static readonly HashSet<int> _hashSet = new HashSet<int>();

        public static Example Create(Operator exampleType)
        { 
            while (true)
            {
                var firstDigit = _random.Next(2, 10);
                var secondDigit = _random.Next(2, 10);

                switch (exampleType)
                {
                    case Operator.Multiply:
                        var rightAnswear = firstDigit * secondDigit;
                        if (_hashSet.Contains(rightAnswear))
                            continue;

                        _hashSet.Add(rightAnswear);
                        return new MultiplyExample
                        {
                            FirstDigit = firstDigit,
                            SecondDigit = secondDigit
                        };
                    case Operator.Division:
                        var divisible = firstDigit * secondDigit;
                        if (_hashSet.Contains(divisible))
                            continue;

                        _hashSet.Add(divisible);
                        return new DivisionExample
                        {
                            FirstDigit = divisible,
                            SecondDigit = secondDigit
                        };
                    default:
                        return null;
                }                
            }            
        }

        public static void Clear()
        {
            _hashSet.Clear();
        }
    }
}
