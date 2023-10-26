using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder
{
    public class BuilderTest
    {
        public static void TestBuilderDP()
        {
            CarBuilder carBuilderBasic = new CarBuilder(new BuildBasicCar());
            CarBuilder carBuilderPremium = new CarBuilder(new BuildPremiumCar());

            carBuilderBasic.BuildCar();
            Car basicCar = carBuilderBasic.GetCar();
            Console.WriteLine("Basic Car Info");
            Console.WriteLine();
            basicCar.DisplayCarInfo();
            Console.WriteLine();

            Console.WriteLine("Premium Car Info");
            Console.WriteLine();
            carBuilderPremium.BuildCar();
            Car premiumCar = carBuilderPremium.GetCar();
            premiumCar.DisplayCarInfo();
        }
    }

    public class Car
    {
        public int Seats { get; set; }
        public int Doors { get; set;  }
        public string Engine { get; set;  }

        public string Transmission { get; set; } 
        public List<string> Accessories { get; }

        public Car()
        {
            Accessories = new List<string>();
        }

        public void DisplayCarInfo()
        {
            Console.WriteLine("Number of Seats {0}", Seats);
            Console.WriteLine("Number of Doors {0}", Doors);
            Console.WriteLine("Engine {0}", Engine);
            Console.WriteLine("Transmission {0}", Transmission);
            Console.WriteLine("Accessories");

            foreach (string a in Accessories)
            {
                Console.WriteLine("  " + a);
            }
        }
    }

    public interface ICarBuilder
    {
        void SetSeats();
        void SetDoors();
        void SetEngine();
        void SetTransmission();
        void SetAccessories();
        Car GetCar();
    }

    class BuildBasicCar : ICarBuilder
    {
        private Car _car;

        public BuildBasicCar()
        {
            _car = new Car();
        }
        public void SetSeats()
        {
            _car.Seats = 4;
        }

        public void SetDoors()
        {
            _car.Doors = 2;
        }

        public void SetEngine()
        {
            _car.Engine = "1.2 liter 4pot";
        }

        public void SetTransmission()
        {
            _car.Transmission = "Manual";
        }

        public void SetAccessories()
        {
            _car.Accessories.Add("Radio");
        }

        public Car GetCar()
        {
            return _car;
        }
    }

    class BuildPremiumCar : ICarBuilder
    {
        private Car _car;

        public BuildPremiumCar()
        {
            _car = new Car();
        }
        public void SetSeats()
        {
            _car.Seats = 5;
        }

        public void SetDoors()
        {
            _car.Doors = 4;
        }

        public void SetEngine()
        {
            _car.Engine = "3 liter V6";
        }

        public void SetTransmission()
        {
            _car.Transmission = "Automatic";
        }

        public void SetAccessories()
        {
            _car.Accessories.Add("CD Radio");
            _car.Accessories.Add("Climate Control");
            _car.Accessories.Add("Sat Nav");
        }

        public Car GetCar()
        {
            return _car;
        }
    }

    // Director
    public class CarBuilder
    {
        private ICarBuilder _carBuilder;

        public CarBuilder(ICarBuilder carBuilder)
        {
            _carBuilder = carBuilder;
        }

        public void BuildCar()
        {
            _carBuilder.SetSeats();
            _carBuilder.SetDoors();
            _carBuilder.SetEngine();
            _carBuilder.SetTransmission();
            _carBuilder.SetAccessories();
        }
        public Car GetCar()
        {
            return _carBuilder.GetCar();
        }
    }

    //public class Wall
    //{
    //    public string Name => "Wall";
    //}

    //public class Roof
    //{
    //    public string Name => "Roof";
    //}

    //public class Conservatry
    //{
    //    public string Name => "Conseratry";
    //}

    //public class Garage
    //{
    //    public string Name => "Garage";
    //}

    //public class House
    //{
    //    public List<Wall> Walls { get; }
    //    public Roof Roof { get; }

    //    public 
    //}
}
