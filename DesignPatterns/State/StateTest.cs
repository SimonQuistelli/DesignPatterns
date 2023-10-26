using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.State
{
    class StateTest
    {
        public static void TestStateDP()
        {
            Account account = new Account("John Smith");
            account.Deposit(100);
            account.AccountInfo();
            account.Deposit(1000);
            account.AccountInfo();
            account.PayIntrest();
            account.AccountInfo();
            account.Withdraw(1500);
            account.AccountInfo();
            account.Withdraw(1000);
            account.AccountInfo();
        }

        public abstract class State
        {
            protected double _balance;
            public string StateName { get; init; }
            public Account BankAccount { get; set; }
            public double Balance { get { return _balance; } }
            public double IntrestRate { get; init; }

            public double RedLowerLimit { get; init; }
            public double RedUpperLimit { get; init; }

            public double SilverLowerLimit { get; init; }

            public double SilverUpperLimit { get; init; }

            public double GoldLowerLimit { get; init; }
            public double GoldUpperLimit { get; init; }

            public State()
            {
                RedLowerLimit = -1000;
                RedUpperLimit = 0.0;
                SilverLowerLimit = 0.0;
                SilverUpperLimit = 1000;
            }

            public virtual void Deposit(double amount)
            {
                Console.WriteLine("Deposit {0:C}", amount);
                Console.WriteLine();
                _balance += amount;
            }

            public virtual void Withdraw(double amount)
            {
                if ((_balance - amount) < RedLowerLimit)
                {
                    Console.WriteLine("Withdraw {0:C} Unable to withdraw due to insuffiant funds", amount);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Withdraw {0:C}", amount);
                    Console.WriteLine();
                    _balance -= amount;
                }
            }

            public virtual void PayInterest()
            {
                double interest = _balance * (IntrestRate / 100);
                Console.WriteLine("Pay interest {0:C}", interest);
                Console.WriteLine();
                _balance += interest;
            }
        }

        public class RedState : State
        {
            public RedState(State state)
            {
                StateName = "Red";
                BankAccount = state.BankAccount;
                _balance = state.Balance;
                IntrestRate = 1.0;
            }

            public override void Deposit(double amount)
            {
                base.Deposit(amount);
                StateChangeCheck();
            }

            public override void Withdraw(double amount)
            {
                base.Withdraw(amount);
                StateChangeCheck();
            }

            public override void PayInterest()
            {
                base.PayInterest();
                StateChangeCheck();
            }

            public void StateChangeCheck()
            {
                if (Balance > SilverLowerLimit &&  Balance < SilverUpperLimit)
                {
                    BankAccount.state = new SilverState(BankAccount.state);
                }
                else if (Balance > GoldLowerLimit)
                {
                    BankAccount.state = new GoldState(BankAccount.state);
                }
            }
        }

        public class SilverState : State
        {
            public SilverState(Account account)
            {
                StateName = "Silver";
                BankAccount = account;
                _balance = 0.0;
                IntrestRate = 1.0;
            }

            public SilverState(State state)
            {
                StateName = "Silver";
                BankAccount = state.BankAccount;
                _balance = state.Balance;
                IntrestRate = 1.0;
            }

            public override void Deposit(double amount)
            {
                base.Deposit(amount);
                StateChangeCheck();
            }

            public override void Withdraw(double amount)
            {
                base.Withdraw(amount);
                StateChangeCheck();
            }

            public override void PayInterest()
            {
                base.PayInterest();
                StateChangeCheck();
            }

            public void StateChangeCheck()
            {
                if (Balance > SilverUpperLimit)
                {
                    BankAccount.state = new GoldState(BankAccount.state);
                }
                else if (Balance < SilverLowerLimit)
                {
                    BankAccount.state = new RedState(BankAccount.state);
                }
            }
        }

        public class GoldState : State
        {
            public GoldState(State state)
            {
                StateName = "Gold";
                BankAccount = state.BankAccount;
                _balance = state.Balance;
                IntrestRate = 2.0;
            }

            public override void Deposit(double amount)
            {
                base.Deposit(amount);
                StateChangeCheck();
            }

            public override void Withdraw(double amount)
            {
                base.Withdraw(amount);
                StateChangeCheck();
            }

            public override void PayInterest()
            {
                base.PayInterest();
                StateChangeCheck();
            }

            public void StateChangeCheck()
            {
                if (Balance >= SilverLowerLimit && Balance < SilverUpperLimit)
                {
                    BankAccount.state = new SilverState(BankAccount.state);
                }
                else if (Balance < SilverLowerLimit)
                {
                    BankAccount.state = new RedState(BankAccount.state);
                }
            }
        }

        public class Account
        {
            public string Name { get; }

            public double OverdraftLimit { get; set; }

            public State state { get; set; }


            public Account(string name)
            {
                Name = name;
                OverdraftLimit = 1000;
                state = new SilverState(this);
            }

            public void Deposit(double amount)
            {
                state.Deposit(amount);
            }

            public void Withdraw(double amount)
            {
                state.Withdraw(amount);
            }

            public void PayIntrest()
            {
                state.PayInterest();
            }

            public void AccountInfo()
            {
                Console.WriteLine("Account name: {0}", Name);
                Console.WriteLine("Account state: {0}", state.StateName);
                Console.WriteLine("Balance: {0:C}", state.Balance);
                Console.WriteLine("Intrest Rate: {0}%", state.IntrestRate);
                Console.WriteLine();
            }
        }
    }
}
