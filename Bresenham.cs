namespace DungeonGenerator;

internal sealed class Bresenham
{
    // Mathematics...
    internal static List<Coord> Algorithm(int x, int y, int x2, int y2)
    {
        List<Coord> coords = [];

        int w = x2 - x;
        int h = y2 - y;
        int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;

        if (w < 0) dx1 = -1; else if (w > 0) dx1 = +1;
        if (h < 0) dy1 = -1; else if (h > 0) dy1 = +1;
        if (w < 0) dx2 = -1; else if (w > 0) dx2 = +1;
        int a = global::System.Math.Abs(w);
        int b = global::System.Math.Abs(h);
        if (a <= b)
        {
            a = Math.Abs(h);
            b = Math.Abs(w);
            if (h < 0) dy2 = -1; else if (h > 0) dy2 = +1;
            dx2 = 0;
        }
        int n = a >> 1;
        for (int i = 0; i <= a; i++)
        {
            coords.Add(new(x, y));

            n += b;
            if (n >= a)
            {
                n -= a;
                x += dx1;
                y += dy1;
            }
            else
            {
                x += dx2;
                y += dy2;
            }
        }

        return coords;
    }
}