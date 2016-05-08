using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

public class RenderPositionSystem : IReactiveSystem
{
    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.Position, Matcher.View).OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        Debug.Log("Render Posision");

        foreach (var e in entities)
        {
            var pos = e.position;
            e.view.gameObject.transform.DOMove(new Vector3(pos.x, pos.y, pos.z), 0.3f);
        }
    }
}
