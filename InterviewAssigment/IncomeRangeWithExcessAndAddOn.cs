using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewAssigment
{
    public class IncomeRangeWithExcessAndAddOn(decimal lowerBracket, decimal upperBracket, decimal percent, decimal addOn) : BaseIncomeRange(lowerBracket, upperBracket, percent)
    {
        private readonly decimal _addedOnAmount = addOn;
        private readonly decimal _excess = lowerBracket - 1;

        public override decimal CalculateDeduction(decimal TI)
        {
            return _addedOnAmount + ((TI - _excess) * (Percent / 100));
        }
    }
}
