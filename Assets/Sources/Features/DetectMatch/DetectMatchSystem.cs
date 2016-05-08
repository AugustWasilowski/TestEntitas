using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;

public class DetectMatchSystem : IReactiveSystem, ISetPool
{
    static Vector2 ToVector(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return new Vector2(0, 1);
            case Direction.Right:
                return new Vector2(1, 0);
            case Direction.Down:
                return new Vector2(0, -1);
            case Direction.Left:
            default:
                return new Vector2(-1, 0);
        }
    }

    Group _group;

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
        Debug.Log("DetectMatch");

        var gameBoard = _pool.gameBoard;
        var grid = _pool.gameBoardCache.grid;
        var myEntities = _group.GetEntities();
        foreach (var e in entities)
        {
            if (e.hasPosition && HasHorizontalMatch(e))
            {
                Debug.Log("Entity Postion " + e.position);
                            
                var leftPosition = new PositionComponent(e.position.x - 1, e.position.y);

                var leftEntity = myEntities.FirstOrDefault(x => x.position == leftPosition);
                if (leftEntity != null)
                {
                    Debug.Log(string.Format("Destroying {0} at position {1}.", leftEntity, leftEntity.position));
                    //_pool.DestroyEntity(e);
                    leftEntity.isDestroy = true;
                }                
            }
        }
    }   

    public void SetPool(Pool pool)
    {
        _pool = pool;
        _group = _pool.GetGroup(Matcher.AllOf(Matcher.Destroy, Matcher.GameBoardElement, Matcher.Position, Matcher.DetectMatch, Matcher.Movable, Matcher.Interactive, Matcher.Resource));
    }

    private bool HasHorizontalMatch(Entity e)
    {
        return true;
    }
}

