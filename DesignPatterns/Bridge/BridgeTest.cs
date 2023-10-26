using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Bridge
{
    class BridgeTest
    {
        public static void TestBridgeDP()
        {
            IAnimalMoveLogic walk = new Walk();
            IAnimalMoveLogic fly = new Fly();
            IAnimalMoveLogic swim = new Swim();

            Dog dog = new Dog(walk);
            Bird bird = new Bird(fly);
            Fish fish = new Fish(swim);

            dog.Move();
            bird.Move();
            fish.Move();
        }
    }

    public interface IAnimalMoveLogic
    {
        void Move();
    }

    public class Walk : IAnimalMoveLogic
    {
        public void Move()
        {
            Console.WriteLine("Move by legs");
        }
    }

    public class Fly : IAnimalMoveLogic
    {
        public void Move()
        {
            Console.WriteLine("Flap my wings");
        }
    }

    public class Swim : IAnimalMoveLogic
    {
        public void Move()
        {
            Console.WriteLine("Wiggle my tail");
        }
    }

    abstract class Animal
    {
        protected IAnimalMoveLogic animalMoveLogic;

        public virtual void Move() { }
    }

    class Dog : Animal
    {
        public Dog(IAnimalMoveLogic move)
        {
            this.animalMoveLogic = move;
        }

        public override void Move()
        {
            Console.Write("Dog ");
            this.animalMoveLogic.Move();
            base.Move();
        }
    }

    class Bird : Animal
    {
        public Bird(IAnimalMoveLogic move)
        {
            this.animalMoveLogic = move;
        }

        public override void Move()
        {
            Console.Write("Brid ");
            this.animalMoveLogic.Move();
            base.Move();
        }
    }

    class Fish : Animal
    {
        public Fish(IAnimalMoveLogic move)
        {
            this.animalMoveLogic = move;
        }

        public override void Move()
        {
            Console.Write("Fish ");
            this.animalMoveLogic.Move();
            base.Move();
        }
    }
}
