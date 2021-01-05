using MultiplicationTable.MathExample.Models;
using System;

namespace MultiplicationTable.MathExample.Creators
{
    public class MultiplyExampleCreator : ExampleStorage, IExampleCreator
    {
        private readonly Random _random = new Random();

        public char Code => '0';

        public string ShortDescription => "умножение";

        public override void Add(int firstDigit, int secondDigit)
        {
            base.Add(firstDigit, secondDigit);
            _hashSet.Add(new Tuple<int, int>(secondDigit, firstDigit));
        }

        public void Clear()
        {
            _hashSet.Clear();
        }

        public Example CreateExample()
        {
            var firstDigit = _random.Next(2, 10);
            var secondDigit = _random.Next(2, 10);

            if (Contains(firstDigit, secondDigit))
                return null;

            Add(firstDigit, secondDigit);

            return new MultiplyExample(firstDigit, secondDigit);
        }
    }
}
