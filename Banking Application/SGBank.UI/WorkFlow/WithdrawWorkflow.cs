using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.WorkFlow
{
    public class WithdrawWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            AccountManager accountManager = AccountManagerFactory.Create();

            Console.Write("Please enter an account number:");
            string accountNumber = Console.ReadLine();

            Console.Write("Please enter a withdrawl amount:");
            decimal amount = decimal.Parse(Console.ReadLine());

            AccountWithdrawResponse response = accountManager.Withdraw(accountNumber, amount);

            if (response.Success)
            {
                Console.WriteLine("Withdrawl completed!");
                Console.WriteLine($"Account Number {response.Account.AccountNumber}");
                Console.WriteLine($"Old Balance {response.OldBalance:c}");
                Console.WriteLine($"Withdraw Amount -{response.Amount:c}");
                Console.WriteLine($"Current Balance {response.Account.Balance:c}");
            }
            else
            {
                Console.WriteLine("An error occured:");
                Console.WriteLine(response.Message);
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

        }
    }
}
