using MultiplicationTable.MathExample.Models;

namespace MultiplicationTable.MathExample.Creators
{
    /// <summary>
    ///     Интерфейс класса, создающего примеры.
    /// </summary>
    public interface IExampleCreator : IClearable
    {
        /// <summary>
        ///     Создать пример.
        /// </summary>
        /// <returns> Базовый класс примера. </returns>
        public Example CreateExample();

        /// <summary>
        ///     Буквенное обозначение. Для определения конкретного класса-создателя из консоли.
        /// </summary>
        public char Code { get; }
    }
}
