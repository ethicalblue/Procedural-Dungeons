namespace DungeonGenerator;

internal sealed class Room
{
    public int X1 { get; private set; }
    public int X2 { get; private set; }
    public int Y1 { get; private set; }
    public int Y2 { get; private set; }
    public int W { get; private set; }
    public int H { get; private set; }
    public Coord Center { get; set; } = new(0, 0);
    public Room(int x, int y, int w, int h)
    {
        X1 = x;
        X2 = x + w;
        Y1 = y;
        Y2 = y + h;

        Center = new((int)Math.Floor((X1 + X2) / 2.0), (int)Math.Floor((Y1 + Y2) / 2.0));
    }
    public bool Intersects(Room room) => (X1 <= room.X2 && X2 >= room.X1 && Y1 <= room.Y2 && room.Y2 >= room.Y1);
}