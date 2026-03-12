namespace TheGarbageCollectionBestPractice;

public class UseStructsInsteadOfClasses
{
    // Assigning structs copies the value of all internal fields
    // Struct can implement interfaces but cannot inherit
    // Structs cannot have instance field initialisers
    // Structs cannot have a parameterless constructor
    // Structs cannot have finalisers

    /*
     * use struct when the data you're storing represents a signle value
     * your data size is very small (24 byte or less) and you are goint to create thousands or millions of instances
     * if your data is immutable
     * if your data will not have to be boxed frequently
     * 
     * In all other scenario's classes are a better alternative
     */
    private const int LISTSIZE = 1000000;
    public void TestClass()
    {
        List<PointClass> list= new List<PointClass>(LISTSIZE);
        for (int i = 0; i < LISTSIZE; i++)
        {
            list.Add(new PointClass(i, i));
        }
    }
    public void TestStruct()
    {
        List<PointStruct> list = new List<PointStruct>(LISTSIZE);
        for (int i = 0; i < LISTSIZE; i++)
        {
            list.Add(new PointStruct(i, i));
        }
    }
}
public class PointClass
{
    public int X;
    public int Y;

    public PointClass(int x, int y)
    {
        X = x;
        Y = y;
    }
}
public struct PointStruct
{
    public int X;
    public int Y;

    public PointStruct(int x, int y)
    {
        X = x;
        Y = y;
    }
}
