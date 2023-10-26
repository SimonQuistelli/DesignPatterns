using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Mediator
{
    class MediatorTest
    {
        public static void TestMediatorDP()
        {
            Mediator mediator = new Mediator();

            Colleague1 c1 = new Colleague1(mediator);
            Colleague2 c2 = new Colleague2(mediator);

            mediator.Colleague1 = c1;
            mediator.Colleague2 = c2;

            c1.Send("How are you?");
            c2.Send("Fine Thanks");
        }
    }

    public interface IMediator
    {
        void Send(string message, Colleague colleague);
    }

    public class Mediator : IMediator
    {
        private Colleague1 _colleague1;
        private Colleague2 _colleague2;

        public Colleague1 Colleague1
        {
            set { _colleague1 = value; }
        }

        public Colleague2 Colleague2
        {
            set { _colleague2 = value; }
        }
        public void Send(string message, Colleague colleague)
        {
            if (colleague == _colleague1)
            {
                _colleague2.Notify(message);
            }

            if (colleague == _colleague2)
            {
                _colleague1.Notify(message);
            }
        }
    }

    public abstract class Colleague
    {
        protected IMediator _mediator;

        public Colleague(IMediator mediator)
        {
            _mediator = mediator;
        }
    }

    public class Colleague1 : Colleague
    {
        public Colleague1(Mediator mediator) : base(mediator)
        {
        }

        public void Send(string message)
        {
            Console.WriteLine("Colleague1 sends message {0}", message);
            _mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("Colleague1 receives message {0}", message);
        }
    }

    public class Colleague2 : Colleague
    {
        public Colleague2(Mediator mediator) : base(mediator)
        {
        }

        public void Send(string message)
        {
            Console.WriteLine("Colleague2 sends message {0}", message);
            _mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("Colleague2 receives message {0}", message);
        }
    }


}
