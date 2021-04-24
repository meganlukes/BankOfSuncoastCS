using System;
using CsvHelper;
using System.Collections.Generic;
using System.Linq;

namespace BankOfSuncoastCS
{
    class Transaction
    {
        public string Account { get; set; }
        public int TransactionAmount { get; set; }
    }
    class Program
    {
        static int AccountBalance(List<Transaction> TList, string account)
        {
            //formula for acccount balance
            int balance = 0;
            return balance;
        }
        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();
            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);
            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }
        static List<Transaction> newTransaction(List<Transaction> TList, int transacttype, string account)
        {
            var newTransact = new Transaction();
            newTransact.Account = account;
            string depOrWith;
            if (transacttype > 0)
            {
                depOrWith = "withdraw";
            }
            else
            {
                depOrWith = "deposit";
            }
            Console.WriteLine($"How much would you like to {depOrWith}?");
            var provAmountString = Console.ReadLine();
            var provAmount = int.Parse(provAmountString);
            if (depOrWith == "deposit")
            {
                newTransact.TransactionAmount = provAmount;
            }
            else   //withdraw
            {
                var accountBalance = 0; //replace with var accountBalance = AccountBalance(TransactionList, account,);
                while (accountBalance < provAmount)
                {
                    Console.WriteLine($"You can't withdraw more money than is currently in your account. Your account balance is {accountBalance}, please enter a withdrawal amount that is less than or equal to your account balance.");
                    provAmountString = Console.ReadLine();
                    provAmount = int.Parse(provAmountString);
                }
                newTransact.TransactionAmount = provAmount;
            }
            TList.Add(newTransact);
            return TList;
        }
        static void Main(string[] args)
        {
            var transactionsList = new List<Transaction>();
            bool running = true;
            Console.WriteLine("Welcome to the First Bank of Suncoast.");
            while (running == true)
            {
                Console.WriteLine("Would you like to check an account (B)alance, make a (T)ransaction, or (Q)uit?");
                var selection = Console.ReadLine().ToUpper();
                if (selection == "B")
                {
                    Console.WriteLine("Would you like to check the balance of your (C)hecking account or your (S)avings account?");
                    var choice = Console.ReadLine().ToUpper();
                    if (choice == "C")
                    {
                        //balance method
                    }
                    else if (choice == "S")
                    {
                        //balance method
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection.");
                    }
                }
                else if (selection == "T")
                {
                    Console.WriteLine("Would you like to make a (D)eposit or a (W)ithdrawal?");
                    var choice = Console.ReadLine().ToUpper();
                    if (choice == "D") //Deposit
                    {
                        Console.WriteLine("Would you like to make a deposit into you (C)hecking account or your (S)avings account?");
                        var option = Console.ReadLine().ToUpper();
                        if (option == "C")   //Deposit into Checking
                        {
                            newTransaction(transactionsList, -1, "Checking");
                        }
                        else if (option == "D")   //Deposit into Savings
                        {
                            newTransaction(transactionsList, -1, "Savings");
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection.");
                        }
                    }
                    else if (choice == "W")   //Withdraw
                    {
                        Console.WriteLine("Would you like to make a withdrawal from your (C)hecking account or your (S)avings account?");
                        var option = Console.ReadLine().ToUpper();
                        if (option == "C")
                        {
                            newTransaction(transactionsList, 1, "Checking");
                        }
                        else if (option == "D")
                        {
                            newTransaction(transactionsList, 1, "Savings");
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection.");
                        }
                    }

                }
                else
                {
                    running = false;
                }


            }


        }
    }
}
