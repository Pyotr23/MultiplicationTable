using System;
using System.Collections.Generic;
using System.Text;

namespace MultiplicationTable
{
    public static class ExampleCreator
    {
        private static readonly Random _random = new Random();
        private static readonly HashSet<int> _hashSet = new HashSet<int>();

        public static Example Create()
        {
            while (true)
            {
                var firstDigit = _random.Next(2, 10);
                var secondDigit = _random.Next(2, 10);
                var rightAnswear = firstDigit * secondDigit;
                if (_hashSet.Contains(rightAnswear))
                    continue;

                _hashSet.Add(rightAnswear);
                return new Example
                {
                    FirstDigit = firstDigit,
                    SecondDigit = secondDigit,
                    RightAnswear = rightAnswear
                };
            }            
        }

        public static void Clear()
        {
            _hashSet.Clear();
        }
    }
}
