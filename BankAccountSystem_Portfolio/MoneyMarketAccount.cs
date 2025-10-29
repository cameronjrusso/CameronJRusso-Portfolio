using P13;

public class MoneyMarketAccount : BankAccount, IInterestBearingAccount
{
    private decimal interestRate;  // Field to store interest rate
    private decimal minimumBalance;  // Field to store minimum balance requirement

    // Updated constructor with interestRate and minimumBalance as parameters
    public MoneyMarketAccount(string accountNumber, string owner, decimal initialDeposit, decimal interestRate, decimal minimumBalance)
        : base(accountNumber, owner, initialDeposit, AccountType.MoneyMarket)  // Pass AccountType.MoneyMarket
    {
        this.interestRate = interestRate;  // Store the interest rate
        this.minimumBalance = minimumBalance;  // Store the minimum balance requirement
    }

    public void AddInterest()
    {
        if (Balance < minimumBalance + 500m)
        {
            Console.WriteLine("Your balance does not meet the requirements to earn interest.");
            return;
        }

        // Ensure the interest rate is in decimal format
        decimal decimalInterestRate = interestRate / 100m;  // Convert percentage to decimal

        // Calculate one month of interest (using simple interest formula A = P + I = P + Prt)
        decimal interest = Balance * decimalInterestRate * (1m / 12m);  // Monthly interest calculation
        Balance += interest;

        // Display the calculated interest
        Console.WriteLine("{0,-12}{1,2}{2,20:N2}", "Interest", ": ", interest);
    }

    public void AccountInfo()
    {
        Console.WriteLine($"Account#    :           {AccountNumber}");
        Console.WriteLine($"Owner       :           {Owner}");
        Console.WriteLine($"Balance     :            {Balance:C}");
        Console.WriteLine($"Type        :              {this.Type.ToString()}");
    }
}
