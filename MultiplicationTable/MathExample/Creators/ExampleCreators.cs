using System.Collections.Generic;
using System.Linq;

namespace MultiplicationTable.MathExample.Creators
{
    public class ExampleCreators
    {
        private readonly IEnumerable<IExampleCreator> _creators;

        public ExampleCreators(IEnumerable<IExampleCreator> creators)
        {
            _creators = creators;
        }

        public string GetStringWithDescriptions()
        {
            var descriptions = _creators
                .Select(cr => cr.Description);
            return string.Join("\n", descriptions);
        }

        public IExampleCreator GetExampleCreator(char code)
        {
            return _creators
                .FirstOrDefault(cr => cr.Code == code);
        }
    }
}
