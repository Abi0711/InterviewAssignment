using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewAssigment
{
    public class IncomeRangeWithExcess(decimal lowerBracket, decimal upperBracket, decimal percent) : BaseIncomeRange(lowerBracket, upperBracket, percent)
    {
        private readonly decimal _excess = lowerBracket - 1;

        public override decimal CalculateDeduction(decimal TI)
        {
            return ((TI - _excess) * (Percent / 100));
        }
    }
}
