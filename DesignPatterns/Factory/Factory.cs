using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    class Factory
    {
        public static void TestFactoryDP()
        {
            CarFactory carFactory = new ConcreateCarFactory();

            ICar mini = carFactory.CreateCar("Mini");
            mini.PrintPerformance();
            ICar ferrari = carFactory.CreateCar("Ferrari");
            ferrari.PrintPerformance();
        }
    }

    public interface ICar
    {
        void PrintPerformance();
    }

    public class Car : ICar
    {
        public int TopSpeed { get; set; }
        public double Accelaration { get; set; }

        public void PrintPerformance()
        {
            Console.WriteLine("Top speed = {0}", TopSpeed);
            Console.WriteLine("0 to 60 = {0}", Accelaration);
        }
    }
    public class Mini : Car
    {
        public Mini()
        {
            TopSpeed = 100;
            Accelaration = 9.5;
        }
    }

    public class Ferrari : Car
    {
        public Ferrari()
        {
            TopSpeed = 190;
            Accelaration = 4.5;
        }
    }

    abstract class CarFactory
    {
        public abstract ICar CreateCar(string make);
    }

    class ConcreateCarFactory : CarFactory
    {
        public override ICar CreateCar(string make)
        {
            switch (make)
            {
                case "Mini":
                    return new Mini();
                case "Ferrari":
                    return new Ferrari();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", make));
            }
        }
    }
}
