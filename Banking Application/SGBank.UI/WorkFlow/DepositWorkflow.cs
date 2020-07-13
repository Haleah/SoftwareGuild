using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.WorkFlow
{
    public class DepositWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            AccountManager accountManager = AccountManagerFactory.Create();

            Console.Write("Please enter an account number:");
            string accountNumber = Console.ReadLine();

            Console.Write("Please enter a deposit amount:");
            decimal amount = decimal.Parse(Console.ReadLine());

            AccountDepositResponse response = accountManager.Deposit(accountNumber, amount);

            if(response.Success)
            {
                Console.WriteLine("Deposit completed!");
                Console.WriteLine($"Account Number {response.Account.AccountNumber}");
                Console.WriteLine($"Old Balance {response.OldBalance:c}");
                Console.WriteLine($"Deposit Amount {response.Amount:c}");
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
