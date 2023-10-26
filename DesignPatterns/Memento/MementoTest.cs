using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.Memento
{
    class MementoTest
    {
        public static void TestMementoDP()
        {
            Originator originator = new Originator();
            Caretaker caretaker = new Caretaker(originator);

            //Console.WriteLine("Originator current {0}", originator.State);
            originator.DoSomething();
            Console.WriteLine();
            caretaker.Backup();
            Console.WriteLine();
            originator.DoSomething();
            Console.WriteLine();
            caretaker.Backup();
            Console.WriteLine();
            originator.DoSomething();
            Console.WriteLine();
            caretaker.Backup();
            Console.WriteLine();
            caretaker.ShowBackups();
            Console.WriteLine();
            caretaker.Undo();
            Console.WriteLine();
            caretaker.ShowBackups();
            Console.WriteLine();
            caretaker.Undo();
            Console.WriteLine();
            caretaker.ShowBackups();
        }
    }

    class Originator
    {
        private string _state;

        public string State { get { return _state; } }

        public Originator()
        {
            _state = null;
        }
        public void DoSomething()
        {
            if (_state == null)
            {
                _state = "State 1";
            }
            else
            {
                string[] split = _state.Split(' ');

                if (split.Length == 2)
                {
                    int i = Convert.ToInt32(split[1]);
                    i++;
                    _state = $"State {i}";
                }
            }

            Console.WriteLine("Do something originator {0}", _state);
            Thread.Sleep(1000);
        }

        public IMemento Save()
        {
            return new ConcreateMemento(_state);
        }

        public void Restore(IMemento memento)
        {
            _state = memento.State;
        }
    }

    interface IMemento
    {
        string State { get; }

        DateTime Date { get; }
    }

    class ConcreateMemento : IMemento
    {
        public string State { get; }

        public DateTime Date { get; }

        public ConcreateMemento(string state)
        {
            State = state;
            Date = DateTime.Now;
        }
    }

    class Caretaker
    {
        private List<IMemento> _mementos;
        private Originator _originator;

        public Caretaker(Originator originator)
        {
            _mementos = new List<IMemento>();
            _originator = originator;
        }

        public void Backup()
        {
            Console.WriteLine("Caretaker backup originator {0}", _originator.State);
            _mementos.Add(_originator.Save());
        }

        public void Undo()
        {
            if (_mementos.Count() == 0)
                return;

            IMemento last = _mementos.Last();
            _mementos.Remove(last);
            last = _mementos.Last();

            Console.WriteLine("Undo restore originator {0}", last.State);
            _originator.Restore(last);
        }

        public void ShowBackups()
        {
            Console.WriteLine("Show Backups");

            foreach (IMemento memento in _mementos)
            {
                Console.WriteLine("{0} {1}", memento.State, memento.Date);
            }
        }
    }
}
