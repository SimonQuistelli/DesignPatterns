using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Strategy
{
    class StrategyTest
    {
        public static void TestStrategyDP()
        {
            var context = new Context(new ConcreteStrategyA());

            Console.WriteLine("Client: Strategy is set to normal sorting.");
            context.DoSomeBusinessLogic();

            Console.WriteLine();

            Console.WriteLine("Client: Strategy is set to reverse sorting.");
            context.Strategy = new ConcreteStrategyB();
            context.DoSomeBusinessLogic();
        }

        public class Context
        {
            private IStrategy _strategy;

            public IStrategy Strategy { get { return _strategy; } set { _strategy = value; } }

            public Context(IStrategy strategy)
            {
                _strategy = strategy;
            }

            public void DoSomeBusinessLogic()
            {
                Console.WriteLine("Context: Sorting data using the strategy");
                var result = this._strategy.DoAlgorithm(new List<string> { "a", "b", "c", "d", "e" });

                string resultStr = string.Empty;
                foreach (var element in result as List<string>)
                {
                    resultStr += element + ",";
                }

                Console.WriteLine(resultStr);
            }
        }

        public interface IStrategy
        {
            object DoAlgorithm(object data);
        }

        public class ConcreteStrategyA : IStrategy
        {
            public object DoAlgorithm(object data)
            {
                var list = data as List<string>;
                list.Sort();
                return list;
            }
        }

        public class ConcreteStrategyB : IStrategy
        {
            public object DoAlgorithm(object data)
            {
                var list = data as List<string>;
                list.Sort();
                list.Reverse();
                return list;
            }
        }
    }
}
