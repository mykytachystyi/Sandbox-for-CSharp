namespace TheGarbageCollectionBestPractice;

public class AvoidUsingToListInLinq
{
    // var numbers = Enumerable.Range(1, 1000).Where(n => n% 2 != 0);
    // This expression creates a filtered enumerator for a range of 500 odd numbers, but it doesn't actually generate the numbers yet.
    // The range does not occupy any memory. The enumerator only tracks the current number


    // Calling the ToLIst method in a LINQ expressions can unexpectedly inflate the memory footprint of your code
    // To fix this problem, call ToList before running the LINQ query
    private static List<string> Dictionary = new List<string>(150000);
    private static IEnumerable<string> dictionary = null;
    private static IEnumerable<string> story = null;
    private static IEnumerable<string> ReadFile(string file)
    {
        using (var reader = File.OpenText(file))
        {
            while(!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                yield return line;
            }
        }
    }
    private static void BadSpellCheck()
    {
        var result = from word in story 
                     let lowerCase = word.ToLower()
                    select new { Word =word, Ok = dictionary.ToList().Contains(lowerCase) };
        foreach (var r in result)
        {
            Console.ForegroundColor = r.Ok ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(r.Word);
            Console.Write("   ");
        }
        Console.ResetColor();
    }
    private static void GoodSpellCheck()
    {
        var result = from word in story
                     let lowerCase = word.ToLower()
                     select new { Word = word, Ok = Dictionary.Contains(lowerCase) };
        foreach (var r in result)
        {
            Console.ForegroundColor = r.Ok ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(r.Word);
            Console.Write("   ");
        }
        Console.ResetColor();
    }
    public static void TestMain()
    {
        dictionary = ReadFile("./allwords.txt");
        story = ReadFile("./story.txt");
        SpellCheck();
    }
}
