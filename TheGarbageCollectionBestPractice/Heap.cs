namespace TheGarbageCollectionBestPractice;

// Dereferences array of the Line to heap
public class Heap
{
    public void DrawPoligon(Line[] lines)
    {

    }
    public void DrawSquare(int x, int y, int w, int h)
    {
        int xw = x + w;
        int yh = y + h;

        Line[] lines =
        [
            new Line(x, y, xw, y),
            new Line(xw, y, xw, yh),
            new Line(xw, yh, x, yh),
            new Line(x, yh, x, y),
        ];
        DrawPoligon(lines);
    }
}
public class Line
{
    public int x1;
    public int x2;
    public int y1;
    public int y2;

    public Line(int x1, int x2, int y1, int y2)
    {
        this.x1 = x1;
        this.x2 = x2;
        this.y1 = y1;
        this.y2 = y2;
    }
}
