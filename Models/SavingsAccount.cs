using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    internal class SavingsAccount : BankAccount
    {
        private const decimal MinimumBalance = 500; // Must maintain 500rs 
        private const decimal WithdrawlLimit = 10000; // Max 100000rs per withdrawl
        public override string AccountType => "Savings Account";

        public SavingsAccount(string accNo, string name, decimal balance) : base(accNo, name, balance)
        { }

        public override void Withdraw(decimal amount)
        {
            if(amount > WithdrawlLimit)
            {
                Console.WriteLine($"Error: Cannot withdraw more than {WithdrawlLimit:C} at once.");
                return;
            }
            if(Balance - amount < MinimumBalance)
            {
                Console.WriteLine($"Error: Must maintain a minimum balance of {MinimumBalance:C}.");
                return;
            }

            base.Withdraw(amount);
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Withdrawl Limit: {WithdrawlLimit}");
            Console.WriteLine($"Minimum Balance : {MinimumBalance}");
        }
    }
}
