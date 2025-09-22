using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace cs_ATM
{
    internal class Account
    {
        public static int accountCount = 1;
        private string accountNumber;
        private string password;
        private string pin;
        private double balance;

        public Account(string aPassword, string aPin)
        {
            if (aPassword.Length < 8 || !aPassword.Any(char.IsUpper) || !aPassword.Any(char.IsLower) || !aPassword.Any(char.IsDigit) || !aPassword.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                throw new ArgumentException("err_invalid-passwd");
            }
            else
            {
                password = aPassword;
            }

            if (aPin == "")
            {
                pin = new Random().Next(1000,9999).ToString();
            }
            else if (aPin.Length != 4 || !aPin.All(char.IsDigit))
            {
                throw new ArgumentException("err_invalid-pin");
            }
            else
            {
                pin = aPin;
            }

            
            accountNumber = "";
            while (accountNumber.Length < (10 - accountCount.ToString().Length))
            {
                accountNumber += "0";
            }
            accountNumber += accountCount.ToString();
            accountCount++;

            Console.WriteLine("Generated a new account with account number: " + accountNumber);
            if (aPin == "")
            {
                Console.WriteLine("PIN: " + pin);
            }
            Console.WriteLine("Password: " + password);

            Console.WriteLine("Make a note of your account number, password, and PIN as they will not be shown again without verification.");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
        
        public static string GetPassword(Account account, string aAccountNumber, string aPin)
        {
            if (aAccountNumber == account.accountNumber && aPin == account.pin)
            {
                return account.password;
            }
            else
            {
                return ("Invalid combination of account number & PIN.");
            }
        }
        public static string GetPin(Account account, string aAccountNumber, string aPassword)
        {
            if (aAccountNumber == account.accountNumber && aPassword == account.password)
            {
                return account.pin;
            }
            else
            {
                return ("Invalid combination of account number & password.");
            }
        }

        public static void CreateAccount(List<Account> accounts)
        {
            while (true)
            {
                Console.WriteLine("Enter a password:");
                string password = Console.ReadLine();
                Console.WriteLine("Enter a 4-digit PIN (or leave blank to generate one):");
                string pin = Console.ReadLine();


                try
                {
                    accounts.Add(new Account(password, pin));
                    break;
                }
                catch (Exception e)
                {
                    if (e.Message == "err_invalid-passwd")
                    {
                        Console.WriteLine("Password must be at least 8 characters long and include at least one uppercase letter, one lowercase letter, one digit, and one special character.");
                    }
                    else if (e.Message == "err_invalid-pin")
                    {
                        Console.WriteLine("PIN must be exactly 4 digits.");
                    }
                    else
                    {
                        Console.WriteLine("An unexpected error occurred: " + e.Message);
                    }
                }
            }
        }

        public static void Login(List<Account> accounts)
        {
            Console.WriteLine("Enter your account number:");
            string accountNumber = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();
            Account account = accounts.Find(a => a.accountNumber == accountNumber && a.password == password);
            if (account != null)
            {
                Console.WriteLine("Login successful!");
                // Proceed with account operations
            }
            else
            {
                Console.WriteLine("Invalid account number or password.");
                Console.WriteLine("Press any key to continue... ");
                Console.ReadKey(true);
            }
        }

    }
}
