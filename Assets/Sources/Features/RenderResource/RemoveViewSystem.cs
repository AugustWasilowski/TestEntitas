using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

public class RemoveViewSystem : IReactiveSystem, ISetPool, IEnsureComponents
{
    public IMatcher ensureComponents
    {
        get
        {
            return Matcher.View;
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Resource.OnEntityRemoved();
        }
    }

    public void Execute(List<Entity> entities)
    {
        Debug.Log("RemoveViewSyste");
        foreach (var e in entities)
        {
            e.RemoveView();
        }
    }

    public void SetPool(Pool pool)
    {
        pool.GetGroup(Matcher.View).OnEntityRemoved += onEntityRemoved;
    }

    private void onEntityRemoved(Group group, Entity entity, int index, IComponent component)
    {
        var viewComponent = (ViewComponent)component;
        var gameObject = viewComponent.gameObject;
        var spriterenderer = gameObject.GetComponent<SpriteRenderer>();
        var color = spriterenderer.color;
        color.a = 0f;
        spriterenderer.material.DOColor(color, 0.2f);
        gameObject.transform.DOScale(Vector3.one * 1.5f, 0.2f).OnComplete(() => Object.Destroy(gameObject));
    }
}
