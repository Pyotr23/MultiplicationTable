using System;
using System.Collections.Generic;

namespace MultiplicationTable.MathExample.Models
{
    public class DivisionExampleStorage : IExampleStorage
    {
        private readonly HashSet<Tuple<int, int>> _multipliersHashSet = new HashSet<Tuple<int, int>>();

        public void Add(int firstDigit, int secondDigit)
        {
            _multipliersHashSet.Add(new Tuple<int, int>(firstDigit * secondDigit, secondDigit));
        }

        public void Clear()
        {
            _multipliersHashSet.Clear(); ;
        }

        public bool Contains(int firstDigit, int secondDigit)
        {
            return _multipliersHashSet.Contains(new Tuple<int, int>(firstDigit * secondDigit, secondDigit));
        }
    }
}
