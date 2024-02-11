
using TermDepositCalculator.Data;

namespace TermDepositCalculatorManager
{
    public class TermDepositCalculator
    {     
        public TermDepositCalculator()
        {
        }

        public void GetTermDepositFinalBalance(decimal amount, decimal interestRate, int investmentTerm, IterestPaid interestPaid)
        {
            decimal finalBalance = 0;
            switch(interestPaid)
            {
                case IterestPaid.Monthly:
                    finalBalance = CalculateInterestPaidMonthly(amount, interestRate / 12, investmentTerm); ;
                    break;
                case IterestPaid.Quarterly:
                    finalBalance = CalculateFinalBalanceQuarterly(amount, interestRate / 4, investmentTerm);
                    break;
                case IterestPaid.Annually:
                    finalBalance = CalculateFinalBalanceAnnualy(amount, interestRate, investmentTerm);
                    break;
                case IterestPaid.AtMaturity:
                    finalBalance = CalculateFinalBalanceAtMaturity(amount, interestRate, investmentTerm);
                    break;
                default:
                    Console.WriteLine("Invalid option selected. Exiting...");
                    break;
            }

            Console.WriteLine($"Final balance: ${finalBalance:F2}");
        }

        public decimal CalculateInterestPaidMonthly(decimal amount, decimal interestRate, int investmentTerm)
        {
            while (investmentTerm > 0)
            {
                amount += amount * interestRate;
                investmentTerm--;
            }

            return amount;
        }

        public decimal CalculateFinalBalanceQuarterly(decimal amount, decimal interestRate, int investmentTermMonths)
        {    
            while (investmentTermMonths > 0)
            {
                amount += amount * interestRate;
                investmentTermMonths -= 3;
            }

            return amount;
        }

        public decimal CalculateFinalBalanceAnnualy(decimal amount, decimal interestRate, int investmentTerm)
        {
            while (investmentTerm > 0)
            {
                amount += (amount * (interestRate));
                investmentTerm--;
            }

            return amount;
        }

        public decimal CalculateFinalBalanceAtMaturity(decimal amount, decimal interestRate, int investmentTerm)
        {
            return amount * (1 + interestRate * investmentTerm / 12);
        }      
    }
}
