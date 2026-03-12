using System;

namespace Co_Contra_Variance
{
    public delegate void ActionFirst<in T>(T obj);
    public delegate R ActionSecond<out R>();

    class Animal { }
    class Dog : Animal { public void MakeCommands() { } }
    class Pappy : Dog { }

    class Program
    {
        static void Main()
        {
            ActionFirst<Animal> animalAction = AnimalAction;
            ActionFirst<Dog> dogAction = animalAction; // Contravariance
            // ActionFirst<Animal> animalDogAction = DogAction; // This is not working 
            ActionSecond<Dog> actionSecond = ReturnAnimal;

            Dog dog = new Dog();
            dogAction(dog);      // Passing a Dog type to a delegate that accepts Animal type
        }

        static Dog ReturnAnimal()
        {
            return new Dog();
            // return Animal(); // Return Animal woundn't work
        }
        static void AnimalAction(Animal animal)
        {
            Console.WriteLine("This is an animal.");
        }
        static void DogAction(Dog dog)
        {
            dog.MakeCommands();
        }
        static object GetObject() { return null; }
        static void SetObject(object obj) { }

        static string GetString() { return ""; }
        static void SetString(string str) { }

        static void Test()
        {
            // Covariance. A delegate specifies a return type as object,  
            // but you can assign a method that returns a string.  
            Func<object> del = GetString;

            // Contravariance. A delegate specifies a parameter type as string,  
            // but you can assign a method that takes an object.  
            Action<string> del2 = SetObject;
        }
    }

}
