﻿using NUnit.Framework;
using SGBank.BLL;
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
    public class BasicAccountTests
    {
        [TestCase("33333", "Basic Account", 100, AccountType.Free, 250, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, -100, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, 250, true)]

        [Test]
        public void BasicAccountDespositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
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

        [TestCase("33333", "Basic Account", 1500, AccountType.Basic, -1000, 1500, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Free, -100, 100, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, 100, 100, false)]
        [TestCase("33333", "Basic Account", 150, AccountType.Basic, -50, 100, true)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, -150, -60, true)]

        [Test]
        public void BasicAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, decimal  balanceAmount, bool expectedResult)
        {
            IWithdraw withdraw = new BasicAccountWithdrawRule();
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