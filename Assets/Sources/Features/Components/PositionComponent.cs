﻿using Entitas;

public class PositionComponent : IComponent
{
    public PositionComponent()
    {

    }

    public PositionComponent(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public int x;
    public int y;
    public int z;
}

