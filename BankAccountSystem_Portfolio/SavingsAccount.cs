using P13;

public class SavingsAccount : BankAccount, IInterestBearingAccount
{
    private decimal interestRate;

    public SavingsAccount(string accountNumber, string owner, decimal initialDeposit, decimal interestRate)
        : base(accountNumber, owner, initialDeposit, AccountType.Savings)
    {
        this.interestRate = interestRate;
    }

    public void AddInterest()
    {
        decimal decimalInterestRate = interestRate / 100m;
        decimal interest = Balance * decimalInterestRate * (1m / 12m);
        Balance += interest;
        Console.WriteLine("{0,-12}{1,2}{2,20:N2}", "Interest", ": ", interest);
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public void Withdrawal(decimal amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine("Can't withdraw more than the available balance.");
        }
        else
        {
            Balance -= amount;
            Console.WriteLine("{0,-12}{1,2}{2,20:N2}", "Withdrawn", ": ", amount);
        }
    }

    public void AccountInfo()
    {
        Console.WriteLine($"Account#    :           {AccountNumber}");
        Console.WriteLine($"Owner       :           {Owner}");
        Console.WriteLine($"Balance     :            {Balance:C}");
        Console.WriteLine($"Type        :              {this.Type.ToString()}");
    }
}

