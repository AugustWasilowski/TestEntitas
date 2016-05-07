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

    public static bool IsLeftEntityExist(this Pool pool, PositionComponent position, out Entity entity)
    {
        return pool.IsLeftEntityExist(position.x, position.y, out entity);
    }

    public static bool IsLeftEntityExist(this Pool pool, int x, int y, out Entity entity)
    {
        var gameboard = pool.gameBoard;
        if (x <= 0)
        {
            entity = null;
            return false;
        }
            
        entity = pool.gameBoardCache.grid[x -1, y];
        
        return entity != null;
    }

    public static bool IsRightEntityExist(this Pool pool, PositionComponent position, out Entity entity)
    {
        return pool.IsRightEntityExist(position.x, position.y, out entity);
    }

    public static bool IsRightEntityExist(this Pool pool, int x, int y, out Entity entity)
    {
        var gameboard = pool.gameBoard;
        if (x >= gameboard.columns - 1)
        {
            entity = null;
            return false;
        }

        entity = pool.gameBoardCache.grid[x + 1, y];

        return entity != null;
    }

    public static bool IsTopEntityExist(this Pool pool, PositionComponent position, out Entity entity)
    {
        return pool.IsTopEntityExist(position.x, position.y, out entity);
    }

    public static bool IsTopEntityExist(this Pool pool, int x, int y, out Entity entity)
    {
        var gameboard = pool.gameBoard;
        if (y >= gameboard.rows -1)
        {
            entity = null;
            return false;
        }

        entity = pool.gameBoardCache.grid[x, y + 1];

        return entity != null;
    }

    public static bool IsBottomEntityExist(this Pool pool, PositionComponent position, out Entity entity)
    {
        return pool.IsBottomEntityExist(position.x, position.y, out entity);
    }

    public static bool IsBottomEntityExist(this Pool pool, int x, int y, out Entity entity)
    {
        var gameboard = pool.gameBoard;
        if (y <= 0)
        {
            entity = null;
            return false;
        }

        entity = pool.gameBoardCache.grid[x, y - 1];

        return entity != null;
    }

    public static void DestroyAdjacentIfSame(this Pool pool, Entity e)
    {
        if (e.isDestroy)
        {
            return;
        }

        List<Entity> DetectedMatchingEntitites = new List<Entity>();

        Entity leftEntity;
        if (IsLeftEntityExist(pool, e.position, out leftEntity))
        {
            if (leftEntity.resource.name == e.resource.name)
            {
                e.isDestroy = true;
                DestroyAdjacentIfSame(pool, leftEntity);
                leftEntity.isDestroy = true;                
            }
        }

        Entity rightEntity;
        if (IsRightEntityExist(pool, e.position, out rightEntity))
        {
            if (rightEntity.resource.name == e.resource.name)
            {
                e.isDestroy = true;
                DestroyAdjacentIfSame(pool, rightEntity);
                rightEntity.isDestroy = true;                
            }
        }

        Entity topEntity;
        if (IsTopEntityExist(pool, e.position, out topEntity))
        {
            if (topEntity.resource.name == e.resource.name)
            {
                e.isDestroy = true;
                DestroyAdjacentIfSame(pool, topEntity);
                topEntity.isDestroy = true;
            }
        }

        Entity bottomEntity;
        if (IsBottomEntityExist(pool, e.position, out bottomEntity))
        {
            if (bottomEntity.resource.name == e.resource.name)
            {
                e.isDestroy = true;
                DestroyAdjacentIfSame(pool, bottomEntity);
                bottomEntity.isDestroy = true;
            }
        }
    }

    private static bool IsEdgePiece(Pool pool, int x, int y)
    {
        var gameboard = pool.gameBoard;
        return x == -1 || x == 0 || x == gameboard.columns - 1 || y == -1 || y == 0 || y == gameboard.rows - 1;
    }    
}
