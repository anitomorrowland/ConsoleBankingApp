using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    internal abstract class BankAccount
    {
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public abstract string AccountType { get; } // ReadOnly string which needs to be inherted in child classes

        protected BankAccount() // Default Constructor 
        {
            AccountNumber = string.Empty;
            Name = string.Empty;
            Balance = 0;
        }
        protected BankAccount(string accNo, string name, decimal balance) // Parameterized Constructor
        {
            AccountNumber = accNo;
            Name = name;
            Balance = balance;
        }

        /// <summary>
        /// Adds the specified amount to the account balance.
        /// </summary>
        /// <remarks>Use this method to increase the account balance by a specified amount. Ensure that
        /// the <paramref name="amount"/> is a positive value before calling this method.</remarks>
        /// <param name="amount">The amount to deposit into the account. Must be a positive value.</param>
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        /// <summary>
        /// Withdraws the specified amount from the account balance.
        /// Needs to be overriden by child classes.
        /// </summary>
        /// <remarks>If the specified amount exceeds the current balance, the withdrawal will not be
        /// processed,  and an error message will be displayed.</remarks>
        /// <param name="amount">The amount to withdraw. Must be a positive value less than or equal to the current balance.</param>
        public virtual void Withdraw(decimal amount)
        {
            if(amount <= Balance)
            {
                Balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient Balance!!!");
            }
        }

        /// <summary>
        /// Displays the current balance to the console.
        /// </summary>
        /// <remarks>The balance is printed in the format "Balance : {Balance}". Ensure that the <see
        /// cref="Balance"/> property is set before calling this method.</remarks>
        public void ShowBalance()
        {
            Console.WriteLine($"Balance : {Balance}");
        }

        /// <summary>
        /// Displays detailed information about the account, including the account holder's name,  account type, account
        /// number, and current balance.
        /// Needs to be overriden by child classes.
        /// </summary>
        /// <remarks>This method outputs the account information to the console. It includes the account
        /// holder's name,  the type of account, the account number, and the balance by invoking the <see
        /// cref="ShowBalance"/> method.</remarks>
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Account Holder Name: {Name}");
            Console.WriteLine($"Type : {AccountType}");
            Console.WriteLine($"{AccountType}: {AccountNumber}");
            ShowBalance();
        }
    }
}
