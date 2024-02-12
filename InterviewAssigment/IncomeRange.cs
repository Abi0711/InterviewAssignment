using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InterviewAssigment
{
    internal class IncomeRange
    {
        private decimal lowerBracket;
        private decimal upperBracket;
        private decimal percent;
        private decimal excess;
        private decimal addedOnAmount;
        public IncomeRange(decimal lowerBracket, decimal percent, decimal excess)
        {
            this.lowerBracket = lowerBracket;
            this.upperBracket = -1;
            this.percent = percent;
            this.excess = excess;
        }
        public IncomeRange(decimal lowerBracket, decimal upperBracket, decimal percent, decimal excess, decimal addedOnAmount)
        {
            this.lowerBracket = lowerBracket;
            this.upperBracket = upperBracket;
            this.percent = percent;
            this.excess = excess;
            this.addedOnAmount = addedOnAmount;
        }

        public IncomeRange(decimal lowerBracket, decimal upperBracket, decimal percent, decimal excess) 
        { 
            this.lowerBracket = lowerBracket;
            this.upperBracket = upperBracket;
            this.percent = percent;
            this.excess = excess;
        }

        public decimal LowerBracket { get => lowerBracket; }
        public decimal UpperBracket { get => upperBracket; }

        public decimal CalculateDeduction(decimal TI)
        {
            return addedOnAmount + ((TI - excess) * (percent/100));
        }
    }
}
