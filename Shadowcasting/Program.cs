//  Octant data
//
//    \ 1 | 2 /
//   8 \  |  / 3
//   -----+-----
//   7 /  |  \ 4
//    / 6 | 5 \
//
//  1 = NNW, 2 =NNE, 3=ENE, 4=ESE, 5=SSE, 6=SSW, 7=WSW, 8 = WNW

//  Sources:
// https://web.archive.org/web/20200224054815/http://www.evilscience.co.uk/field-of-vision-using-recursive-shadow-casting-c-3-5-implementation/
// https://github.com/AndyStobirski/RogueLike/blob/master/FOVRecurse.cs

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

const string WALL = "#";
const string FREE = ".";
const string PLAYER = "@";

List<Tile> visitedTiles = new();



void SetColor(string tile)
{
    if (tile == PLAYER)
        Console.ForegroundColor = ConsoleColor.Red;
    else
        Console.ForegroundColor = ConsoleColor.DarkGray;
}

while (true)
{
    Update();
    
    var info = Console.ReadKey();
    if (info.Key == ConsoleKey.Escape)
        break;
}

void Update(){
    Console.Clear();
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
}

// functions
bool IsPointValid(int pX, int pY)
{
    return pX >= 0 & pX < map.GetLength(0) & pY >= 0 & pY < map.GetLength(1);
}