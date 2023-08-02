using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Dungeon;

public static class RoomOneData
{
    public const int Width = 14;
    public const int Height = 10;
    public const string Id = "Room1";

    public readonly static List<Door> Doors = new()
    {
        new Door(new Point(13, 2), "A", "Room2", "A","YellowKey", Direction.West, true, "Yellow"),
        new Door(new Point(5, 0), "C", "Room3", "A", "CyanKey",Direction.South, true, colour:"Cyan")
    };

    public readonly static List<Key> Keys = new()
    {
        new Key(new Point(10,5), "YellowKey", "Room2", "A", "Yellow Key", true)
    };

    public static readonly int[,] Data =
    {
        {  1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
        {  1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        {  1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {  1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        {  1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        {  1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        {  1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        {  1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        {  1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        {  1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
    };
}
