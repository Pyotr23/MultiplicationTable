using MultiplicationTable.MathExample.Models;
using System;

namespace MultiplicationTable.MathExample.Creators
{
    /// <summary>
    ///     Класс, создающий примеры с делением.
    /// </summary>
    public class DivisionExampleCreator : ExampleStorage, IExampleCreator
    {
        private readonly Random _random = new Random();
                
        public char Code => '1';

        public string ShortDescription => "деление";

        public void Clear()
        {
            _hashSet.Clear();
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
