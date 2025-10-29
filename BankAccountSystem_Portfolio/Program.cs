namespace P13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("P13   Cameron Russo   \n\n");
            try
            {
                char choice;

                do
                {
                    Console.Write("Enter the letter of the desired menu option.\n" +
                                  "Press the Enter key after entering the letter.\n\n" +
                                  "  A: Create a checking account\n" +
                                  "  B: Create a savings account\n" +
                                  "  C: Create a money market account\n\n" +
                                  "  X: Exit the bank account module\n\n" +
                                  "Choice: ");

                    choice = char.ToUpper(Console.ReadKey().KeyChar);

                    Console.Write("\n\n");

                    switch (choice)
                    {
                        case 'A':
                            CreateCheckingAccount();
                            break;
                        case 'B':
                            CreateSavingsAccount();
                            break;
                        case 'C':
                            CreateMoneyMarketAccount();
                            break;
                        case 'X':
                            Console.WriteLine("\n\nNow exiting bank account module...please wait.\n\n");
                            break;
                        default:
                            Console.WriteLine("\a\n\n Invalid option entered - Please try again.\n\n");
                            break;
                    }

                } while (choice != 'X');
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\n{ex.Message}");
            }
        }

        static string InputOwner()
        {
            string owner;
            do
            {
                Console.Write("Enter account owner:  ");
                owner = Console.ReadLine();
            } while (string.IsNullOrEmpty(owner));

            return owner;
        }

        static string InputAccountNumber()
        {
            string accountNumber;
            do
            {
                Console.Write("Enter 10 digit account number:  ");
                accountNumber = Console.ReadLine();
            } while (string.IsNullOrEmpty(accountNumber) || accountNumber.Length != 10);

            return accountNumber;
        }

        static decimal InputBalance()
        {
            decimal balance;
            do
            {
                Console.Write("Enter account balance:  ");
            } while (!decimal.TryParse(Console.ReadLine(), out balance) && balance > 0);

            return balance;
        }

        static decimal InputInterestRate()
        {
            decimal interestRate;
            do
            {
                Console.Write("Enter interest rate (as a percentage, e.g., 3 for 3%): ");
            } while (!decimal.TryParse(Console.ReadLine(), out interestRate) || interestRate <= 0);
            return interestRate;
        }

        static decimal InputMinimumBalance()
        {
            decimal minBalance;
            do
            {
                Console.Write("Enter minimum balance for the account:  ");
            } while (!decimal.TryParse(Console.ReadLine(), out minBalance) || minBalance <= 0);

            return minBalance;
        }

        static void MakeDeposit(BankAccount bankAccount)
        {
            decimal amount;
            do
            {
                Console.Write("\n\nEnter deposit amount:  ");
            } while (!decimal.TryParse(Console.ReadLine(), out amount) && amount > 0);

            Console.Write("\n\n");

            bankAccount.Deposit(amount);
        }

        static void MakeWithdrawal(BankAccount bankAccount)
        {
            decimal amount;
            do
            {
                Console.Write("\n\nEnter withdrawal amount:  ");
            } while (!decimal.TryParse(Console.ReadLine(), out amount) && amount <= 0);

            Console.Write("\n\n");

            bankAccount.Withdrawal(amount);
        }

        static void DisplayContinuePrompt()
        {
            Console.WriteLine("\n\nBank account module completed. Press Enter to continue: ");
            Console.ReadLine();
            Console.Clear();
        }

        static void CreateCheckingAccount()
        {
            string accountNumber = InputAccountNumber();
            string owner = InputOwner();
            decimal balance = InputBalance();
            CheckingAccount checkingAccount = new CheckingAccount(accountNumber, owner, balance);
            checkingAccount.AccountInfo();
            MakeDeposit(checkingAccount);
            MakeWithdrawal(checkingAccount);
            checkingAccount.AccountInfo();
            DisplayContinuePrompt();
        }

        static void CreateSavingsAccount()
        {
            string accountNumber = InputAccountNumber();
            string owner = InputOwner();
            decimal balance = InputBalance();
            decimal interestRate = InputInterestRate();
            SavingsAccount savingsAccount = new SavingsAccount(accountNumber, owner, balance, interestRate);
            savingsAccount.AccountInfo();
            MakeDeposit(savingsAccount);
            savingsAccount.AddInterest();
            MakeWithdrawal(savingsAccount);
            savingsAccount.AccountInfo();
            DisplayContinuePrompt();
        }

        static void CreateMoneyMarketAccount()
        {
            string accountNumber = InputAccountNumber();
            string owner = InputOwner();
            decimal balance = InputBalance();
            decimal interestRate = InputInterestRate();
            decimal minimumBalance = InputMinimumBalance();
            MoneyMarketAccount moneyMarketAccount = new MoneyMarketAccount(accountNumber, owner, balance, interestRate, minimumBalance);
            moneyMarketAccount.AccountInfo();
            MakeDeposit(moneyMarketAccount);
            moneyMarketAccount.AddInterest();
            MakeWithdrawal(moneyMarketAccount);
            moneyMarketAccount.AccountInfo();
            DisplayContinuePrompt();
        }
    }
}
