using System.Text.RegularExpressions;
using TermDepositCalculator.Data;
using TermDepositCalculatorManager;

namespace TermDepositCalculatorProgram
{
    public class Program
    {
        static void Main(string[] args)
        {
            var amout = GetInputAmount();
            var interestRate = GetInterestRate();
            var inverstmentTerm = GetInvestmentTerm();
            var interestPaid = GetInterestPaid();                   
            
            var termDepositCalculatorManager = new TermDepositCalculatorManager.TermDepositCalculator();
            termDepositCalculatorManager.GetTermDepositFinalBalance(amout, interestRate/100, inverstmentTerm, interestPaid);
        }

        private static IterestPaid GetInterestPaid()
        {
            Console.WriteLine("Enter interest paid (Monthly, Quarterly, Annually, AtMaturity): ");
            var interestPaidInput = Console.ReadLine();
            
            while (interestPaidInput == null || !Enum.IsDefined(typeof(IterestPaid), interestPaidInput))
            {
                Console.WriteLine("Interest paid input is invalid. Enter interest paid (Monthly, Quarterly, Annually, AtMaturity): ");
                interestPaidInput = Console.ReadLine();
            }

            Enum.TryParse(interestPaidInput, out IterestPaid iterestPaid);
            return iterestPaid;
        }

        private static int GetInvestmentTerm()
        {
            var investmentTerm = 0;
            Console.WriteLine("Enter the investment term in months: ");
            var investmentTermInput = Console.ReadLine();
            while (investmentTermInput == null || !int.TryParse(investmentTermInput, out investmentTerm) || investmentTerm <=0)
            {
                Console.WriteLine("Enter possitive number of months: ");
                investmentTermInput = Console.ReadLine();
            }

            return investmentTerm;
        }

        private static decimal GetInterestRate()
        {
            decimal interestRate = 0;
            Console.WriteLine("Enter interest rate (in percentage, e.g., 1.10%): ");
            var userInputInterestRate = Console.ReadLine();

            while(!IsInterestRateValid(userInputInterestRate))
            {
                Console.WriteLine("Enter possitive numeric interest rate: ");
                userInputInterestRate = Console.ReadLine();
            }

           
            decimal.TryParse(userInputInterestRate?.Replace("%", string.Empty), out interestRate);
            return interestRate;
        }

        private static decimal GetInputAmount()
        {
            Console.WriteLine("Welcome to your term deposit calculator");
            Console.WriteLine("Enter the amout you would like to deposite: ");

            decimal amountParsed = 0;
            var userInputAmount = Console.ReadLine();
            var amout = (userInputAmount != null && decimal.TryParse(userInputAmount, out amountParsed))
                ? amountParsed
                : 0;

            while (amout <= 0)
            {
                Console.WriteLine("Please enter possitive numeric amout: ");
                userInputAmount = Console.ReadLine();
                amout = userInputAmount != null && decimal.TryParse(userInputAmount, out amountParsed)
                ? Convert.ToDecimal(userInputAmount.Replace(",", string.Empty))
                : 0;
            }

            return amout;
        }

        private static bool IsInterestRateValid(string? userInputInterestRate)
        {
            double interestRate = 0;
            return userInputInterestRate == null 
                || (double.TryParse(userInputInterestRate.Replace("%", string.Empty), out interestRate) && interestRate > 0);
        }
    }
}
