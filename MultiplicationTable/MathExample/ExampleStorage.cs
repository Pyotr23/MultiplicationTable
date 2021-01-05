using System;
using System.Collections.Generic;

namespace MultiplicationTable.MathExample
{
    public class ExampleStorage
    {
        protected readonly HashSet<Tuple<int, int>> _hashSet = new HashSet<Tuple<int, int>>();

        public virtual void Add(int firstDigit, int secondDigit)
        {
            _hashSet.Add(new Tuple<int, int>(firstDigit, secondDigit));            
        }

        public bool Contains(int firstDigit, int secondDigit)
        {
            return _hashSet.Contains(new Tuple<int, int>(firstDigit, secondDigit));
        }
    }
}
