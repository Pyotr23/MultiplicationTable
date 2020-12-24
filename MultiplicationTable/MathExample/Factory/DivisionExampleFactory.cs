using MultiplicationTable.MathExample.Models;

namespace MultiplicationTable.MathExample.Factory
{
    public class DivisionExampleFactory : IExampleFactory
    {
        public Example CreateExample(int firstDigit, int secondDigit)
        {
            return new DivisionExample(firstDigit * secondDigit, secondDigit);
        }

        public IExampleStorage CreateExampleStorage()
        {
            return new DivisionExampleStorage();
        }
    }
}
