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
        private string pin;
        private double balance;

        public Account(string aPin)
        {
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

            Console.WriteLine("Make a note of your account number and PIN as they will not be shown again.");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        public static void CreateAccount(List<Account> accounts)
        {
            while (true)
            {
                Console.WriteLine("Enter a 4-digit PIN (or leave blank to generate one):");
                string pin = Console.ReadLine();


                try
                {
                    accounts.Add(new Account(pin));
                    break;
                }
                catch (Exception e)
                {
                    if (e.Message == "err_invalid-pin")
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
            Console.WriteLine("Enter your pin:");
            string pin = Console.ReadLine();
            Account account = accounts.Find(a => a.accountNumber == accountNumber && a.pin == pin);
            if (account != null)
            {
                Console.WriteLine("Login successful!");
                LoggedIn.Menu(account);
            }
            else
            {
                Console.WriteLine("Invalid account number or pin.");
                Console.WriteLine("Press any key to continue... ");
                Console.ReadKey(true);
            }
        }

        public string GetAccountNumber()
        {
            return accountNumber;
        }
        public string GetPIN()
        {
            return pin;
        }
        public double GetBalance()
        {
            return balance;
        }
        public void Deposit(double amount)
        {
            balance += amount;
        }
        public void Withdraw(double amount)
        {
            balance -= amount;
        }
        public void ChangePin(string currentPin, string newPin)
        {
            if (currentPin != pin)
            {
                throw new ArgumentException("err_incorrect-pin");
            }
            else if (newPin.Length < 4 || newPin.Length > 1)
            {
                throw new ArgumentException("err_invalid-pin");
            }
            else
            {
                pin = newPin;
            }
        }

    }
}
