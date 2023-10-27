// https://medium.com/@hacj/yet-another-c-tile-dungeon-be371ed53862

/*
MIT License

Copyright (c) 2020 hacj

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

*/

/*
* YATD (yet another tile dungeon)
* A super-simple one-class script to generate a basic roguelike-esque dungeon, designed for a roguelike-esque game
* Drop this into your project and get right to work on your gameplay.
* It generates a variety of square rooms and puts corridors between each.
* Also generates an "entry" and "exit" tile in distant rooms.
* */

using System;
using System.Collections.Generic;

namespace Dungeons;

public enum Tile {
    FLOOR,
    INTERIOR_WALL,
    EXTERIOR_WALL,
    ENTRY,
    EXIT
}

public class Dungeon {
    private Tile[,] _tiles = new Tile[0,0];

    // Seed used to generate dungeon -> using the same seed always results in the same layout.
    private int _seed;

    // max dim of dungeon
    public int Width { get; private set; }
    public int Height { get; private set; }

    public int[] Start { get; private set; } = new int[0];
    public int[] Exit { get; private set; } = new int[0];

    // room sizes
    private readonly int _minRoomSize;
    private readonly int _maxRoomSize;

    // room count min and max
    private readonly int _minRoomCount;
    private readonly int _maxRoomCount;

    // Some default args for a dungeon I think looks nice for my use case. Overwrite them if you like!
    public Dungeon(int seed, int width = 35, int height = 35, int minRoomCount = 7, int maxRoomCount = 9, int minRoomSize = 3, int maxRoomSize = 5)
    {
        _seed = seed;
        Width = width;
        Height = height;
        _minRoomSize = minRoomSize;
        _maxRoomSize = maxRoomSize;
        _minRoomCount = minRoomCount;
        _maxRoomCount = maxRoomCount;

        // Set up tile grid with all walls
        FillInWalls();

        // Carve out rooms
        var rooms = AddRooms();

        // Connect rooms, add doors
        AddCorridors(rooms);

        // Add the entry and exit tiles.
        AddEntryExit(rooms);

        // Make distiction for intertor and exterior walls.
        DetermineWallTypes();
    }

    // Public functions

    // Better not go out of bounds lmao
    public Tile GetTileAt(int x, int y)
    {
        return _tiles[x, y];
    }

    // Generation stuff

    public void FillInWalls()
    {
        _tiles = new Tile[Width, Height];

        for (int x = 0; x != Width; ++x)
        {
            for (int y = 0; y != Height; ++y)
            {
                _tiles[x, y] = Tile.EXTERIOR_WALL;
            }
        }
    }

    public List<int[]> AddRooms()
    {
        List<int[]> roomCenters = new List<int[]>();

        int roomCount = RandomRange( _minRoomCount, _maxRoomCount);
        for (int i = 0; i != roomCount; ++i)
        {
            int x = RandomRange(_maxRoomSize, Width - _maxRoomSize);
            int y = RandomRange(_maxRoomSize, Height - _maxRoomSize);
            int w = RandomRange(_minRoomSize, _maxRoomSize);
            int h = RandomRange(_minRoomSize, _maxRoomSize);
            CarveOpen(x - (w/2), y - (h/2), w, h);
            roomCenters.Add(new int[2] { x, y });
        }
        return roomCenters;
    }

    public void AddCorridors(List<int[]> centers)
    {
        for(int i = 0; i != centers.Count - 1; ++i)
        {
            // Go from room to room, adding corridor between each.
            // carve only accepts positive width, height so find the lower x/y coords and go higher.
            CarveOpen(Math.Min(centers[i][0], centers[i + 1][0]), centers[i][1], 1 + Math.Abs(centers[i + 1][0] - centers[i][0]), 1);
            CarveOpen(centers[i+1][0], Math.Min(centers[i][1], centers[i + 1][1]), 1, 1 + Math.Abs(centers[i + 1][1] - centers[i][1]));
        }
    }

    public void AddEntryExit(List<int[]> centers)
    {
        int distHi = 0;
        int startIdx = -1;
        int endIdx = -1;

        // Pick the two rooms that are farthest away from each other.
        for (int i = 0; i != centers.Count; ++i)
        {
            for (int j = 0; j != centers.Count; ++j)
            {
                int dist = Math.Abs(centers[i][0] - centers[j][0]) + Math.Abs(centers[i][1] - centers[j][1]);

                if (dist > distHi)
                {
                    distHi = dist;
                    startIdx = i;
                    endIdx = j;
                }
            }
        }

        Start = centers[startIdx];
        Exit = centers[endIdx];

        _tiles[Start[0], Start[1]] = Tile.ENTRY;
        _tiles[Exit[0], Exit[1]] = Tile.EXIT;
    }

    public void DetermineWallTypes()
    {
        for (int x = 0; x != Width; ++x)
        {
            for (int y = 0; y != Height; ++y)
            {
                if(_tiles[x,y] != Tile.FLOOR)
                {
                    continue;
                }

                for (int dx = -1; dx <= 1; ++dx)
                {
                    for (int dy = -1; dy <= 1; ++dy)
                    {
                        // If there's an exterior wall, mark it as interior, instead.
                        if(_tiles[x+dx,y+dy] == Tile.EXTERIOR_WALL)
                        {
                            _tiles[x + dx, y + dy] = Tile.INTERIOR_WALL;
                        }
                    }
                }
            }
        }
    }

    // Fill part of the map with "floor", either as a rectangle
    private void CarveOpen(int x, int y, int width, int height)
    {
        if(width < 1 || height < 1)
        {
            return;
        }
        for (int dx = x; dx != x + width; ++dx)
        {
            for (int dy = y; dy != y + height; ++dy)
            {
                _tiles[dx, dy] = Tile.FLOOR;
            }
        }
    }

    // Portable method to derive a hashed value from an integer, which is useful to generate a "random" number
    private static int Inthash(ref int x)
    {
        if (x == 0)
        {
            x = 1;
        }
        x = ((x >> 16) ^ x) * 0x45d9f3b;
        x = ((x >> 16) ^ x) * 0x45d9f3b;
        x = (x >> 16) ^ x;
        return x;
    }

    // Helper to get random value from seed
    private int RandomRange(int min, int max)
    {
        int range = Inthash(ref _seed) % ((max + 1) - min);
        return min + range;
    }
}
