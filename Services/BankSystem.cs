using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    internal class BankSystem
    {
        private readonly List<BankAccount> _accounts; // Private Field

        public BankSystem(List<BankAccount> initialAccounts = null)
        {
            _accounts = initialAccounts ?? new List<BankAccount>();
        }
        public void AddAccount(BankAccount account)
        {
            if(account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            if(_accounts.Any(a => a.AccountNumber == account.AccountNumber))
            {
                throw new InvalidOperationException($"Account {account.AccountNumber} already exists.");
            }
            _accounts.Add(account);
            Console.WriteLine($"Account {account.AccountNumber} added successfully.");
        }

        public BankAccount? GetAccountByNumber(string accountNumber)
        {
            return _accounts.FirstOrDefault(a => a.AccountNumber.Equals(accountNumber, StringComparison.OrdinalIgnoreCase));
        }

        public void ShowAllAccounts()
        {
            if (_accounts.Count == 0)
            {
                Console.WriteLine("No accounts found.");
                return;
            }

            Console.WriteLine("=========== All Accounts ===========");
            foreach (var account in _accounts)
            {
                account.DisplayInfo(); // Calls overridden method from each account type
                Console.WriteLine("------------------------------");
            }
        }

        public void AddAccountInteractive()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Account Type (S for Savings / C for Current): ");
            string type = Console.ReadLine().Trim().ToUpper();

            Console.Write("Enter Initial Deposit: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal balance) || balance <= 0)
            {
                Console.WriteLine("Invalid amount.");
                return;
            }

            string accNo = "AC" + (_accounts.Count + 1).ToString("D4");

            BankAccount account = type switch
            {
                "S" => new SavingsAccount(accNo, name, balance),
                "C" => new CurrentAccount(accNo, name, balance),
                _ => null
            };

            if (account == null)
            {
                Console.WriteLine("Invalid account type.");
                return;
            }

            AddAccount(account);
        }

        public void DepositToAccount()
        {
            Console.Write("Enter Account Number: ");
            string accNo = Console.ReadLine();

            var account = GetAccountByNumber(accNo);
            if (account == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            Console.Write("Enter Amount to Deposit: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
            {
                account.Deposit(amount);
                Console.WriteLine("Deposit Successful!");
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
        }

        public void WithdrawFromAccount()
        {
            Console.Write("Enter Account Number: ");
            string accNo = Console.ReadLine();

            var account = GetAccountByNumber(accNo);
            if (account == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            Console.Write("Enter Amount to Withdraw: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
            {
                account.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
        }

        public void ShowAccountBalance()
        {
            Console.Write("Enter Account Number: ");
            string accNo = Console.ReadLine();

            var account = GetAccountByNumber(accNo);
            if (account != null)
            {
                account.ShowBalance();
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

    }
}
