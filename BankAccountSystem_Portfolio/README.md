# 💰 Bank Account Management System

A console-based C# application that simulates a simple **bank account management system**.  
This project demonstrates **Object-Oriented Programming (OOP)** principles such as inheritance, abstraction, polymorphism, and interfaces.

---

## 🧠 Overview
Users can create and manage different types of bank accounts — **Checking**, **Savings**, and **Money Market** — and perform basic transactions like deposits, withdrawals, and interest calculations.  

This project was built to demonstrate OOP design in a realistic banking scenario using **.NET** and **C#**.

---

## 🏗️ Features
- Abstract base class `BankAccount` for shared logic and data  
- Derived classes for account-specific behavior:
  - **CheckingAccount:** Enforces withdrawal limits and overdraft prevention  
  - **SavingsAccount:** Earns monthly interest  
  - **MoneyMarketAccount:** Enforces minimum balance for interest eligibility  
- Implements interface `IInterestBearingAccount` for consistent interest logic  
- Robust input validation and exception handling  
- Clear console-based menu navigation  

---

## 🧩 Project Structure
```
BankAccountSystem/
├── AccountType.cs              # Enum for account types
├── BankAccount.cs              # Abstract base class
├── CheckingAccount.cs          # Checking account with withdrawal limits
├── SavingsAccount.cs           # Savings with interest
├── MoneyMarketAccount.cs       # Money market with minimum balance
├── IInterestBearingAccount.cs  # Interest interface
├── Program.cs                  # Main menu and program logic
├── P13.csproj
├── P13.sln
└── Images/                     # Screenshots for documentation
```

---

## 🧮 Sample Output
```
P13   Cameron Russo   

Enter the letter of the desired menu option.
  A: Create a checking account
  B: Create a savings account
  C: Create a money market account
  X: Exit the bank account module

Choice: A

Enter 10 digit account number:  1234567890
Enter account owner:  Cameron Russo
Enter account balance:  1000

Deposited  :               250.00
Withdrawn  :               500.00

Account#    :           1234567890
Owner       :           Cameron Russo
Balance     :            $750.00
Type        :              Checking
```

---

## 🛠️ Technologies Used
- **Language:** C# (.NET 6 / .NET Core)
- **IDE:** Visual Studio
- **Concepts:** OOP, abstraction, polymorphism, interfaces, exception handling, user input validation

---

## 🧰 Skills Demonstrated
- Class inheritance and encapsulation  
- Virtual and overridden methods  
- Interface design and implementation  
- Console input/output handling  
- Error validation and data consistency  

---

## 🚀 How to Run
1. Open the solution file `P13.sln` in Visual Studio.  
2. Press **F5** or **Run** to start the program.  
3. Follow the console prompts to create and manage accounts.

---

## 🧠 Future Enhancements
- Add data persistence (JSON or SQL storage)  
- Develop a GUI version using WinForms or WPF  
- Include transaction logs and authentication  

---

> 📁 *Created by Cameron Russo*  
> Data Analytics & Programming Student | Mesa Community College  
> [LinkedIn](https://www.linkedin.com/in/your-link-here)
