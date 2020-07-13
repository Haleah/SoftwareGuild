﻿using SGBank.Models;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.DepositRules
{
    public class FreeAccountDepositRule : IDeposit
    {
        public AccountDepositResponse Deposit(Account account, decimal amount)
        {
            AccountDepositResponse response = new AccountDepositResponse();

            if(account.Type != AccountType.Free )
            {
                response.Success = false;
                response.Message = " Error: a non free account hit the Free Deposit Rule.";
                return response;
            }
            if(amount > 100)
            {
                response.Success = false;
                response.Message = "Free accounts can not deposit more than $100.00 at a time.";
                return response;
            }
            if(amount <= 0)
            {
                response.Success = false;
                response.Message = "Deposit amount must be more than zero.";
                return response;
            }
            response.OldBalance = account.Balance;
            account.Balance += amount;
            response.Account = account;
            response.Amount = amount;
            response.Success = true;

            return response;
        }
    }
}