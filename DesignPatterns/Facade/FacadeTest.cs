using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Facade
{
    class FacadeTest
    {
        public static void TestFacadeDP()
        {
            Customer customer = new Customer("John Smith");
            Mortgage mortgage = new Mortgage();

            Console.WriteLine("Customer {0} applies for mortgage", customer.Name);
            bool elegible = mortgage.IsEligible(customer);

            if (elegible)
            {
                Console.WriteLine("Customer mortgage is approved");
            }
        }
    }

    public class Bank
    {
        public bool HasSufficientSavings(Customer customer)
        {
            Console.WriteLine("Customer {0} has sufficient funds", customer.Name);
            return true;
        }
    }

    public class Credit
    {
        public bool HasGoodCredit(Customer customer)
        {
            Console.WriteLine("Customer {0} has good credit ", customer.Name);
            return true;
        }
    }

    public class Customer
    {
        private string name;

        public Customer(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return name; }
        }
    }

    public class Mortgage
    {
        private Bank bank;
        private Credit credit;

        public Mortgage()
        {
            bank = new Bank();
            credit = new Credit();
        }

        public bool IsEligible(Customer customer)
        {
            bool eligible = true;

            if (!bank.HasSufficientSavings(customer))
            {
                eligible = false;
            }

            if (!credit.HasGoodCredit(customer))
            {
                eligible = false;
            }

            return eligible;
        }
    }
}
