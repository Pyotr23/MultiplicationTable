using System;
using System.Collections.Generic;

namespace MultiplicationTable.MathExample.Models
{
    public class DivisionExampleStorage : IExampleStorage
    {
        /// <summary>
        ///     Хеш-таблица для хранения кортежей "Делимое - делитель"
        /// </summary>
        private readonly HashSet<Tuple<int, int>> _hashSet = new HashSet<Tuple<int, int>>();

        private readonly Random _random = new Random();

        public void Add(int firstDigit, int secondDigit)
        {
            _hashSet.Add(new Tuple<int, int>(firstDigit * secondDigit, secondDigit));
        }

        public void Clear()
        {
            _hashSet.Clear(); ;
        }

        public bool Contains(int firstDigit, int secondDigit)
        {
            return _hashSet.Contains(new Tuple<int, int>(firstDigit * secondDigit, secondDigit));
        }

        public Example CreateExample()
        {
            while (true)
            {
                var firstDigit = _random.Next(2, 10);
                var secondDigit = _random.Next(2, 10);
                firstDigit *= secondDigit;

                if (Contains(firstDigit, secondDigit))
                    continue;

                Add(firstDigit, secondDigit);

                return new DivisionExample(firstDigit, secondDigit);
            }
        }
    }
}
