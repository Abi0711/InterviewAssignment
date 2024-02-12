using System.Collections;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InterviewAssigment
{
    public class Assignment
    {



        public static void Main()
        {
            Dictionary<string, int> payFrequencies = new() { ["M"] = 12, ["F"] = 24, ["W"] = 52 };
            Deduction medicareLevy = new([
                new(0, 21335, 0),
                new IncomeRangeWithExcess(21336, 26668, 10),
                new BaseIncomeRange(26669, -1, 2)
            ]);
            Deduction budgetRepairLevy = new([
                new BaseIncomeRange(0, 180000, 0),
                new IncomeRangeWithExcess(180001, -1, 2)
            ]);
            Deduction incomeTax = new([
                new BaseIncomeRange(0, 18200, 0),
                new IncomeRangeWithExcess(18201, 37000, 19),
                new IncomeRangeWithExcessAndAddOn(37001, 87000, 32.5m, 3572),
                new IncomeRangeWithExcessAndAddOn(87001, 180000, 37, 19822),
                new IncomeRangeWithExcessAndAddOn(180001, -1, 47, 54232)
            ]);

            Console.WriteLine("Enter your salary package amount: ");
            string? salaryIn = Console.ReadLine();
            decimal grossPackage;
            while (string.IsNullOrEmpty(salaryIn) || !decimal.TryParse(salaryIn, out grossPackage) || grossPackage < 0)
            {
                Console.WriteLine("Please enter a positive numeric value:");
                salaryIn = Console.ReadLine();
            }

            Console.WriteLine("Enter your pay frequency (W for weekly, F for fortnightly, M for monthly): ");

            string? payFreq = Console.ReadLine();
            while (string.IsNullOrEmpty(payFreq) || !payFrequencies.TryGetValue(payFreq, out int _))
            {
                Console.WriteLine("Please enter a value of M, W or F and should not be empty:");
                payFreq = Console.ReadLine();
            }

            Console.WriteLine("\nCalculating salary details...\n");

            Console.WriteLine($"Gross Package: {FormatDollar(grossPackage)}");
            decimal super = TaxCalculator.CalculateSuper(grossPackage);
            Console.WriteLine($"Superannuation: {FormatDollar(super)}\n");
            decimal TI = TaxCalculator.CalculateTI(grossPackage, super);
            Console.WriteLine($"Taxable income: {FormatDollar(TI)}\n");

            decimal deductions = TaxCalculator.CalculateDeduction(medicareLevy, TI) 
                + TaxCalculator.CalculateDeduction(budgetRepairLevy, TI) 
                + TaxCalculator.CalculateDeduction(incomeTax, TI);
            Console.WriteLine("Deductions: ");
            Console.WriteLine($"Medicare Levy: {FormatDollar(TaxCalculator.CalculateDeduction(medicareLevy, TI))}");
            Console.WriteLine($"Budget Repair Levy: {FormatDollar(TaxCalculator.CalculateDeduction(budgetRepairLevy, TI))}");
            Console.WriteLine($"Income Tax: {FormatDollar(TaxCalculator.CalculateDeduction(incomeTax, TI))}\n");

            decimal netIncome = TaxCalculator.CalculateNetIncome(grossPackage, super, deductions);
            Console.WriteLine($"Net income: {FormatDollar(netIncome)}");
            decimal payPacket = netIncome / payFrequencies[payFreq];
            string perPay;
            switch (payFreq)
            {
                case "M": perPay = "per month"; break;
                case "F": perPay = "per fortnight"; break;
                case "W": perPay = "per week"; break;
                default: return;
            };
            Console.WriteLine($"Pay Packet: {FormatDollar(TaxCalculator.CalculatePayPacket(netIncome, payFreq, payFrequencies))} {perPay}");
        }
        private static string FormatDollar(decimal number) => string.Format("{0:C}", Convert.ToDecimal(number));
    }
}