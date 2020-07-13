using NUnit.Framework;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
    [TestFixture]
    public class Premium_AccountTests
    {
        [TestCase("44444", "Premium Account", 100, AccountType.Free, 250, false)]
        [TestCase("44444", "Premium Account", 100, AccountType.Premium, -100, false)]
        [TestCase("44444", "Premium Account", 100, AccountType.Premium, 250, true)]

        [Test]
        public void PremiumAccountDespositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit deposit = new NoLimitDepositRule();
            Account account = new Account();
            account.Type = accountType;
            account.Balance = balance;
            account.Name = name;
            account.AccountNumber = accountNumber;

            AccountDepositResponse response = deposit.Deposit(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }

        [TestCase("44444", "Premium Account", 100, AccountType.Free, -100, 100, false)]
        [TestCase("44444", "Premium Account", 100, AccountType.Premium, 100, 100, false)]
        [TestCase("44444", "Premium Account", 150, AccountType.Premium, -50, 100, true)]
        [TestCase("44444", "Premium Account", 100, AccountType.Premium, -650, -560, true)]

        [Test]
        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, decimal balanceAmount, bool expectedResult)
        {
            IWithdraw withdraw = new PremiumAccountWithdrawRule();
            Account account = new Account();
            account.Type = accountType;
            account.Balance = balance;
            account.Name = name;
            account.AccountNumber = accountNumber;

            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }
    }
}
