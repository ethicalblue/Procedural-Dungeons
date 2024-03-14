namespace DungeonGenerator
{
    internal sealed class Misc
    {
        public static global::System.Random Random = new();
        public static bool LineContainsPoint(Coord coord1, Coord coord2, Coord coordToCheck) => 
            (coordToCheck.Y - coord1.Y) / (coord2.Y - coord1.Y) == 
            (coordToCheck.X - coord1.X) / (coord2.X - coord1.X);
    }
}