namespace MultiplicationTable.MathExample.Models
{
    public interface IExampleStorage
    {
        public bool Contains(int firstDigit, int secondDigit);
        public void Add(int firstDigit, int secondDigit);
        public void Clear();
        public Example CreateExample();
    }
}
