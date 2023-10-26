using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.AbstractFactory
{
    class AbstractFactory
    {
        public static void TestAbractFactoryDP()
        {
            ProductFactory1 productFactort1 = new ProductFactory1();

            IProductA productA = productFactort1.CreateProductA();
            IProductB productB = productFactort1.CreateProductB();

            productA.DoSomething();
            productB.DoSomething();

            ProductFactory2 productFactort2 = new ProductFactory2();

            productA = productFactort2.CreateProductA();
            productB = productFactort2.CreateProductB();

            productA.DoSomething();
            productB.DoSomething();
        }
    }

    public interface IProductA
    {
        void DoSomething();
    }

    public interface IProductB
    {
        void DoSomething();
    }

    public class ProductA1 : IProductA
    {
        public void DoSomething()
        {
            Console.WriteLine("Do something Product A1");
        }
    }

    public class ProductB1 : IProductB
    {
        public void DoSomething()
        {
            Console.WriteLine("Do something Product B1");
        }
    }

    public class ProductA2 : IProductA
    {
        public void DoSomething()
        {
            Console.WriteLine("Do something Product A2");
        }
    }

    public class ProductB2 : IProductB
    {
        public void DoSomething()
        {
            Console.WriteLine("Do something Product B2");
        }
    }

    public interface IProductFactory
    {
        IProductA CreateProductA();

        IProductB CreateProductB();
    }


    public class ProductFactory1 : IProductFactory
    {
        public IProductA CreateProductA()
        {
            return new ProductA1();
        }

        public IProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    public class ProductFactory2 : IProductFactory
    {
        public IProductA CreateProductA()
        {
            return new ProductA2();
        }

        public IProductB CreateProductB()
        {
            return new ProductB2();
        }
    }
}
