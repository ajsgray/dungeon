using Microsoft.Xna.Framework;
using SharpDX.Win32;

namespace Dungeon;

public class Door
{
    public Point Position;
    public string Id;
    public string DestinationRoomId;
    public string DestinationDoorId;
    public string KeyId;
    public string Colour;
    public Direction Facing;
    public bool IsLocked;

    public Door(Point position, string id, string destinationRoomId, string destinationDoorId, string keyId, Direction facing, bool isLocked, string colour)
    {
        Position = position;
        Id = id;
        DestinationRoomId = destinationRoomId;
        DestinationDoorId = destinationDoorId;
        KeyId = keyId;  
        Facing = facing;
        IsLocked = isLocked;
        Colour = colour;
    }
}
