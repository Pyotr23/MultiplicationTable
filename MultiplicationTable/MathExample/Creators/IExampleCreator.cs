using MultiplicationTable.MathExample.Models;

namespace MultiplicationTable.MathExample.Creators
{
    public interface IExampleCreator : IClearable
    {
        public Example CreateExample();
    }
}
