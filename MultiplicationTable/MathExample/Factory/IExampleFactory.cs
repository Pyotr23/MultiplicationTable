using MultiplicationTable.MathExample.Models;

namespace MultiplicationTable.MathExample.Factory
{
    public interface IExampleFactory
    {
        Example CreateExample(int firstDigit, int secondDigit);
        IExampleStorage CreateExampleStorage();
    }
}
