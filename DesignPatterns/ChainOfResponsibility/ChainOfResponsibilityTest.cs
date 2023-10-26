using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ChainOfResponsibility
{
    class ChainOfResponsibilityTest
    {
        public static void TestChainOfResponsibilityDP()
        {
            MonkeyHandler monkey = new MonkeyHandler();
            SquirrelHandler squirrel = new SquirrelHandler();
            DogHandler dog = new DogHandler();

            monkey.Handler = squirrel;
            squirrel.Handler = dog;

            Client.ClientCode(monkey);
            Client.ClientCode(squirrel);
        }

        public interface IHandler
        {
            //void SetNext(IHandler handler);
            //IHandler _nextHandler;
            IHandler Handler { set; }

            bool ProcessRequest(string request);
        }

        public abstract class AbstractHandler : IHandler
        {
            private IHandler _nextHandler;

            public IHandler Handler { set { _nextHandler = value; } }

            public virtual bool ProcessRequest(string request)
            {
                bool requestHandled = false;

                if (this._nextHandler != null)
                {
                    requestHandled = _nextHandler.ProcessRequest(request);
                    return requestHandled;
                }
                else
                {
                    return requestHandled;
                }
            }

            //public void SetNext(IHandler handler)
            //{
            //    _nextHandler = handler
            //}
        }

        public class MonkeyHandler : AbstractHandler
        {
            public override bool ProcessRequest(string request)
            {
                if (request == "banana")
                {
                    Console.WriteLine("Monkey will eat banana");
                    return true;
                }
                return base.ProcessRequest(request);
            }
        }

        public class SquirrelHandler : AbstractHandler
        {
            public override bool ProcessRequest(string request)
            {
                if (request == "nut")
                {
                    Console.WriteLine("Squirrel will eat nut");
                    return true;
                }
                return base.ProcessRequest(request);
            }
        }

        public class DogHandler : AbstractHandler
        {
            public override bool ProcessRequest(string request)
            {
                if (request == "meatball")
                {
                    Console.WriteLine("Dog will eat meatball");
                    return true;
                }
                return base.ProcessRequest(request);
            }
        }

        public class Client
        {
            public static void ClientCode(IHandler handler)
            {
                List<string> foodItems = new List<string> { "nut", "banana", "apple"};

                foreach (string foodItem in foodItems)
                {
                    if (!handler.ProcessRequest(foodItem))
                    {
                        Console.WriteLine("Food item {0} has not been processed", foodItem);
                    }
                }
            }
        }
    }
}
