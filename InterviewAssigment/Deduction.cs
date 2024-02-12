using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewAssigment
{
    public class Deduction(List<BaseIncomeRange> incomeRanges)
    {
        private readonly List<BaseIncomeRange> _incomeRanges = incomeRanges;

        public decimal Calculate(decimal TI)
        {
            TI = Math.Floor(TI);
            if(_incomeRanges.Count == 0 || TI < 0) throw new Exception("Income");

            for(int i = 0; i < _incomeRanges.Count; i++)
            {
                if(_incomeRanges[i].IsInRange(TI))
                {
                    return Math.Ceiling(_incomeRanges[i].CalculateDeduction(TI));
                }
            }

            throw new Exception("Calculating deduction not valid");
        }

    }
}
