﻿using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ProcessInputSystem : IReactiveSystem, ISetPool
{
    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Input.OnEntityAdded();
        }
    }

    Pool _pool;

    public void Execute(List<Entity> entities)
    {
        Debug.Log("Process Input");

        var inputEntity = entities.SingleEntity();
        var input = inputEntity.input;

        if (isInGameboard(input.x, input.y))
        {
            var e = _pool.gameBoardCache.grid[input.x, input.y, 0];
            if (e != null && e.isInteractive)
            {              
                _pool.DestroyAdjacentIfSame(e);
            }
        }

        _pool.DestroyEntity(inputEntity);
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    private bool isInGameboard(int x, int y)
    {
        return (x >= 0 && x < _pool.gameBoard.columns)
            && (y >= 0 && y < _pool.gameBoard.rows);
    }
}
