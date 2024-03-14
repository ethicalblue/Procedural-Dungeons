using System.Collections.Generic;

namespace DungeonGenerator
{
    internal sealed class Coord
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Coord() { }
        public Coord(int x, int y) { X = x; Y = y; }
        public static List<Coord> GetPointzAround(int x, int y)
        {
            return new()
            {
                new(x + 1, y),
                new(x, y + 1),
                new(x + 1, y + 1),
                new(x + 1, y - 1),
                new(x - 1, y + 1),
                new(x - 1, y),
                new(x, y - 1),
                new(x - 1, y - 1)
            };
        }
    }
}
