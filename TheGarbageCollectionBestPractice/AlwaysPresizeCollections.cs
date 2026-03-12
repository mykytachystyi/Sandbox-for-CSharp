using System.Collections;

namespace TheGarbageCollectionBestPractice;

internal class AlwaysPresizeCollections
{
    // Every collection and list in .NET starts out with a certain default capacity, and when it runs out of space it will create a new list
    // and copy all values there

    private const int MAXITEMS = 262145;
    private static ArrayList arrayList = new ArrayList();
    private static Queue<int> queue = new Queue<int>();
    private static Stack<int> stack = new Stack<int>();
    private static List<int> list = new List<int>(MAXITEMS); // To presize lists
    private static Dictionary<int, int> dictionary = new Dictionary<int, int>();

    public void Init()
    {
        arrayList.Add(1);
        queue.Enqueue(1);
        stack.Push(1);
        list.Add(1);
        dictionary.Add(1, 1);
    }
    public static void FillList()
    {
        for (int i =0; i < MAXITEMS; i++)
        {
            list.Add(i);
        }
    }
    // Default collection capacity:
    // ArrayList = 4, Queue = 4, Stack = 16, List = 4, Dictionary = 12


    // Actual memory footprint 
    // 4,195,168 bytes
    // The list need to grow to 2 MB to fit all items!
    // Consecutive doubling adds up to 4 MB

    // Worst case scenario: 4x large that needs to be allocated
}
