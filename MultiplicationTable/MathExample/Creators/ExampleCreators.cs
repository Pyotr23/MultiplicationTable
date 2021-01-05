using System.Collections.Generic;
using System.Linq;

namespace MultiplicationTable.MathExample.Creators
{
    /// <summary>
    ///     Класс, управляющий коллекцией создателей примеров.
    /// </summary>
    public class ExampleCreators
    {
        private readonly IEnumerable<IExampleCreator> _creators;

        public ExampleCreators(IEnumerable<IExampleCreator> creators)
        {
            _creators = creators;
        }

        /// <summary>
        ///     Получить строку с описаниями создателей примеров.
        /// </summary>
        public string GetStringWithDescriptions()
        {
            var descriptions = _creators
                .Select(cr => cr.Description);
            return string.Join("\n", descriptions);
        }

        /// <summary>
        ///     Получить создатель примеров.
        /// </summary>
        /// <param name="code"> Код создателя. </param>
         public IExampleCreator GetExampleCreator(char code)
        {
            return _creators
                .FirstOrDefault(cr => cr.Code == code);
        }
    }
}
