using System.Collections.Generic;

namespace Dungeon;

public class Room
{
    public int Width, Height;
    public int[,] Data;
    public List<Door> Doors;
    public List<Key> Keys;

    public static Room Load(int width, int height, int[,] data, List<Door> doors, List<Key> keys)
    {
        var room = new Room
        {
            Width = width,
            Height = height,
            Data = data,
            Doors = doors,
            Keys = keys
        };

        foreach (var door in doors)
        {
            // set up locked doors
            if (!door.IsLocked) continue;
            data[door.Position.Y, door.Position.X] = 1;
        }

        return room;
    }
}
