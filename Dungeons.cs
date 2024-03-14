namespace DungeonGenerator;

internal sealed class Dungeons
{
    public static Coord StartPosition { get; private set; } = new(0, 0);
    public static Coord NextLevelPosition { get;private set; } = new(0, 0);
    public static List<string> Create(int maxRooms, int minRoomSize, 
        int maxRoomSize, bool squareRooms, int mapWidth, int mapHeight)
    {
        List<string> map = [];

        PlaceRooms(maxRooms, minRoomSize, maxRoomSize, mapWidth, mapHeight, squareRooms);

        var startRoom = Rooms.FirstOrDefault();
        var lastRoom = Rooms.LastOrDefault();

        if(startRoom is not null && lastRoom is not null)
        {
            StartPosition = startRoom.Center;
            NextLevelPosition = lastRoom.Center;
        }

        for (int x = 0; x < mapWidth; x++)
        {
            var line = string.Empty;
            for (int y = 0; y < mapHeight; y++)
            {
                if (StartPosition.X == x && StartPosition.Y == y)
                {
                    line += "@";
                }
                else if (NextLevelPosition.X == x && NextLevelPosition.Y == y)
                {
                    line += ">";
                }
                else
                {
                    if (RoomsPoints.Exists(p => p.X == x && p.Y == y) || Corridors.Exists(p => p.X == x && p.Y == y))
                    {
                        line += ".";
                    }
                    else if(StoneWallPoints.Exists(p => p.X == x && p.Y == y))
                    {
                        line += "#";
                    }
                    else
                    {
                        line += " ";
                    }
                }
            }
            map.Add(line);
        }

        return map;
    }

    private static void CreateRoom(Room room)
    {
        for (int x = room.X1; x < room.X2; x++)
        {
            for (int y = room.Y1; y < room.Y2; y++)
            {
                RoomsPoints.Add(new(x, y));
                StoneWallPoints.AddRange(Coord.GetPointzAround(x, y));
            }
        }
    }

    private static void HorizontalCorridor(int x1, int x2, int y)
    {
        for (int x = Math.Min(x1, x2); x < Math.Max(x1, x2) + 1; x++)
        {
            Corridors.Add(new(x, y));
            StoneWallPoints.AddRange(Coord.GetPointzAround(x, y));
        }
    }

    private static void VerticalCorridor(int y1, int y2, int x)
    {
        for (int y = Math.Min(y1, y2); y < Math.Max(y1, y2) + 1; y++)
        {
            Corridors.Add(new(x, y));
            StoneWallPoints.AddRange(Coord.GetPointzAround(x, y));
        }
    }

    private static void PlaceRooms(int maxRooms, int minRoomSize, int maxRoomSize, int mapWidth, int mapHeight, bool squareRooms)
    {
        Rooms = [];
        RoomsPoints = [];
        StoneWallPoints = [];
        Corridors = [];
        Coord centerNew;

        for (int i = 0; i < maxRooms; i++)
        {
            var w = Misc.Random.Next(minRoomSize, maxRoomSize);
            var h = Misc.Random.Next(minRoomSize, maxRoomSize);

            if (squareRooms == true)
            {
                h = w;
            }

            var x = Misc.Random.Next(0, (mapWidth - w - 1)) + 1;
            var y = Misc.Random.Next(0, (mapHeight - h - 1)) + 1;

            Room roomNew = new(x, y, w, h);

            bool failed = false;

            if(Rooms is not null)
            {
                foreach (var room in Rooms)
                {
                    if (roomNew.Intersects(room))
                    {
                        failed = true;
                        break;
                    }
                }
            }

            if (failed == false)
            {
                CreateRoom(roomNew);
                centerNew = roomNew.Center;
                if (Rooms is not null && Rooms.Count != 0)
                {
                    var prevCenter = Rooms.LastOrDefault()?.Center;

                    if (prevCenter is not null)
                    {
                        if (Misc.Random.Next(0, 1 + 1) == 0)
                        {
                            HorizontalCorridor(prevCenter.X, centerNew.X, prevCenter.Y);
                            VerticalCorridor(prevCenter.Y, centerNew.Y, centerNew.X);
                        }
                        else
                        {
                            VerticalCorridor(prevCenter.Y, centerNew.Y, centerNew.X);
                            HorizontalCorridor(prevCenter.X, centerNew.X, prevCenter.Y);
                        }
                    }
                }

                Rooms?.Add(roomNew);
            }
        }
    }
    private static List<Room> Rooms = [];
    private static List<Coord> RoomsPoints = [];
    private static List<Coord> StoneWallPoints = [];
    private static List<Coord> Corridors = [];
}