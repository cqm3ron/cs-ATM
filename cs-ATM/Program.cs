using System.Linq.Expressions;

namespace cs_ATM
{
    internal class Program
    {
        public static List<Account> accounts = new List<Account>();
        static void Main(string[] args)
        {

            Selector();
        }

        static void Selector()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Account.CreateAccount(accounts);
                        break;
                    case "2":
                        Account.Login(accounts);
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        Selector();
                        break;
                }
            }
        }
    }
}
