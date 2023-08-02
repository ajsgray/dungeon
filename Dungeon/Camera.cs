using Microsoft.Xna.Framework;

namespace Dungeon;

public class Camera
{
    private readonly int viewportWidth;
    private readonly int viewportHeight;
    public Vector2 Position, PlayerPosition;
    public Matrix Transform;

    // TODO: don't move camera unless player has moved too close to the edge of the screen
    public Rectangle MovementBounds;

    public Camera(int viewportWidth, int viewportHeight)
    {
        this.viewportWidth = viewportWidth;
        this.viewportHeight = viewportHeight;

        MovementBounds = new Rectangle(viewportWidth / 4, viewportHeight / 4, viewportWidth / 2, viewportHeight / 2);
    }

    public void Update(Vector2 playerPosition)
    {
        PlayerPosition = playerPosition;

        Transform = Matrix.Identity *
            Matrix.CreateTranslation(-playerPosition.X, -playerPosition.Y, 0f) *  // following
            Matrix.CreateTranslation(viewportWidth / 2, viewportHeight / 2, 0f); // viewport movement
    }
}