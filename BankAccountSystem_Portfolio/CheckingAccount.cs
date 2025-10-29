using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P13
{
    public class CheckingAccount : BankAccount
    {
        // Constructor
        public CheckingAccount(string accountNumber, string owner, decimal initialDeposit)
            : base(accountNumber, owner, initialDeposit, AccountType.Checking)
        {
        }

        // Override Withdrawal method to handle specific logic for checking accounts
        public override void Withdrawal(decimal amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("\nCan't withdraw due to insufficient funds");
                return;
            }

            const decimal WithdrawalLimit = 1000m;
            if (amount > WithdrawalLimit)
            {
                Console.WriteLine("\nCan't withdraw more than {0:N2}", WithdrawalLimit);
                return;
            }

            // Call the base class Withdrawal method
            base.Withdrawal(amount);
        }
    }
}

