using Microsoft.Xna.Framework;

namespace Dungeon;

public struct Circle
{
    public Vector2 Centre;
    public float Radius;

    public Circle(Vector2 centre, float radius)
    {
        Centre = centre;
        Radius = radius;
    }

    public readonly bool Intersects(Circle other)
    {
        var dir = other.Centre - Centre;
        return dir.LengthSquared() < (Radius * Radius) + (other.Radius * other.Radius);
    }
}