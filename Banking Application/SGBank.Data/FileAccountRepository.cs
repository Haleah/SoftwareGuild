using SGBank.Models.Interfaces;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        public Account LoadAccount(string AccountNumber)
        {
            using (StreamReader reader = new StreamReader("Account.txt"))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[0] == "AccountNumber")
                    {
                        continue;
                    }
                    else if (fields[0] == AccountNumber)
                    {
                        Account accountToUpdate = new Account();
                        accountToUpdate.AccountNumber = fields[0];
                        accountToUpdate.Name = fields[1];
                        accountToUpdate.Balance = decimal.Parse(fields[2]);
                        switch (fields[3])
                        {
                            case "F":
                                accountToUpdate.Type = AccountType.Free;
                                break;
                            case "B":
                                accountToUpdate.Type = AccountType.Basic;
                                break;
                            case "P":
                                accountToUpdate.Type = AccountType.Premium;
                                break;
                        }
                        return accountToUpdate;
                    }
                }
                return null;
            }
        }
        public void SaveAccount(Account account)
        {
            List<Account> accountList = new List<Account>();
            using (StreamReader reader = new StreamReader("Account.txt"))
            {
                string line = "";
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');
                    if (fields[0] != account.AccountNumber)
                    {
                        Account accountToWrite = new Account();
                        accountToWrite.AccountNumber = fields[0];
                        accountToWrite.Name = fields[1];
                        accountToWrite.Balance = decimal.Parse(fields[2]);
                        switch (fields[3])
                        {
                            case "F":
                                accountToWrite.Type = AccountType.Free;
                                break;
                            case "B":
                                accountToWrite.Type = AccountType.Basic;
                                break;
                            case "P":
                                accountToWrite.Type = AccountType.Premium;
                                break;
                        }
                        accountList.Add(accountToWrite);
                    }
                    else
                    {
                        accountList.Add(account);
                    }
                }
            }
            using (StreamWriter writetext = new StreamWriter("Account.txt"))
            {
                writetext.WriteLine("AccountNumber,Name,Balance,Type");
                foreach (var accountFromList in accountList)
                {
                    string typeChar;
                    switch (accountFromList.Type)
                    {
                        case AccountType.Free:
                            typeChar = "F";
                            break;

                        case AccountType.Basic:
                            typeChar = "B";
                            break;

                        case AccountType.Premium:
                        default:
                            typeChar = "P";
                            break;

                    }
                    string ReplacementString = accountFromList.AccountNumber + "," + accountFromList.Name + "," + accountFromList.Balance + "," + typeChar;
                    writetext.WriteLine(ReplacementString);
                }
            }
        }
    }
}
