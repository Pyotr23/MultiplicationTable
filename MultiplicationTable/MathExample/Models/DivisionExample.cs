namespace MultiplicationTable.MathExample.Models
{
    public class DivisionExample : Example
    {
        public DivisionExample(int firstDigit, int secondDigit)
            : base(firstDigit, secondDigit)
        { }

        public override Operator Operator => Operator.Division;

        public override int RightAnswer => FirstDigit / SecondDigit;
    }
}
