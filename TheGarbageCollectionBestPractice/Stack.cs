namespace TheGarbageCollectionBestPractice;

/*
    The memory size of the stack in .NET largely depends on the runtime and the platform. Typically:
    - For 32-bit systems, the stack size is around 1 MB by default.
    - For 64-bit systems, the stack size is also usually 1 MB by default.

    However, you can modify the stack size for a thread when creating it using the Thread class, or by setting it through compiler options if you're working with native code.
*/
public class Stack
{
    public void DrawLine(int x1, int y1, int x2, int y2)
    {
        DrawLine(x1, y1, x2, y2);
    }
    public void DrawSquare(int x, int y, int w, int h)
    {
        int xw = x + w;
        int yh = y + h;

        DrawLine(x, y, xw, y);
        DrawLine(xw, y, xw, yh);
        DrawLine(xw, yh, x, yh);
        DrawLine(x, yh, x, y);
    }
    public void Test()
    {
        Console.WriteLine("Going to draw a square...");
        DrawSquare(100, 100, 50, 50);
        Console.WriteLine("Square drawn.");
    }
}