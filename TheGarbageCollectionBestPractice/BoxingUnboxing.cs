namespace TheGarbageCollectionBestPractice;

public class BoxingUnboxing
{
    public void Test()
    {
        int a = 1234;
        object b = a;
        int c = (int)b;

        Console.WriteLine(c);
    }
}
