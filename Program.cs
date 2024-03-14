using DungeonGenerator;

internal class Program
{
    private static void Main(string[] args)
    {
        bool running = true;

        while(running)
        {
            Console.Clear();

            var map = Dungeons.Create(40, 4, 13, false, 25, 100);

            var mapFilled = ItemzGenerator.FillMapWithItemz(map);

            foreach (var line in mapFilled)
            {
                foreach(var c in line)
                {
                    Console.ForegroundColor = ColorizeConsole(c);
                    Console.Write(c);
                }
                Console.WriteLine();
            }

            if (Console.ReadKey().Key == ConsoleKey.Escape) { running = false; }
        }
    }

    private static ConsoleColor ColorizeConsole(char c) => c switch
    {
        'c' => ConsoleColor.Magenta,
        '!' => ConsoleColor.Red,
        '%' => ConsoleColor.DarkGreen,
        '/' => ConsoleColor.White,
        ']' => ConsoleColor.DarkBlue,
        '$' => ConsoleColor.Green,
        '@' => ConsoleColor.Blue,
        '>' => ConsoleColor.White,
        _ => ConsoleColor.Gray,
    };
}