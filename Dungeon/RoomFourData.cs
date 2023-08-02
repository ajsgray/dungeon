using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Dungeon;

public static class RoomFourData
{
    public const int Width = 13;
    public const int Height = 14;
    public const string Id = "Room4";

    public readonly static List<Door> Doors = new()
    {
        new Door(new Point(1, 13), "A", "Room3", "B","", Direction.North, false, ""),
        new Door(new Point(0, 1), "B", "Room5", "A","", Direction.East, false, "")
    };

    public readonly static List<Key> Keys = new();

    public static readonly int[,] Data =
{
        {  1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1  },
        {  0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1  },
        {  1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1  },

    };
}