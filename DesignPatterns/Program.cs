using System;
using DesignPatterns.Singleton;
using DesignPatterns.Factory;
using DesignPatterns.Observer;
using DesignPatterns.Adapter;
using DesignPatterns.AbstractFactory;
using DesignPatterns.Builder;
using DesignPatterns.Bridge;
using DesignPatterns.Prototype;
using DesignPatterns.Composite;
using DesignPatterns.Facade;
using DesignPatterns.Decorator;
using DesignPatterns.Flyweight;
using DesignPatterns.Proxy;
using DesignPatterns.ChainOfResponsibility;
using DesignPatterns.Command;
using DesignPatterns.Iterator;
using DesignPatterns.Mediator;
using DesignPatterns.Memento;
using DesignPatterns.State;
using DesignPatterns.Strategy;
using DesignPatterns.TemplateMethod;
using DesignPatterns.Visitor;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 Singleton");
            Console.WriteLine("2 Factory");
            Console.WriteLine("3 Observer");
            Console.WriteLine("4 Adapter");
            Console.WriteLine("5 Abstract Factory");
            Console.WriteLine("6 Builder");
            Console.WriteLine("7 Bridge");
            Console.WriteLine("8 ProtoType");
            Console.WriteLine("9 Composite");
            Console.WriteLine("10 Facade");
            Console.WriteLine("11 Decorator");
            Console.WriteLine("12 Flyweight");
            Console.WriteLine("13 Proxy");
            Console.WriteLine("14 Chain of responsibility");
            Console.WriteLine("15 Command");
            Console.WriteLine("16 Iterator");
            Console.WriteLine("17 Mediator");
            Console.WriteLine("18 Memento");
            Console.WriteLine("19 State");
            Console.WriteLine("20 Strategy");
            Console.WriteLine("21 Template Method");
            Console.WriteLine("22 Visitor");
            Console.WriteLine("q Quit");

            string option = Console.ReadLine();

            while (!option.Equals("q", StringComparison.OrdinalIgnoreCase))
            {
                switch (option)
                {
                    case "1":
                        Singleton.Singleton.TestSingletonDP();
                        break;
                    case "2":
                        Factory.Factory.TestFactoryDP();
                        break;
                    case "3":
                        Observer.Observer.TestObserverDP();
                        break;
                    case "4":
                        Adapter.Adapter.TestAdapterDP();
                        break;
                    case "5":
                        AbstractFactory.AbstractFactory.TestAbractFactoryDP();
                        break;
                    case "6":
                        Builder.BuilderTest.TestBuilderDP();
                        break;
                    case "7":
                        Bridge.BridgeTest.TestBridgeDP();
                        break;
                    case "8":
                        Prototype.ProtoTypeTest.TestProtoTypeDP();
                        break;
                    case "9":
                        Composite.CompositeTest.TestCompositeDP();
                        break;
                    case "10":
                        Facade.FacadeTest.TestFacadeDP();
                        break;
                    case "11":
                        Decorator.DecoratorTest.TestDecoratorDP();
                        break;
                    case "12":
                        Flyweight.FlyweightTest.TestFlyweightDP();
                        break;
                    case "13":
                        Proxy.ProxyTest.TestProxyDP();
                        break;
                    case "14":
                        ChainOfResponsibility.ChainOfResponsibilityTest.TestChainOfResponsibilityDP();
                        break;
                    case "15":
                        CommandTest.TestCommandDP();
                        break;
                    case "16":
                        IteratorTest.TestIteratorDP();
                        break;
                    case "17":
                        MediatorTest.TestMediatorDP();
                        break;
                    case "18":
                        MementoTest.TestMementoDP();
                        break;
                    case "19":
                        StateTest.TestStateDP();
                        break;
                    case "20":
                        StrategyTest.TestStrategyDP();
                        break;
                    case "21":
                        TemplateMethodTest.TestTemplateMethodDP();
                        break;
                    case "22":
                        VisitorTest.TestVisitorDP();
                        break;
                    default:
                        Console.WriteLine("Invalid entry");
                        break;
                }

                option = Console.ReadLine();
            }
        }
    }
}
