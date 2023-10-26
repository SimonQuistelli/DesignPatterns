using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator
{
    class DecoratorTest
    {
        public static void TestDecoratorDP()
        {
            Circle circle = new Circle();
            Rectangle rectangle = new Rectangle();

            RedShape redCircle = new RedShape(circle);
            RedShape redRectangle = new RedShape(rectangle);

            Console.WriteLine("Circle with normal border");
            circle.Draw();
            Console.WriteLine();

            Console.WriteLine("Rectangle with normal border");
            rectangle.Draw();
            Console.WriteLine();

            Console.WriteLine("Circle with red border");
            redCircle.Draw();
            Console.WriteLine();

            Console.WriteLine("Rectangle with red border");
            redRectangle.Draw();
        }
    }

    public interface IShape
    {
        void Draw();
    }

    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Draw Circle");
        }
    }

    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Draw Rectangle");
        }
    }

    public abstract class ShapeDecorator : IShape
    {
        protected IShape _shape;
        public ShapeDecorator(IShape shape)
        {
            _shape = shape;
        }
        public virtual void Draw()
        {
            _shape.Draw();
        }
    }

    public class RedShape : ShapeDecorator
    {
        public RedShape(IShape shape) : base(shape)
        {
        }

        public override void Draw()
        {
            base.Draw();
            Console.WriteLine("Draw Red Border");
        }
    }
}
