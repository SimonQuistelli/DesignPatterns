using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Proxy
{
    class ProxyTest
    {
        public static void TestProxyDP()
        {
            Proxy proxy = new Proxy();
            proxy.PerformOperation();
        }
    }

    public interface ISubject
    {
        void PerformOperation();
    }

    public class RealSubject : ISubject
    {
        public void PerformOperation()
        {
            Console.WriteLine("Real subject perform operation");
        }
    }

    public class Proxy : ISubject
    {
        private ISubject _subject = null;

        public void PerformOperation()
        {
            if(_subject == null)
                _subject = new RealSubject();

            _subject.PerformOperation();
        }
    }
}
