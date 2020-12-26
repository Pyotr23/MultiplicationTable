using System;
using System.Collections.Generic;

namespace MultiplicationTable.MathExample.Models
{
    public class MultiplyExampleStorage : IExampleStorage
    {
        /// <summary>
        ///     Хеш-таблица для хранения кортежей со множителями
        /// </summary>
        private readonly HashSet<Tuple<int, int>> _hashSet = new HashSet<Tuple<int, int>>();

        private readonly Random _random = new Random();

        public void Add(int firstDigit, int secondDigit)
        {
            _hashSet.Add(new Tuple<int, int>(firstDigit, secondDigit));
            _hashSet.Add(new Tuple<int, int>(secondDigit, firstDigit));
        }

        public bool Contains(int firstDigit, int secondDigit)
        {
            return _hashSet.Contains(new Tuple<int, int>(firstDigit, secondDigit));
        }

        public void Clear()
        {
            _hashSet.Clear();
        }

        public Example CreateExample()
        {
            while (true)
            {
                var firstDigit = _random.Next(2, 10);
                var secondDigit = _random.Next(2, 10);

                if (Contains(firstDigit, secondDigit))
                    continue;

                Add(firstDigit, secondDigit);

                return new MultiplyExample(firstDigit, secondDigit);                                                
            }
        }
    }
}
