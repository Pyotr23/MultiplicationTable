namespace MultiplicationTable.MathExample.Models
{
    public abstract class ExampleStorage
    {
        public abstract bool Contains(int firstDigit, int secondDigit);
        public abstract void Add(int firstDigit, int secondDigit);
        public abstract void Clear();
    }
}
