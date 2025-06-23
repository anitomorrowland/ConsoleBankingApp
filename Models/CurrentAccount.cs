using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    internal class CurrentAccount : BankAccount
    {
        public const decimal WithdrawlFee = 20; // 20rs per withdrawl
        public override string AccountType => "Current Account";

        public CurrentAccount(string accNo, string name, decimal balance) : base(accNo, name, balance)
        { }

        public override void Withdraw(decimal amount)
        {
            decimal totalAmount = amount + WithdrawlFee;
            if(totalAmount <= Balance)
            {
                Balance -= totalAmount;
                Console.WriteLine($"Withdrew {amount} + fee {WithdrawlFee}");
            }
            else
            {
                Console.WriteLine("Error: Isufficient funds (including fee).");
            }
            base.Withdraw(amount);
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Withdrawl fee: {WithdrawlFee}");
            ShowBalance();
        }
    }
}
