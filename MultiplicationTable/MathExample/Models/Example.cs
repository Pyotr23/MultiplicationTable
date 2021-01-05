namespace MultiplicationTable.MathExample.Models
{
    public abstract class Example
    {
        public int FirstDigit { get; private set; }
        public int SecondDigit { get; private set; }
        abstract public Operator Operator { get; }
        abstract public int RightAnswer { get; }

        public Example(int firstDigit, int secondDigit)
        {
            FirstDigit = firstDigit;
            SecondDigit = secondDigit;
        }

        public override string ToString()
        {            
            return $"{ToStringWithoutAnswer()}{RightAnswer}";
        }

        public string ToStringWithoutAnswer()
        {            
            return $"{FirstDigit} {Constants.OperatorSymbol[Operator]} {SecondDigit} = ";
        }
    }    
}
