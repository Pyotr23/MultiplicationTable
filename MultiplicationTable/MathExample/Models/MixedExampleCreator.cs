using System;
using System.Linq;

namespace MultiplicationTable.MathExample.Models
{
    public class MixedExampleCreator : IExampleCreator
    {
        private readonly IExampleCreator[] _exampleCreators =
            { new MultiplyExampleCreator(), new DivisionExampleCreator() };
        private readonly Random _random = new Random();

        public void Clear()
        {
            _exampleCreators
                .ToList()
                .ForEach(s => s.Clear());
        }

        public Example CreateExample()
        {
            var index = _random.Next(0, 2);
            return _exampleCreators[index].CreateExample();
        }
    }
}
