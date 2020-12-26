using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiplicationTable.MathExample.Models
{
    public class MixedExampleStorage : IExampleStorage
    {
        private readonly IExampleStorage[] _exampleStorages =
            { new MultiplyExampleStorage(), new DivisionExampleStorage() };
        private readonly Random _random = new Random();

        public void Add(int firstDigit, int secondDigit)
        {
            throw new NotImplementedException();
            //var index = _random.Next(0, 2);
            //if (_exampleStorages[index].)
        }

        public void Clear()
        {
            _exampleStorages
                .ToList()
                .ForEach(s => s.Clear());
        }

        public bool Contains(int firstDigit, int secondDigit)
        {
            throw new NotImplementedException();
        }

        public Example CreateExample()
        {
            var index = _random.Next(0, 2);
            return _exampleStorages[index].CreateExample();
        }
    }
}
