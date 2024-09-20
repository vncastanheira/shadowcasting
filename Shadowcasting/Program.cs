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
    { "#", ".", ".", ".", ".", "#" },
    { "#", ".", ".", "#", ".", "#" },
    { "#", ".", ".", ".", ".", "#" },
    { "#", "#", "#", "#", "#", "#" },
};

// const
const string WALL = "#";
const string FREE = ".";
const string PLAYER = "@";

// Player
int playerY = 4;
int playerX = 2;


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
                var nextX = playerX + 1;
                if (InBounds(playerY, nextX) && IsFreeTile(playerY, nextX))
                    playerX = nextX;
            }
            break;
        case ConsoleKey.LeftArrow:
            {
                var nextX = playerX - 1;
                if (InBounds(playerY, nextX) && IsFreeTile(playerY, nextX))
                    playerX = nextX;
            }
            break;
        case ConsoleKey.DownArrow:
            {
                var nextY = playerY + 1;
                if (InBounds(nextY, playerX) && IsFreeTile(nextY, playerX))
                    playerY = nextY;
            }
            break;
        case ConsoleKey.UpArrow:
            {
                var nextY = playerY - 1;
                if (InBounds(nextY, playerX) && IsFreeTile(nextY, playerX))
                    playerY = nextY;
            }
            break;    
        default:
            break;
    }
    return info.Key;
}

void Update()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.DarkGray;
    for (int y = 0; y < map.GetLength(0); y++)
    {
        for (int x = 0; x < map.GetLength(1); x++)
        {
            if (playerX == x && playerY == y)
            {
                SetColor(PLAYER);
                Console.Write($"@ ");
            }
            else
            {
                var tile = map[y, x];
                SetColor(tile);
                Console.Write($"{tile} ");
            }
        }
        Console.Write("\n");
    }
}

// functions
bool InBounds(int pY, int pX)
{
    return pX >= 0 & pX < map.GetLength(1) & pY >= 0 & pY < map.GetLength(0);
}

bool IsFreeTile(int pY, int pX)
{
    return map[pY, pX] == FREE;
}