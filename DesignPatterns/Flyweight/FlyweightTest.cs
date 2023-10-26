using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Flyweight
{
    class FlyweightTest
    {
        public static void TestFlyweightDP()
        {
            ShapeFactory shapeFactory = new ShapeFactory();

            IShape shape;
            shape = shapeFactory.GetShape("Rectangle");
            shape.Draw();
            shape = shapeFactory.GetShape("Rectangle");
            shape.Draw();
            shape = shapeFactory.GetShape("Rectangle");
            shape.Draw();
            shape = shapeFactory.GetShape("Circle");
            shape.Draw();
            shape = shapeFactory.GetShape("Circle");
            shape.Draw();
            shape = shapeFactory.GetShape("Circle");
            shape.Draw();

            Console.WriteLine("Shape Object Count {0}", shapeFactory.NumOfShapeObjects);
        }

        public interface IShape
        {
            void Draw();
        }

        public class Rectangle : IShape
        {
            public void Draw()
            {
                Console.WriteLine("Draw Rectangle");
            }
        }

        public class Circle : IShape
        {
            public void Draw()
            {
                Console.WriteLine("Draw Circle");
            }
        }

        public class ShapeFactory
        {
            private Dictionary<string, IShape> _shapes;

            public int NumOfShapeObjects
            {
                get { return _shapes.Count(); }
            }

            public ShapeFactory()
            {
                _shapes = new Dictionary<string, IShape>();
            }

            public IShape GetShape(string shapeName)
            {
                IShape shape = null;

                if (_shapes.ContainsKey(shapeName))
                {
                    shape = _shapes[shapeName];
                }
                else
                {
                    switch (shapeName)
                    {
                        case "Rectangle":
                            shape = new Rectangle();
                            _shapes.Add("Rectangle", shape);
                            break;
                        case "Circle":
                            shape = new Circle();
                            _shapes.Add("Circle", shape);
                            break;
                        default:
                            throw new Exception("Factory cannot create the object specified");
                    }
                }

                return shape;
            }
        }
    }
}
