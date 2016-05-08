using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class FallSystem : IReactiveSystem, ISetPool
{
    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.GameBoardElement.OnEntityRemoved();
        }
    }

    Pool _pool;

    public void Execute(List<Entity> entities)
    {
        Debug.Log("Fall");

        var gameBoard = _pool.gameBoard;
        var grid = _pool.gameBoardCache.grid;

        for (int depth = 0; depth < gameBoard.depths; depth++)
        {
            for (int column = 0; column < gameBoard.columns; column++)
            {
                for (int row = 0; row < gameBoard.rows; row++)
                {
                    var e = grid[column, row, 0];
                    if (e != null && e.isMovable)
                    {
                        moveForward(e, column, row, depth, grid); // TODO: This is broken somehow. 
                        //moveDown(e, column, row, grid);
                    }
                }
            }
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    private void moveDown(Entity e, int column, int row, Entity[,,] grid)
    {
        var nextRowPos = grid.GetNextEmptyRow(column, row);
        if (nextRowPos != row)
        {
            e.ReplacePosition(column, nextRowPos, e.position.z);
        }
    }

    private void moveForward(Entity e, int column, int row, int depth, Entity[,,] grid)
    {
        var nextDepthPos = grid.GetNextEmptyDepth(column, row, depth);
        if (nextDepthPos != depth)
        {
            e.ReplacePosition(column, row, nextDepthPos);
        }
    }
}

