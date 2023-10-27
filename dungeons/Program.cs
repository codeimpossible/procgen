
using Dungeons;

int seed = 1024;
int maxRoomCount = 32;
int maxRoomSize = 16;
string[] arguments = Environment.GetCommandLineArgs();
Console.WriteLine("GetCommandLineArgs: {0}", string.Join(", ", arguments));
if (arguments.Length > 1) {
    seed = int.Parse(arguments[1]);
    if (arguments.Length > 2)
        maxRoomCount = int.Parse(arguments[2]);
    if (arguments.Length > 3)
        maxRoomSize = int.Parse(arguments[3]);
}

var dungeon = new Dungeon(seed, 120, 60, maxRoomCount: maxRoomCount, maxRoomSize: maxRoomSize);
for(var y = 0; y < dungeon.Height; y++) {
    for(var x = 0; x < dungeon.Width; x++) {
        var tile = dungeon.GetTileAt(x, y);
        switch(tile) {
            case Tile.FLOOR: Console.Write(" "); break;
            case Tile.INTERIOR_WALL: Console.Write("#"); break;
            case Tile.EXTERIOR_WALL: Console.Write(" "); break;
            case Tile.ENTRY: Console.Write("@"); break;
            case Tile.EXIT: Console.Write("X"); break;
        }
    }
    Console.Write("\n");
}
Console.Write("\n");
