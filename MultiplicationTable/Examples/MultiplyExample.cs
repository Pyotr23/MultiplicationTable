namespace MultiplicationTable.Examples
{
    public class MultiplyExample : Example
    {
        public override Operator Operator { get => Operator.Multiply; }
        public override int RightAnswear { get => FirstDigit * SecondDigit; }        
    }
}
