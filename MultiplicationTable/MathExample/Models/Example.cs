namespace MultiplicationTable.MathExample.Models
{
    public abstract class Example
    {
        public int FirstDigit { get; private set; }
        public int SecondDigit { get; private set; }
        abstract public Operator Operator { get; }
        abstract public int RightAnswear { get; }

        public Example(int firstDigit, int secondDigit)
        {
            FirstDigit = firstDigit;
            SecondDigit = secondDigit;
        }

        public override string ToString()
        {            
            return $"{ToStringWithoutAnswear()}{RightAnswear}";
        }

        public string ToStringWithoutAnswear()
        {            
            return $"{FirstDigit} {Constants.OperatorSymbol[Operator]} {SecondDigit} = ";
        }
    }    
}
