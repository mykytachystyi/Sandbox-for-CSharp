namespace TheGarbageCollectionBestPractice;

// The problem: this time of create, use and free up resources can be huge!
// The resource is kept allocated for a very long time.
// The dispose pattern provides a method for explicitly releasing scarce resources.
// The using statement will automatically call the dispose method at the end of the using block
// - The dispose pattern dramatically reduces the length of time that resources are held by objects
// - Calling the dispose method supppresses the finaliser, which prevents the object's lifetime extending into gen:1
public class TheDisposePattern
{
    public static long FinalisedObjects = 0;
    public static long TotalTime = 0;

    public void Test()
    {
        for (int i = 0; i < 500000; i++)
        {
            var obj = new WithoutDispose();
            obj.DoWork();

            /*
             * using (var obj = new WithDispose())
             * {
             *      obj.DoWork();
             * }
             */
        }
        double avgLifetime = 1.0 * TotalTime / FinalisedObjects;
        Console.WriteLine("Number of disposed/finalised objects: {0}K", FinalisedObjects);
        Console.WriteLine("Average resource lifetime: {0}ms", avgLifetime);
    }
}
public class WithoutDispose
{
    private Stopwatch stopwatch = null;

    public WithoutDispose()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
    }
    public void DoWork()
    {
        double j = 0;
        for (int i = 0; i < 1000; i++)
        {
            j += i * i;
        }
    }
    ~WithoutDispose()
    {
        stopwatch.Stop();
        Interlocked.Increment(ref TheDisposePattern.FinalisedObjects);
        Interlocked.Add(ref TheDisposePattern.TotalTime, stopwatch.ElapsedMilliseconds);
    }
}
public class WithDispose : IDisposable
{
    private Stopwatch stopwatch = null;
    private bool disposed = false;

    public WithDispose()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
    }
    public void DoWork()
    {
        double j = 0;
        for (int i = 0; i < 1000; i++)
        {
            j += i * i;
        }
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            stopwatch.Stop();
            Interlocked.Increment(ref TheDisposePattern.FinalisedObjects);
            Interlocked.Add(ref TheDisposePattern.TotalTime, stopwatch.ElapsedMilliseconds);

            if (disposing)
            {

            }
            else
            {
                // free unmanaged resources onse
            }
            disposed = true;
        }
    }
    ~WithDispose()
    {
        Dispose(false);
    }
}
public class Stopwatch
{
    public int ElapsedMilliseconds = 0;
    public void Start()
    {

    }
    public void Stop()
    {

    }
}
