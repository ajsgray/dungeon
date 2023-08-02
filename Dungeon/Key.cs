using Microsoft.Xna.Framework;

namespace Dungeon;

public class Key
{
    public Point Position;
    public string Id, DestinationDoorId, DestinationRoomId, ItemName;
    public float Radius = 10f;
    public bool IsActive;

    public Key(Point position, string id, string destinationRoomId, string destinationDoorId, string itemName, bool isActive)
    {
        Position = position;
        Id = id;
        DestinationRoomId = destinationRoomId;
        DestinationDoorId = destinationDoorId;
        ItemName = itemName;
        IsActive = isActive;
    }

    public Circle GetCircleBounds()
        => new (Position.ToVector2() * 32 + new Vector2(16,16), Radius);
}