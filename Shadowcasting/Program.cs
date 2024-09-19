string[,] map = new[,] {
    { "#", "#", "#", "#", "#", "#" },
    { "#", ".", ".", ".", ".", "#" },
    { "#", ".", "#", ".", ".", "#" },
    { "#", "#", "#", ".", ".", "#" },
    { "#", ".", ".", ".", ".", "#" },
    { "#", ".", "#", "#", ".", "#" },
    { "#", "@", ".", ".", ".", "#" },
    { "#", ".", ".", "#", ".", "#" },
    { "#", ".", ".", ".", ".", "#" },
    { "#", "#", "#", "#", "#", "#" },
};

List<Tile> visitedTiles = new();

Console.ForegroundColor = ConsoleColor.DarkGray;
for (int i = 0; i < map.GetLength(0); i++)
{
    for (int j = 0; j < map.GetLength(1); j++)
    {
        var tile = map[i, j];
        SetColor(tile);
        Console.Write($"{tile} ");
    }
    Console.Write("\n");
}

void SetColor(string tile)
{
    if (tile == "@")
        Console.ForegroundColor = ConsoleColor.Red;
    else
        Console.ForegroundColor = ConsoleColor.DarkGray;
}

Console.ReadKey();