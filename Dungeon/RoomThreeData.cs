using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Dungeon;

public static class RoomThreeData
{
    public const int Width = 5;
    public const int Height = 30;
    public const string Id = "Room3";

    public readonly static List<Door> Doors = new()
    {
        new Door(new Point(2, 29), "A", "Room1", "C","", Direction.North, false, ""),
        new Door(new Point(2, 0), "B", "Room4", "A","", Direction.South, false, "")
    };

    public readonly static List<Key> Keys = new();

    public static readonly int[,] Data =
{
        {  1, 1, 0, 1, 1  },
        {  1, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 1  },
        {  1, 0, 0, 1, 1  },
        {  1, 0, 0, 1, 1  },
        {  1, 0, 0, 1, 1  },
        {  1, 0, 0, 1, 1  },
        {  1, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 1  },
        {  1, 1, 0, 0, 1  },
        {  1, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 1  },
        {  1, 1, 0, 0, 1  },
        {  1, 1, 0, 0, 1  },
        {  1, 1, 0, 0, 1  },
        {  1, 1, 0, 0, 1  },
        {  1, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 1  },
        {  1, 0, 0, 0, 1  },
        {  1, 1, 0, 1, 1  },
    };
}