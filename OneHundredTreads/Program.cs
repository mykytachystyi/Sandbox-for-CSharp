using System;
using System.Threading;

namespace OneHundredTreads
{
    public class Program
    {
        static int factory = 0; // Суматор
        static object locker = new object(); // Об'єкт для синхронізації

        static void Main()
        {
            Thread[] threads = new Thread[200];

            for (int i = 0; i < 100; i++)
            {
                threads[i] = new Thread(() => Deliver(i + 1));
                threads[i + 100] = new Thread(() => Pickup(i + 1));
            }

            foreach (Thread thread in threads) thread.Start();
            foreach (Thread thread in threads) thread.Join();

            Console.WriteLine($"На фабриці залишилося: {factory}");
        }

        static void Deliver(int id)
        {
            lock (locker)
            {
                factory++;
                Console.WriteLine($"[Доставка] Потік #{id} привіз щось. Стан фабрики: {factory}");
            }
        }

        static void Pickup(int id)
        {
            lock (locker)
            {
                factory--;
                Console.WriteLine($"[Вивіз] Потік #{id} вивіз щось. Стан фабрики: {factory}");
            }
        }
    }

}
