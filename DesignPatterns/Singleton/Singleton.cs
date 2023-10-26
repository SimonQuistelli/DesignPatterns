using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Singleton
{
    class Singleton
    {
        public static void TestSingletonDP()
        {
            OnlyOneCat myCat1 = OnlyOneCat.Cat;
            OnlyOneCat myCat2 = OnlyOneCat.Cat;

            myCat1.Meow();

            if (myCat1 == myCat2)
            {
                Console.WriteLine("Same");
            }
        }
    }
    public sealed class OnlyOneCat
    {
        private static OnlyOneCat _instance;

        private static readonly object threadLock = new object();

        OnlyOneCat() { }

        public static OnlyOneCat Cat
        {
            get
            {
                lock (threadLock)
                {
                    if (_instance == null)
                    {
                        _instance = new OnlyOneCat();
                    }
                }
                return _instance;
            }
        }

        public void Meow()
        {
            Console.WriteLine("Meow");
        }
    }
}
