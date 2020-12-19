using System;
using System.Collections.Generic;
using System.Text;

namespace MultiplicationTable
{
    public class Example
    {
        public int FirstDigit { get; set; }
        public int SecondDigit { get; set; }
        public Operator Operator { get; set; } = Operator.Multiply; 
        public int RightAnswear { get; set; }

        public override string ToString()
        {            
            return $"{ToStringWithoutAnswear()}{RightAnswear}";
        }

        public string ToStringWithoutAnswear()
        {
            var mathOperator = Operator == Operator.Multiply
                ? "*"
                : ":";
            return $"{FirstDigit} {mathOperator} {SecondDigit} = ";
        }
    }

    public enum Operator
    {
        Multiply,
        Division
    }
}
