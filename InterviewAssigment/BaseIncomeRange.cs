using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewAssigment
{
    public class BaseIncomeRange
    {

        public decimal LowerBracket { get; protected set; }
        public decimal Percent { get; protected set; }
        public decimal UpperBracket { get; protected set; }
        public BaseIncomeRange(decimal lowerBracket, decimal upperBracket, decimal percent)
        {
            if (lowerBracket < 0) throw new Exception("Lower bracket cannot be a negative number");
            if (lowerBracket >= upperBracket && upperBracket!=-1) throw new Exception("Bracket range from lower to upper must be greater than 0");
            LowerBracket = lowerBracket;
            UpperBracket = upperBracket;
            Percent = percent;
        }
        public virtual decimal CalculateDeduction(decimal TI)
        {
            return (TI * (Percent / 100));
        }

        public bool IsInRange(decimal TI)
        {
            return UpperBracket==-1 ? LowerBracket <= TI : LowerBracket <= TI && UpperBracket >= TI;
        }

    }
}
