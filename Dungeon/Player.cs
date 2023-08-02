using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Dungeon;

public class Player
{
    public Vector2 Position;
    public Vector2 Velocity;
    public int Width, Height;

    const float Acceleration = 1f;
    const float MaxVelocity = 5f;

    public HashSet<string> Items = new();

    public Player(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public Rectangle GetBounds()
        => new((int)Position.X, (int)Position.Y, Width, Height);

    public Circle GetCircleBounds()
        => new (Position + new Vector2(Width/2, Height/2), Width / 2); // not ideal just using the width but player will probably be square for a long time

    public void Update(KeyboardState kb)
    {
        if (kb.IsKeyDown(Keys.A))
        {
            Velocity.X -= Acceleration;
            Velocity.X = MathHelper.Clamp(Velocity.X, -MaxVelocity, MaxVelocity);
        }
        if (kb.IsKeyDown(Keys.D))
        {
            Velocity.X += Acceleration;
            Velocity.X = MathHelper.Clamp(Velocity.X, -MaxVelocity, MaxVelocity);
        }
        if (kb.IsKeyDown(Keys.W))
        {
            Velocity.Y -= Acceleration;
            Velocity.Y = MathHelper.Clamp(Velocity.Y, -MaxVelocity, MaxVelocity);
        }
        if (kb.IsKeyDown(Keys.S))
        {
            Velocity.Y += Acceleration;
            Velocity.Y = MathHelper.Clamp(Velocity.Y, -MaxVelocity, MaxVelocity);
        }
    }

    public void AddItem(string itemName)
    {
        Items.Add(itemName);
    }
}
