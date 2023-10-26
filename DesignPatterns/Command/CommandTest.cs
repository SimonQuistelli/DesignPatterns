using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Command
{
    class CommandTest
    {
        public static void TestCommandDP()
        {
            Calculator calculator = new Calculator();
 
            Console.WriteLine("Calculator value start {0}", calculator.CurrentValue);
            calculator.Execute(CommandType.Add, 20);
            Console.WriteLine("Calculator value after add 20 command {0}", calculator.CurrentValue);
            calculator.Execute(CommandType.Subtract, 10);
            Console.WriteLine("Calculator value after subtract 10 command {0}", calculator.CurrentValue);
            calculator.Execute(CommandType.Multiply, 2);
            Console.WriteLine("Calculator value after multiply by 2 command {0}", calculator.CurrentValue);
            calculator.Execute(CommandType.Divide, 4);
            Console.WriteLine("Calculator value after divide by 4 command {0}", calculator.CurrentValue);
            calculator.Undo();
            Console.WriteLine("Calculator value after First Undo {0}", calculator.CurrentValue);
            calculator.Undo();
            Console.WriteLine("Calculator value after Second Undo {0}", calculator.CurrentValue);
        }
    }

    public enum CommandType
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }

    public interface ICommand
    {
        double Execute(double currentValue);
        double Undo(double currentValue);
    }

    public class CalculatorCommand : ICommand
    {
        private CommandType _commandType;
        private double _value;

        public CalculatorCommand(CommandType commandType, double value)
        {
            _commandType = commandType;
            _value = value;
        }
        public double Execute(double currentValue)
        {
            switch (_commandType)
            {
                case CommandType.Add:
                    currentValue += _value;
                    break;
                case CommandType.Subtract:
                    currentValue -= _value;
                    break;
                case CommandType.Multiply:
                    currentValue *= _value;
                    break;
                case CommandType.Divide:
                    currentValue /= _value;
                    break;
                default:
                    break;
            }
            return currentValue;
        }

        public double Undo(double currentValue)
        {
            switch (_commandType)
            {
                case CommandType.Add:
                    currentValue -= _value;
                    break;
                case CommandType.Subtract:
                    currentValue += _value;
                    break;
                case CommandType.Multiply:
                    currentValue /= _value;
                    break;
                case CommandType.Divide:
                    currentValue *= _value;
                    break;
                default:
                    break;
            }
            return currentValue;
        }
    }

    public class Calculator
    {
        private Stack<ICommand> _commands;
        public double CurrentValue { get; set; }

        public Calculator()
        {
            CurrentValue = 0.0;
            _commands = new Stack<ICommand>();
        }

        public void Execute(CommandType commandType, double value)
        {
            ICommand command = new CalculatorCommand(commandType, value);

            CurrentValue = command.Execute(CurrentValue);
            _commands.Push(command);
        }

        public void Undo()
        {
            ICommand command = _commands.Pop();
            CurrentValue = command.Undo(CurrentValue);
        }
    }
}
