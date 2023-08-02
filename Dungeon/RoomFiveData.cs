using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Dungeon;

public static class RoomFiveData
{
    public const int Width = 13;
    public const int Height = 6;
    public const string Id = "Room5";

    public readonly static List<Door> Doors = new()
    {
        new Door(new Point(12, 1), "A", "Room4", "B", "", Direction.West, false, "")
    };

    public readonly static List<Key> Keys = new();

    public static readonly int[,] Data =
{
        {  1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1  },
        {  1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0  },
        {  1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1  },
        {  1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1  },


    };
}