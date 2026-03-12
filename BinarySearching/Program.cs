// See https://aka.ms/new-console-template for more information
new BinarySearch().Start();

public class BinarySearch
{
    public void Start()
    {
        var searchValue = 3;
        var values = new int[] { 1, 2, 3, 5, 6, 7, 8, 9 };
        for (int i = 0; i < values.Length; i++)
        {
            Console.WriteLine("Index:" + (i + 1) + " Value:" + values[i]);
        }
        Console.WriteLine();
        var result = Search(values, searchValue);
        Console.WriteLine("Index of found number:" + (result + 1));
    }
    public int SearchForUndestand(int[] array, int target)
    {
        int left = 0;
        int right = array.Length - 1;

        Console.WriteLine("Binary Search started.");
        Console.WriteLine();
        Console.Write($"Target:{target}\t");
        Console.Write($"Left index: {left}\t Left value : {array[left]}\t");
        Console.WriteLine($"Right index: {right}\t Right value : {array[right]}");

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            Console.Write($"Mid Index:{mid + 1} \t");
            Console.WriteLine($"Mid Value:{array[mid]} ? Target value: {target}");

            if (array[mid] == target)
            {
                Console.WriteLine("Found the number:" + target);
                return mid; // Element found
            }
            else if (array[mid] < target)
            {
                left = mid + 1;
                Console.WriteLine($"{array[mid]} < {target} move left part close");
                Console.WriteLine($"Left index:{left + 1}");
            }
            else
            {
                Console.WriteLine($"{array[mid]} > {target} move right part close");
                Console.WriteLine(array[mid] + " > " + target);
                right = mid - 1;
                Console.WriteLine($"Right index:{right + 1}");
            }
        }

        Console.WriteLine("Element not found.");
        return -1; // Element not found
    }
    public int Search(int[] array, int target)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (array[mid] == target)
            {
                return mid;
            }
            else if (array[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return -1;
    }
}