using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Observer
{
    class Observer
    {
        public static void TestObserverDP()
        {
            Light light = new Light();
            Display display1 = new Display(light);
            Display display2 = new Display(light);

            light.Attach(display1);
            light.Attach(display2);

            light.ToggleLightSwitch();

            light.ToggleLightSwitch();
        }
    }

    public abstract class ObserverDP
    {
        public abstract void Update();
    }

    public class Display : ObserverDP
    {
        private Light _Light;

        public Display(Light light)
        {
            _Light = light;
        }
        public override void Update()
        {
            if (_Light.IsIluminated)
            {
                Console.WriteLine("Light is on");
            }
            else
            {
                Console.WriteLine("Light is off");
            }
        }
    }
    public abstract class Observers
    {
        private List<ObserverDP> observers = new List<ObserverDP>();

        public void Attach(ObserverDP observer)
        {
            observers.Add(observer);
        }
        public void Detach(ObserverDP observer)
        {
            observers.Remove(observer);
        }
        public void Notify()
        {
            foreach (ObserverDP o in observers)
            {
                o.Update();
            }
        }
    }

    public class Light : Observers
    {
        private bool _isIluminated;
        public bool IsIluminated { get { return _isIluminated; } }

        public Light()
        {
            _isIluminated = false;
        }

        public void ToggleLightSwitch()
        {
            if (_isIluminated == false)
            {
                _isIluminated = true;
            }
            else
            {
                _isIluminated = false;
            }
            Notify();
        }
    }
}
