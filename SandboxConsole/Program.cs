using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            A b = new B();
            A c = new C();
            B a2 = new C();
            a.Show(); 
            b.Show(); 
            c.Show(); 
            a2.Show(); 
            Console.ReadKey();
        }
    }
    public class A
    {
        public virtual void Show()
        {
            Console.WriteLine("A.Show");
        }
    }
    public class B : A
    {
        public override void Show()
        {
            Console.WriteLine("B.Show");
        }
    }
    public class C : B
    {
        public new void Show()
        {
            base.Show();
            Console.WriteLine("C.Show");
        }
    }
}
