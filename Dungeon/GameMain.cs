using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Accessibility;
using LilyPath;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dungeon;

public class TileMap
{
    private TileMap() { }

    public static TileMap CreateNew()
    {
        return new TileMap()
        {

        };
    }
}

public class GameMain : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _tile, _circle, _key;
    private Dictionary<string, Room> _rooms = new();
    private Room _currentRoom;
    private Player _player = new(16, 16);
    private DrawBatch _drawBatch;
    private Camera _camera;

    // game data
    public const int TileDim = 32;

    public const int Wall = 1;
    public const int Walkable = 0;
    // end game data

    // DEBUG toggles
    const bool DrawHitBox = false;
    // endif

    public GameMain()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = false;
    }

    protected override void Initialize()
    {
        _rooms[RoomOneData.Id] = Room.Load(RoomOneData.Width, RoomOneData.Height, RoomOneData.Data, RoomOneData.Doors, RoomOneData.Keys);
        _rooms[RoomTwoData.Id] = Room.Load(RoomTwoData.Width, RoomTwoData.Height, RoomTwoData.Data, RoomTwoData.Doors, RoomTwoData.Keys);
        _rooms[RoomThreeData.Id] = Room.Load(RoomThreeData.Width, RoomThreeData.Height, RoomThreeData.Data, RoomThreeData.Doors, RoomThreeData.Keys);
        _rooms[RoomFourData.Id] = Room.Load(RoomFourData.Width, RoomFourData.Height, RoomFourData.Data, RoomFourData.Doors, RoomFourData.Keys);
        _rooms[RoomFiveData.Id] = Room.Load(RoomFiveData.Width, RoomFiveData.Height, RoomFiveData.Data, RoomFiveData.Doors, RoomFiveData.Keys);

        _currentRoom = _rooms[RoomOneData.Id];
        _player.Position = new(128, 128);

        _camera = new Camera(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _drawBatch = new DrawBatch(GraphicsDevice);
        _tile = Content.Load<Texture2D>("tile");
        _circle = Content.Load<Texture2D>("circle_16x16");
        _key = Content.Load<Texture2D>("key");
    }

    KeyboardState kb, pkb;

    protected override void Update(GameTime gameTime)
    {
        kb = Keyboard.GetState();

        var oldPosition = _player.Position;
        _player.Update(kb);

        // constrain to world
        _player.Position.X += _player.Velocity.X;
        if (Collided(_player.GetBounds()))
            _player.Position.X = oldPosition.X;

        _player.Position.Y += _player.Velocity.Y;
        if (Collided(_player.GetBounds()))
            _player.Position.Y = oldPosition.Y;

        _player.Velocity *= 0.9f;

        var playerCell = new Point((int)(_player.Position.X / 32), (int)(_player.Position.Y / 32));

        var playerRectangle = new Rectangle(playerCell.X - 8, playerCell.Y - 8, 16, 16);


        bool Collided(Rectangle bounds)
        {
            var leftTile = bounds.Left / TileDim;
            var rightTile = bounds.Right / TileDim;
            var topTile = bounds.Top / TileDim;
            var BottomTile = bounds.Bottom / TileDim;

            if (leftTile < 0) leftTile = 0;
            if (rightTile > TileDim) rightTile = TileDim;
            if (topTile < 0) topTile = 0;
            if (BottomTile > TileDim) BottomTile = TileDim;

            for (var i = leftTile; i <= rightTile; i++)
            {
                for (var j = topTile; j <= BottomTile; j++)
                {
                    var t = _currentRoom.Data[j, i];

                    if (t == Wall)
                        return true;
                }
            }

            return false;
        }


        // check if hit door
        foreach (var door in _currentRoom.Doors)
        {
            var rectangle = new Rectangle(door.Position.X * TileDim, door.Position.Y * TileDim, TileDim, TileDim);

            // player touched a door
            if (rectangle.Intersects(_player.GetBounds()))
            {
                if (door.IsLocked)
                    continue;

                // get next room
                var nextRoom = _rooms[door.DestinationRoomId];

                // get exit door
                var exitDoor = nextRoom.Doors.Single(x => x.Id == door.DestinationDoorId);

                var nextPosition = new Vector2(exitDoor.Position.X, exitDoor.Position.Y) * TileDim;
                switch (exitDoor.Facing)
                {
                    case Direction.North:
                        nextPosition.Y -= TileDim;
                        break;
                    case Direction.East:
                        nextPosition.X += TileDim;
                        break;
                    case Direction.South:
                        nextPosition.Y += TileDim;
                        break;
                    case Direction.West:
                        nextPosition.X -= TileDim;
                        break;
                    default:
                        break;
                }
                _player.Position = nextPosition;

                _currentRoom = nextRoom;
                break;
            }
        }

        // check if hit key
        foreach (var key in _currentRoom.Keys)
        {
            if (key.GetCircleBounds().Intersects(_player.GetCircleBounds()) && key.IsActive)
            {
                // player collected key
                _player.AddItem(key.Id);
                key.IsActive = false;

                // unlock all doors
                foreach (var room in _rooms.Values)
                {
                    foreach (var door in room.Doors)
                    {
                        if (door.KeyId == key.Id)
                        {
                            door.IsLocked = false;
                            door.Colour = "White";
                            room.Data[door.Position.Y, door.Position.X] = Walkable; // open door
                        }

                    }
                }

                break;
            }
        }

        _camera.Update(_player.Position);

        pkb = kb;
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin(transformMatrix: _camera.Transform);

        // draw level
        for (int i = 0; i < _currentRoom.Width; i++)
        {
            for (int j = 0; j < _currentRoom.Height; j++)
            {
                Vector2 pos = new(i * TileDim, j * TileDim);
                Color color = Color.White;

                switch (_currentRoom.Data[j, i])
                {
                    case Wall:
                        color = Color.FromNonPremultiplied(10, 10, b: 10, 255);
                        break;
                    case Walkable:
                        color = Color.FromNonPremultiplied(120, 120, b: 120, 255);
                        break;
                    default:
                        break;
                }

                _spriteBatch.Draw(_tile, pos, color);
            }
        }

        // draw exits
        foreach (var item in _currentRoom.Doors)
        {
            var color = Color.White;
            switch (item.Colour)
            {
                case "Yellow":
                    color = Color.Gold;
                    break;
                case "Cyan":
                    color = Color.Cyan;
                    break;
                default:
                    break;
            }

            _spriteBatch.Draw(_tile, new Vector2(item.Position.X * TileDim, item.Position.Y * TileDim), color);
        }

        foreach (var item in _currentRoom.Keys)
        {
            if (!item.IsActive)
                continue;

            var color = Color.White;
            switch (item.Id)
            {
                case "YellowKey":
                    color = Color.Yellow;
                    break;
                case "CyanKey":
                    color = Color.Cyan;
                    break;
                default:
                    break;
            }
            _spriteBatch.Draw(_key, new Vector2(item.Position.X * TileDim, item.Position.Y * TileDim), color);
        }

        // draw player
        _spriteBatch.Draw(_circle, _player.Position, Color.Red);

        _spriteBatch.End();


        //_drawBatch.Begin(DrawSortMode.Deferred, null, null, null, null, null, _camera.Transform);

        //_drawBatch.End();

        // draw camera movement box
        _drawBatch.Begin();
        //_drawBatch.DrawRectangle(Pen.Magenta, _camera.MovementBounds);
        _drawBatch.End();

        // draw screen stuff
        _spriteBatch.Begin();

        Vector2 start = new(10, GraphicsDevice.Viewport.Height - 32);
        foreach (var item in _player.Items)
        {
            switch (item)
            {
                case "YellowKey":
                    _spriteBatch.Draw(_key, start, Color.Yellow);
                    break;
                case "CyanKey":
                    _spriteBatch.Draw(_key, start, Color.Cyan);
                    break;
                default:
                    break;
            }
            start.X += 32;
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}