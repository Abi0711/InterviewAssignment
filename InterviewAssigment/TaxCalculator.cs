using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewAssigment
{
    public class TaxCalculator
    {
        const decimal SUPERANNUATION = (decimal)(0.095 / 1.095);

        public static decimal CalculateSuper(decimal grossPackage)
        {

            return Math.Round(grossPackage * SUPERANNUATION , 2);
        }
        public static decimal CalculateTI(decimal grossPackage, decimal super)
        {
            return grossPackage - super;
        }
        public static decimal CalculateDeduction(Deduction deduction, decimal TI)
        {
            return deduction.Calculate(TI);
        }

        public static decimal CalculateNetIncome(decimal grossPackage, decimal super, decimal deductions)
        {
            return grossPackage - super - deductions;
        }

        public static decimal CalculatePayPacket(decimal netIncome, string payFreq, Dictionary<string, int> payFrequencies)
        {
            return netIncome / payFrequencies[payFreq];
        }

    }

}
