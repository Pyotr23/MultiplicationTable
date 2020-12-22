using MultiplicationTable.MathExample.Factory;
using MultiplicationTable.MathExample.Models;
using System;
using System.Collections.Generic;

namespace MultiplicationTable
{
    public class ExampleCreator
    {
        private readonly Random _random = new Random();
        private readonly IExampleFactory _exampleFactory;
        private readonly IExampleStorage _exampleStorage;

        public ExampleCreator(Operator exampleType)
        {
            switch (exampleType)
            {
                case Operator.Multiply:
                    _exampleFactory = new MultiplyExampleFactory();
                    break;
            }
            _exampleStorage = _exampleFactory.CreateExampleStorage();
        }

        public Example Create()
        { 
            while (true)
            {
                var firstDigit = _random.Next(2, 10);
                var secondDigit = _random.Next(2, 10);

                
                if (_exampleStorage.Contains(firstDigit, secondDigit))
                    continue;

                _exampleStorage.Add(firstDigit, secondDigit);
                return _exampleFactory.CreateExample(firstDigit, secondDigit);                        
                    //case Operator.Division:
                    //    var divisible = firstDigit * secondDigit;
                    //    if (_hashSet.Contains(divisible))
                    //        continue;

                    //    _hashSet.Add(divisible);
                    //    return new DivisionExample
                    //    {
                    //        FirstDigit = divisible,
                    //        SecondDigit = secondDigit
                    //    };                                  
            }            
        }

        public void ClearStorage()
        {
            _exampleStorage.Clear();
        }
    }
}
