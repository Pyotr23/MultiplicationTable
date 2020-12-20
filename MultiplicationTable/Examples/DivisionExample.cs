namespace MultiplicationTable.Examples
{
    public class DivisionExample : Example
    {
        public override Operator Operator => Operator.Division;

        public override int RightAnswear => FirstDigit / SecondDigit;
    }
}
