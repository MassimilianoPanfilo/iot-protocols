﻿namespace NetCoreClient.ValueObjects;

internal class Position
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public int Z { get; private set; }

    public Position(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}