using System;

namespace APM
{
    public class Playground
    {
        static Calculator calculator = new Calculator();

        public void Test()
        {
            // Використовуємо AsyncCallback для отримання результату
            AsyncCallback callback = new AsyncCallback(OnAddComplete);
            IAsyncResult asyncResult = calculator.BeginAdd(5, 3, callback, "Add operation");

            // Виконуємо іншу роботу, поки асинхронний виклик виконується
            Console.WriteLine("Doing other work...");

            // Опціонально чекаємо завершення асинхронного виклику
            int result = calculator.EndAdd(asyncResult);
            Console.WriteLine("Result: " + result);
        }

        // Метод зворотного виклику для обробки завершення асинхронного виклику
        static void OnAddComplete(IAsyncResult asyncResult)
        {
            string state = (string)asyncResult.AsyncState;
            int result = calculator.EndAdd(asyncResult); // Використовуємо існуючий екземпляр
            Console.WriteLine($"{state} completed. Result: {result}");
        }
    }
}