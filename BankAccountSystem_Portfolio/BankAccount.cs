using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P13
{
    public abstract class BankAccount
    {
        // Auto-properties
        public string AccountNumber { get; } // A 10-digit account number
        public decimal Balance { get; protected set; } // Protected set lets derived classes modify the value
        public string Owner { get; set; } // Name of the account owner
        public AccountType Type { get; }

        // Constructor
        public BankAccount(string accountNumber, string owner, decimal initialDeposit, AccountType type)
        {
            AccountNumber = accountNumber;
            Owner = owner;
            Type = type;

            if (initialDeposit < 0)
                throw new InvalidOperationException("Initial deposit can't be negative");

            Balance = initialDeposit;
        }

        // Method to deposit money into the account
        public void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine("{0,-12}{1,2}{2,20:N2}", "Deposited", ": ", amount);
        }

        // Virtual method to withdraw money (can be overridden by derived classes)
        public virtual void Withdrawal(decimal amount)
        {
            Balance -= amount;
            Console.WriteLine("{0,-12}{1,2}{2,20:N2}", "Withdrawn", ": ", amount);
        }

        // Display account information
        public void AccountInfo()
        {
            Console.Write("\n\n");
            Console.WriteLine("{0,-12}{1,2}{2,20}", "Account#", ": ", AccountNumber);
            Console.WriteLine("{0,-12}{1,2}{2,20}", "Owner", ": ", Owner);
            Console.WriteLine("{0,-12}{1,2}{2,20:C}", "Balance", ": ", Balance);
            Console.WriteLine("{0,-12}{1,2}{2,20}", "Type", ": ", Type.ToString());
        }
    }
}
