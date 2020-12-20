namespace MultiplicationTable.Examples
{
    public abstract class Example
    {
        public int FirstDigit { get; set; }
        public int SecondDigit { get; set; }
        abstract public Operator Operator { get; }
        abstract public int RightAnswear { get; }

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
