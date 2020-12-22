namespace MultiplicationTable.MathExample.Models
{
    public class MultiplyExample : Example
    {
        public MultiplyExample(int firstDigit, int secondDigit)
            : base(firstDigit, secondDigit)
        { }

        public override Operator Operator { get => Operator.Multiply; }
        public override int RightAnswear { get => FirstDigit * SecondDigit; }        
    }
}
