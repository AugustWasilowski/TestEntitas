using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class FillSystem : IReactiveSystem, ISetPool
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
        Debug.Log("Fill");

        var gameBoard = _pool.gameBoard;
        var grid = _pool.gameBoardCache.grid;
        for (int depth = 0; depth < gameBoard.depths; depth++)
        {
            for (int column = 0; column < gameBoard.columns; column++)
            {
                var nextRowPos = grid.GetNextEmptyRow(column, gameBoard.rows);
                while (nextRowPos != gameBoard.rows)
                {
                    _pool.CreateRandomPiece(column, nextRowPos, depth); // TODO: z needs to be incremented. NextRowPos needs to swtich from y to z
                    nextRowPos = grid.GetNextEmptyRow(column, gameBoard.rows);
                }
            }
        }
        
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}

