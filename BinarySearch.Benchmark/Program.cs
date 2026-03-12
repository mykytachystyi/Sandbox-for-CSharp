using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Start benchmark for binary searching.");

var summary = BenchmarkRunner.Run<SearchBenchmark>();

Console.WriteLine("End benchmark for binary searching.");


[MemoryDiagnoser]
public class SearchBenchmark
{
    private static readonly int[] Numbers = Enumerable.Range(1, 1000000).ToArray();

    [Params(333333, 777777)]
    public static int SearchValue { get; set; }

    [Benchmark]
    public int LinearSearch()
    {
        var index = Array.FindIndex(Numbers, x => x == SearchValue);

        return index;
    }
    [Benchmark]
    public int BinarySearchFromDotnet()
    {
        var index = Array.BinarySearch(Numbers, SearchValue);

        return index;
    }
    [Benchmark]
    public int BinarySearch()
    {
        var search = new BinarySearch();

        var index = search.Search(Numbers, SearchValue);

        return index;
    }
}