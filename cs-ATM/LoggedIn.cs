using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_ATM
{
    internal static class LoggedIn
    {
        public static void Menu(Account account)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Logged in as account: " + account.GetAccountNumber());
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. View Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Change PIN");
                Console.WriteLine("5. Logout");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Balance: $" + account.GetBalance().ToString("0.00"));
                        break;

                    case "2":
                        Console.Write("Enter amount to deposit: $");
                        if (double.TryParse(Console.ReadLine(), out double depositAmount))
                        {
                            if (depositAmount <= 0)
                            {
                                Console.WriteLine("Deposit amount must be positive.");
                            }
                            else
                            {
                                account.Deposit(depositAmount);
                                Console.WriteLine("Deposited $" + depositAmount.ToString("0.00") + ". New balance: $" + account.GetBalance().ToString("0.00"));
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.");
                        }
                        break;

                    case "3":
                        Console.Write("Enter amount to withdraw: $");
                        if (double.TryParse(Console.ReadLine(), out double withdrawAmount))
                        {
                            if (withdrawAmount <= 0)
                            {
                                Console.WriteLine("Withdrawal amount must be positive.");
                            }
                            else if (withdrawAmount > account.GetBalance())
                            {
                                Console.WriteLine("Insufficient funds.");
                            }
                            else
                            {
                                account.Withdraw(withdrawAmount);
                                Console.WriteLine("Withdrew $" + withdrawAmount.ToString("0.00") + ". New balance: $" + account.GetBalance().ToString("0.00"));
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.");
                        }
                        break;

                    case "4":
                        Console.Write("Enter current pin: ");
                        string currentPin = Console.ReadLine();
                        Console.Write("Enter new pin: ");
                        string newPin = Console.ReadLine();
                        try
                        {
                            account.ChangePin(currentPin, newPin);
                            Console.WriteLine("Pin changed successfully.");
                        }
                        catch (Exception e)
                        {
                            if (e.Message == "err_invalid-pin")
                            {
                                Console.WriteLine("New pin must be exactly 4 digits.");
                            }
                            else if (e.Message == "err_incorrect-pin")
                            {
                                Console.WriteLine("Current pin is incorrect.");
                            }
                            else
                            {
                                Console.WriteLine("An unexpected error occurred: " + e.Message);
                            }
                        }
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please press any key to try again.");
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                }
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}
