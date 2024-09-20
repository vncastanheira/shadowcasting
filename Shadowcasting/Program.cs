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

using map;

string[,] map = new[,] {
    { "#", "#", "#", "#", "#", "#" },
    { "#", ".", ".", ".", ".", "#" },
    { "#", ".", "#", ".", ".", "#" },
    { "#", "#", "#", ".", ".", "#" },
    { "#", ".", ".", ".", ".", "#" },
    { "#", ".", "#", "#", ".", "#" },
    { "#", ".", ".", ".", ".", "#" },
    { "#", ".", ".", "#", ".", "#" },
    { "#", ".", ".", ".", ".", "#" },
    { "#", "#", "#", "#", "#", "#" },
};

var fovRecurse = new FOVRecurse(map);
fovRecurse.Player = new System.Drawing.Point(2, 4);
fovRecurse.VisualRange = 10;

void Update()
{
    Console.Clear();
    fovRecurse.GetVisibleCells();
    for (int y = 0; y < map.GetLength(1); y++)
    {
        for (int x = 0; x < map.GetLength(0); x++)
        {
            if (fovRecurse.Player.X == x && fovRecurse.Player.Y == y)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"@ ");
            }
            else if (fovRecurse.VisiblePoints.Exists(p => p.X == x && p.Y == y))
            {
                var tile = fovRecurse.map[x, y];
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{tile} ");
            }
            else
            {
                var tile = fovRecurse.map[x, y];
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"{tile} ");
            }
        }
        Console.Write("\n");
    }
    Console.ResetColor();
}


// const
const string WALL = "#";
const string FREE = ".";
const string PLAYER = "@";


List<Tile> visitedTiles = new();


while (true)
{
    Update();
    if (GetInput() == ConsoleKey.Escape)
        break;
}

ConsoleKey GetInput()
{
    var info = Console.ReadKey();
    switch (info.Key)
    {
        case ConsoleKey.RightArrow:
            {
                fovRecurse.movePlayer(1, 0);
            }
            break;
        case ConsoleKey.LeftArrow:
            {
                fovRecurse.movePlayer(-1, 0);
            }
            break;
        case ConsoleKey.DownArrow:
            {
                fovRecurse.movePlayer(0, 1);
            }
            break;
        case ConsoleKey.UpArrow:
            {
                fovRecurse.movePlayer(0, -1);
            }
            break;
        default:
            break;
    }
    return info.Key;
}


//bool IsValid(int pY, int pX)
//{
//    return InBounds(pY, pX) && IsFreeTile(pY, pX);
//}

//// functions
//bool InBounds(int pY, int pX)
//{
//    return pX >= 0 & pX < map.GetLength(1) & pY >= 0 & pY < map.GetLength(0);
//}

//bool IsFreeTile(int pY, int pX)
//{
//    return map[pY, pX] == FREE;
//}

//double GetSlope(double pX1, double pY1, double pX2, double pY2, bool pInvert)
//{
//    return pInvert ? (pY1 - pY2) / (pX1 - pX2) : (pX1 - pX2) / (pY1 - pY2);
//}

//void CalculateFOV()
//{
//    var scanY = playerY - 1;
//    var scanX = playerX;


//    while (GetSlope(scanX, scanY, playerX, playerY, false) >= 0)
//    {
//        visitedTiles.Add(new Tile { x = scanX, y = scanY });

//        if (map[scanY, scanX] == WALL)
//            break;

//        scanY -= 1;
//    }
//}