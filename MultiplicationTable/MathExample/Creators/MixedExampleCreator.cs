using MultiplicationTable.MathExample.Models;
using System;
using System.Linq;

namespace MultiplicationTable.MathExample.Creators
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
            var example = _exampleCreators[index].CreateExample();
            return example ?? _exampleCreators[1 - index].CreateExample();
        }
    }
}
