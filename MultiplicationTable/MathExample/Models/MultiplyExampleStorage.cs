using System;
using System.Collections.Generic;

namespace MultiplicationTable.MathExample.Models
{
    public class MultiplyExampleStorage : ExampleStorage
    {
        private readonly HashSet<Tuple<int, int>> _multipliersHashSet = new HashSet<Tuple<int, int>>();

        public override void Add(int firstDigit, int secondDigit)
        {
            _multipliersHashSet.Add(new Tuple<int, int>(firstDigit, secondDigit));
            _multipliersHashSet.Add(new Tuple<int, int>(secondDigit, firstDigit));
        }

        public override bool Contains(int firstDigit, int secondDigit)
        {
            return _multipliersHashSet.Contains(new Tuple<int, int>(firstDigit, secondDigit));
        }

        public override void Clear()
        {
            _multipliersHashSet.Clear();
        }
    }
}
