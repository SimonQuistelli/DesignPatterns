using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Composite
{
    class CompositeTest
    {
        public static void TestCompositeDP()
        {
            Box mainBox = new Box();

            Product apple = new Product("Apple", 0.5);
            Product pear = new Product("Pear", 0.4);

            mainBox.Add(apple);
            mainBox.Add(pear);

            Box subBoxA = new Box();

            Product tomoto = new Product("Tomoto", 0.6);
            Product lettice = new Product("Lettice", 0.7);

            subBoxA.Add(tomoto);
            subBoxA.Add(lettice);

            Product cabbage = new Product("Cabbage", 0.65);
            Product cauliflower = new Product("Caulifower", 0.75);

            Box subBoxB = new Box();

            subBoxB.Add(cabbage);
            subBoxB.Add(cauliflower);

            subBoxA.Add(subBoxB);

            mainBox.Add(subBoxA);

            double total = Math.Round(mainBox.CalculatePrice(), 2);
            Console.WriteLine("Total Price {0}", total);
        }
    }

    interface IComponent
    {
        string Name { get; init; }
        double CalculatePrice();
    }

    class Product : IComponent
    {
        public string Name { get; init; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public double CalculatePrice()
        {
            return Price;
        }
    }

    class Box : IComponent
    {
        public string Name { get; init; }

        private List<IComponent> _components;

        public Box()
        {
            Name = "Box";
            _components = new List<IComponent>();
        }

        public void Add(IComponent component)
        {
            _components.Add(component);
        }

        public void Remove(IComponent component)
        {
            _components.Remove(component);
        }

        public double CalculatePrice()
        {
            double total = 0.0;

            foreach (IComponent c in _components)
            {
                total += c.CalculatePrice();
            }

            return total;
        }
    }
}
