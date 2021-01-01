using System;

namespace MultiplicationTable.MathExample.Models
{
    public class DivisionExampleCreator : ExampleStorage, IExampleCreator
    {
        private readonly Random _random = new Random();        

        public void Clear()
        {
            _hashSet.Clear(); ;
        }        

        public Example CreateExample()
        {
            var firstDigit = _random.Next(2, 10);
            var secondDigit = _random.Next(2, 10);
            firstDigit *= secondDigit;

            if (Contains(firstDigit, secondDigit))
                return null;

            Add(firstDigit, secondDigit);

            return new DivisionExample(firstDigit, secondDigit);
        }
    }
}
