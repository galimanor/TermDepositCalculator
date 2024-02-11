using Microsoft.VisualStudio.TestTools.UnitTesting;
using TermDepositCalculator.Data;

namespace TermDepositCalculatorManager.Tests
{
    [TestClass]
    public class TermDepositCalculatorTests
    {
        private TermDepositCalculator calculator;

        [TestInitialize]
        public void Setup()
        {
            calculator = new TermDepositCalculator();
        }

        [TestMethod]
        public void CalculateInterestPaidMonthly_ValidInputs_CorrectFinalBalance()
        {
            decimal amount = 10000;
            decimal interestRate = 0.01m; 
            int investmentTerm = 12; 
            decimal expectedFinalBalance = 10100.46m;

            decimal finalBalance = calculator.CalculateInterestPaidMonthly(amount, interestRate/12, investmentTerm);

            Assert.AreEqual(expectedFinalBalance, decimal.Round(finalBalance, 2, MidpointRounding.AwayFromZero));
        }

        [TestMethod]
        public void CalculateFinalBalanceQuarterly_ValidInputs_CorrectFinalBalance()
        {
            decimal amount = 10000;
            decimal interestRate = 0.03m;
            int investmentTermMonths = 12; 
            decimal expectedFinalBalance = 10303.39m; 

            decimal finalBalance = calculator.CalculateFinalBalanceQuarterly(amount, interestRate/4, investmentTermMonths);

            Assert.AreEqual(expectedFinalBalance, decimal.Round(finalBalance, 2, MidpointRounding.AwayFromZero));
        }

        [TestMethod]
        public void CalculateFinalBalanceAnnualy_ValidInputs_CorrectFinalBalance()
        {
            decimal amount = 10000;
            decimal interestRate = 0.12m; 
            int investmentTerm = 2;
            decimal expectedFinalBalance = 12544.00m;

            decimal finalBalance = calculator.CalculateFinalBalanceAnnualy(amount, interestRate, investmentTerm);

            Assert.AreEqual(expectedFinalBalance, finalBalance);
        }

        [TestMethod]
        public void CalculateFinalBalanceAtMaturity_ValidInputs_CorrectFinalBalance()
        {
            decimal amount = 10000;
            decimal interestRate = 0.06m; 
            int investmentTerm = 12;
            decimal expectedFinalBalance = 10600.00m; 

            decimal finalBalance = calculator.CalculateFinalBalanceAtMaturity(amount, interestRate, investmentTerm);

            Assert.AreEqual(expectedFinalBalance, finalBalance);
        }

        [TestMethod]
        public void CalculateFinalBalanceAnnualy_ZeroInterestRate_ReturnsInitialAmount()
        {
            decimal amount = 10000;
            decimal interestRate = 0;
            int investmentTerm = 12;
            decimal expectedFinalBalance = 10000;

            decimal finalBalance = calculator.CalculateFinalBalanceAnnualy(amount, interestRate, investmentTerm);

            Assert.AreEqual(expectedFinalBalance, finalBalance, "Final balance should be the initial amount when zero interest rate is provided.");
        }

        [TestMethod]
        public void CalculateFinalBalanceAtMaturity_ZeroInvestmentTerm_ReturnsInitialAmount()
        {
            decimal amount = 10000;
            decimal interestRate = 0.06m;
            int investmentTerm = 0;
            decimal expectedFinalBalance = 10000;

            decimal finalBalance = calculator.CalculateFinalBalanceAtMaturity(amount, interestRate, investmentTerm);

            Assert.AreEqual(expectedFinalBalance, finalBalance, "Final balance should be the initial amount when zero investment term is provided.");
        }
    }
}