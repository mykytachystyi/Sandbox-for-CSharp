using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace APM
{
    public class Calculator
    {
        public delegate int AddDelegate(int x, int y);

        public int Add(int x, int y)
        {
            return x + y;
        }

        // Метод для початку асинхронного виклику
        public IAsyncResult BeginAdd(int x, int y, AsyncCallback callback, object state)
        {
            AddDelegate addDelegate = new AddDelegate(Add);
            return addDelegate.BeginInvoke(x, y, callback, state);
        }

        // Метод для завершення асинхронного виклику
        public int EndAdd(IAsyncResult asyncResult)
        {
            AddDelegate addDelegate = (AddDelegate)((AsyncResult)asyncResult).AsyncDelegate;
            return addDelegate.EndInvoke(asyncResult);
        }
    }
}