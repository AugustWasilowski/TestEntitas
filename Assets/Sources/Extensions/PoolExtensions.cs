using Entitas;
using UnityEngine;
using System.Collections.Generic;

public static class PoolExtensions
{
    static readonly string[] _pieces =
    {
        Res.CandyBlue,
        Res.CandyGreen,
        Res.CandyOrange,
        Res.CandyRed
    };

    public static Entity CreateRandomPiece(this Pool pool, int x, int y)
    {
        int pieceId = Random.Range(0, _pieces.Length);
        string pieceName = _pieces[pieceId];

        return pool.CreateEntity()
           .IsGameBoardElement(true)
           .AddPosition(x, y)
           .IsMovable(true)
           .IsInteractive(true)
           .AddResource(pieceName, pieceId)
           .IsDetectMatch(true);
    }

    public static bool IsHorizontalMatch(this Pool pool, PositionComponent position, out Entity entity)
    {
        return pool.IsHorizontalMatch(position.x, position.y, out entity);
    }

    public static bool IsHorizontalMatch(this Pool pool, int x, int y, out Entity entity)
    {
        var gameboard = pool.gameBoard;
        bool edge = x == -1 || x == 0 || x == gameboard.columns || y == -1 || y == gameboard.rows;
        if (edge)
        {
            entity = null;
            return false;
        }
            
        entity = pool.gameBoardCache.grid[x -1, y];
        
        return entity == null;
    }
}
