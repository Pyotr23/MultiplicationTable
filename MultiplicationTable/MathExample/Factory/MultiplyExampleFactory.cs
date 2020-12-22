using MultiplicationTable.MathExample.Models;

namespace MultiplicationTable.MathExample.Factory
{
    public class MultiplyExampleFactory : IExampleFactory
    {
        public Example CreateExample(int firstDigit, int secondDigit)
        {
            return new MultiplyExample(firstDigit, secondDigit);
        }

        public ExampleStorage CreateExampleStorage()
        {
            return new MultiplyExampleStorage();
        }
    }
}
