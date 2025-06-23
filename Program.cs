namespace BankingApp
{
    internal class Program
    {
        private static BankSystem bankSystem = new BankSystem();
        static void Main(string[] args)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════════╗");
                Console.WriteLine("║           BANKING SYSTEM MENU            ║");
                Console.WriteLine("╚══════════════════════════════════════════╝");
                Console.WriteLine("1. Create Account.");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Show Balance");
                Console.WriteLine("5. View All Accounts");
                Console.WriteLine("6. Exit");

                Console.Write("Select an option(1-6): ");
                string choice = Console.ReadLine();

                switch(choice)
                {
                    case "1":
                        bankSystem.AddAccountInteractive();
                        break;
                    case "2":
                        bankSystem.DepositToAccount();
                        break;
                    case "3":
                        bankSystem.WithdrawFromAccount();
                        break;
                    case "4":
                        bankSystem.ShowAccountBalance();
                        break;
                    case "5":
                        bankSystem.ShowAllAccounts();
                        break;
                    case "6":
                        Console.WriteLine("Thank you for using the Banking App.");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
            }
        }
    }
}
