namespace DungeonGenerator;

internal sealed class ItemzGenerator
{
    public static List<string> FillMapWithItemz(List<string> mapTemplate)
    {
        for (int i = 0; i < mapTemplate.Count; i++)
        {
            string line = string.Empty;
            for (int j = 0; j < mapTemplate[i].Length; j++)
            {
                if (mapTemplate[i][j] == '.')
                {
                    visible.Add(new(i, j));
                }
            }
        }

        List<string> finalMapTemplate = [];

        for (int i = 0; i < mapTemplate.Count; i++)
        {
            string line = string.Empty;
            for (int j = 0; j < mapTemplate[i].Length; j++)
            {
                Coord point = new(i, j);

                if (mapTemplate[i][j] == '.')
                {
                    if (visible.Any(p => p.X == point.X + 1 && p.Y == point.Y) &&
                        visible.Any(p => p.X == point.X && p.Y == point.Y + 1) &&
                        visible.Any(p => p.X == point.X + 1 && p.Y == point.Y + 1) &&
                        visible.Any(p => p.X == point.X + 1 && p.Y == point.Y - 1) &&
                        visible.Any(p => p.X == point.X - 1 && p.Y == point.Y + 1) &&
                        visible.Any(p => p.X == point.X - 1 && p.Y == point.Y) &&
                        visible.Any(p => p.X == point.X && p.Y == point.Y - 1) &&
                        visible.Any(p => p.X == point.X - 1 && p.Y == point.Y - 1))
                    {
                        List<string> characters = ["c", "!", "%", "/", "]", "$"];

                        visible.RemoveAll(v => v.X == i && v.Y == j);

                        if (Misc.Random.Next(0, 100) < 25)
                        {
                            var c = characters.ElementAt(Misc.Random.Next(0, characters.Count));

                            line += c;
                        }
                        else
                        {
                            line += ".";
                        }
                    }
                    else
                    {
                        line += ".";
                    }
                }
                else
                {
                    line += mapTemplate[i][j];
                }
            }
            finalMapTemplate.Add(line);
        }

        return finalMapTemplate;
    }

    private static readonly List<Coord> visible = [];
}